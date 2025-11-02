using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Dtos.PageableParams;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Quality.PunchItems.Queries.GetPunches;
using Oprim.Domain.Entities.Quality;
using Oprim.Ui.Components.Shared.Dialogs.PunchItems;

namespace Oprim.Ui.Components.Pages.Qc;

public partial class PunchItems
{
    [Inject] private IUnitOfWork _ofWork { get; set; } = default!;
    [Inject] private IMediator Mediator { get; set; } = default!;
    [Inject] private IDialogService DialogService { get; set; } = default!;
    private string searchString1 = "";
    private PunchItem? selectedItem1;
    private List<PunchItem> _items = [];
    private bool _loading = true; // ← فلگ لودینگ

    private async Task LoadData()
    {
        try
        {
            _loading = true;
            await Task.Delay(100);
            _items = await Mediator.Send(new GetPunchesQuery());
            Console.WriteLine(_items.Count);
        }
        finally
        {
            _loading = false;
        }

        StateHasChanged();
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    private async Task CreateItem()
    {
        var parameters = new DialogParameters { ["Item"] = null };
        var dialog = DialogService.Show<PunchItemDialog>("", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var newItem = (PunchItem)result.Data!;
            await _ofWork.GenericRepository<PunchItem>().AddAsync(newItem, CancellationToken.None);
            _items.Add(newItem);
            await LoadData();
        }
    }
    private PageableParam _filter = new PageableParam
    {
        PageSize = 10,
        Page = 1,
        Search = string.Empty,
        TotalPage = 0
    };

    private async Task OnPageChanged(int newPage)
    {
        _filter.Page = newPage;
        await LoadData();
    }
    private async Task EditItem(PunchItem item)
    {
        var parameters = new DialogParameters { ["Item"] = item };
        var dialog = DialogService.Show<PunchItemDialog>("", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var updated = (PunchItem)result.Data!;
            await _ofWork.GenericRepository<PunchItem>().UpdateAsync(updated, CancellationToken.None);
            var index = _items.FindIndex(x => x.Id == updated.Id);
            if (index >= 0) _items[index] = updated;
            await LoadData();
        }
    }

    private bool FilterFunc1(PunchItem element) =>
        string.IsNullOrWhiteSpace(searchString1) ||
        element.Notes.Contains(searchString1, StringComparison.OrdinalIgnoreCase);
}