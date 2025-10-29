using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Patterns.PMO.Projects.Queries.GetProjects;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Ui.Components.Shared.Dialogs.Projects;

public partial class ProjectItemGroupDialog
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = default!;
    [Parameter] public ProjectItemGroup? Item { get; set; }
    [Inject] private IMediator _mediator { set; get; }
    private MudForm? _form;
    private ProjectItemGroup _model = new();
    private List<Project> _projects = [];
    private string _titlePage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (Item is null)
        {
            _model = new ProjectItemGroup();
            _titlePage = "فرم ثبت  گروه پروژه";
        }
        else
        {
            _titlePage = "فرم ویرایش گروه پروژه";
            _model = new ProjectItemGroup
            {
                Id = Item.Id,
                Name = Item.Name,
                CreateTime = Item.CreateTime,
                ProjectId = Item.ProjectId
            };
        }

        _projects = await _mediator.Send(new GetProjectsQuery());
        StateHasChanged();
    }

    private async Task Submit()
    {
        await _form!.Validate();
        if (_form.IsValid)
        {
            MudDialog.Close(DialogResult.Ok(_model));
            _model = null;
        }
    }

    private void Cancel() => MudDialog.Cancel();

    private void OnValidated()
    {
    }
}