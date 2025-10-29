using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Patterns.PMO.Projects.Queries.GetProjects;
using Oprim.Domain.Entities.PMO;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Ui.Components.Shared.Dialogs.ProjectDepartmentDialogs;

public partial class ProjectDepartmentDialog
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = default!;
    [Parameter] public ProjectDepartment? Item { get; set; }
    [Inject] private IMediator _mediator { set; get; }
    private MudForm? _form;
    private ProjectDepartment _model = new();
    private List<Project> _projects = [];
    private string _titlePage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (Item is null)
        {
            _model = new ProjectDepartment();
            _titlePage = "فرم ثبت  گروه پروژه";
        }
        else
        {
            _titlePage = "فرم ویرایش گروه پروژه";
            _model = new ProjectDepartment
            {
                Id = Item.Id,
                Name = Item.Name,
                CreateTime = Item.CreateTime,
                ProjectId = Item.ProjectId,
                Code = Item.Code
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