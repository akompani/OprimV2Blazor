using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Patterns.PMO.Projects.Queries.GetProjects;
using Oprim.Domain.Entities.PMO;
using Oprim.Domain.Entities.Quality;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Ui.Components.Shared.Dialogs.PunchItems;

public partial class PunchItemDialog
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = default!;
    [Parameter] public PunchItem? Item { get; set; } // اگر null بود یعنی Create، وگرنه Edit
    [Inject] private IMediator _mediator { set; get; }
    private MudForm? _form;
    private PunchItem _model = new();
    private List<Project> _projects = [];
    private List<ProjectItem> _projectItems = [];
    private List<ProjectDepartmentItem> _departmentItems = [];

    protected override void OnInitialized()
    {
    }

    protected override async Task OnInitializedAsync()
    {
        _projects = await _mediator.Send(new GetProjectsQuery());
        _model = Item is null
            ? new PunchItem { CreateTime = DateTime.Now }
            : new PunchItem
            {
                Id = Item.Id,
                Notes = Item.Notes,
                CreateTime = DateTime.Now,
                OpponentLinks = Item.OpponentLinks,
                ProjectId = Item.ProjectId,
                DepartmentItemId = Item.DepartmentItemId,
                ProjectItemId = Item.ProjectItemId,
            };
        StateHasChanged();
    }

    private async Task Submit()
    {
        await _form!.Validate();

        if (_form.IsValid)
            MudDialog.Close(DialogResult.Ok(_model));
        _model = null;
    }

    private void Cancel() => MudDialog.Cancel();

    private void OnValidated()
    {
    }
}