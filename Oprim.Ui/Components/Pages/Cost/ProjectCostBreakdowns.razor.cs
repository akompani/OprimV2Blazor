using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Dtos.PageableParams;
using Oprim.Application.Interfaces;
using Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdowns;
using Oprim.Domain.Entities.Cost;
using Oprim.Ui.Components.Shared.Dialogs.ProjectCostBreakdowns;

namespace Oprim.Ui.Components.Pages.Cost;

public partial class ProjectCostBreakdowns
{
    [Inject] private IUnitOfWork _ofWork { get; set; } = default!;
    [Inject] private IMediator Mediator { get; set; } = default!;
    [Inject] private IDialogService DialogService { get; set; } = default!;
    private string searchString1 = "";
    private ProjectCostBreakdown? selectedItem1;
    private List<ProjectCostBreakdown> _items = [];
    private bool _loading = true; // ← فلگ لودینگ
    


    private async Task LoadData()
    {
        try
        {
            _loading = true;
            _items = await Mediator.Send(new GetProjectCostBreakdownsQuery());
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
    private async Task CreateItem()
    {
        var parameters = new DialogParameters { ["Item"] = null };
        var dialog = DialogService.Show<ProjectCostBreakdownDialog>("", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var newItem = (ProjectCostBreakdown)result.Data!;
            await _ofWork.GenericRepository<ProjectCostBreakdown>().AddAsync(newItem, CancellationToken.None);
            _items.Add(newItem);
            await LoadData();
        }
    }

    private async Task EditItem(ProjectCostBreakdown item)
    {
        var parameters = new DialogParameters { ["Item"] = item };
        var dialog = DialogService.Show<ProjectCostBreakdownDialog>("", parameters);
        var result = await dialog.Result;

        if (!result.Canceled)
        {
            var updated = (ProjectCostBreakdown)result.Data!;
            await _ofWork.GenericRepository<ProjectCostBreakdown>().UpdateAsync(updated, CancellationToken.None);
            var index = _items.FindIndex(x => x.Id == updated.Id);
            if (index >= 0) _items[index] = updated;
            await LoadData();
        }
    }

    private bool FilterFunc1(ProjectCostBreakdown element) =>
        string.IsNullOrWhiteSpace(searchString1) ||
        element.Name.Contains(searchString1, StringComparison.OrdinalIgnoreCase);
}