using MediatR;
using Microsoft.AspNetCore.Components;
using Oprim.Application.Patterns.Cost.ProjectCostBreakdowns.Queries.GetProjectCostBreakdowns;
using Oprim.Application.Patterns.PMO.ProjectItemGroups.Queries.GetProjectItemGroups;
using Oprim.Domain.Entities.Cost;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Ui.Components.Shared.Dialogs.ProjectItems;

public partial class ProjectItemDialog
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = default!;
    [Parameter] public ProjectItem? Item { get; set; }
    [Inject] private IMediator _mediator { set; get; }
    private MudForm? _form;
    private ProjectItem _model = new();
    private List<ProjectItemGroup> _projects = [];
    private List<ProjectCostBreakdown> _breakdowns = [];
    private string _titlePage = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (Item is null)
        {
            _model = new ProjectItem();
            _titlePage = "فرم ثبت  گروه پروژه";
        }
        else
        {
            _titlePage = "فرم ویرایش گروه پروژه";
            _model = new ProjectItem
            {
                Id = Item.Id,
                Name = Item.Name,
                CreateTime = Item.CreateTime,
                ProjectId = Item.ProjectId,
                Code = Item.Code,
                EstimateCost = Item.EstimateCost,
                TotalCost = Item.TotalCost,
                Unit = Item.Unit,
                EngineeringLead = Item.EngineeringLead,
                EstimateQuantity = Item.EstimateQuantity,
                ProcurementLead = Item.ProcurementLead,
                TotalQuantity = Item.TotalQuantity,
                EstimateUnitCost = Item.EstimateCost,
                ProjectCostBreakdownId = Item.ProjectCostBreakdownId,
                ProjectItemGroupId = Item.ProjectItemGroupId,
                QuantityForOneHour = Item.QuantityForOneHour,
            };
        }

        _projects = await _mediator.Send(new GetProjectItemGroupsQuery());
        _breakdowns = await _mediator.Send(new GetProjectCostBreakdownsQuery());
        StateHasChanged();
    }

    private async Task Submit()
    {
        await _form!.Validate();
        if (_form.IsValid)
        {
            _model.ProjectId = _projects.FirstOrDefault(x => x.Id == _model.ProjectItemGroupId).ProjectId;
            MudDialog.Close(DialogResult.Ok(_model));
            _model = null;
        }
    }

    private void Cancel() => MudDialog.Cancel();

    private void OnValidated()
    {
    }
}