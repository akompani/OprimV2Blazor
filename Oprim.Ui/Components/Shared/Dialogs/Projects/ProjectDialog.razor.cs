using Microsoft.AspNetCore.Components;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Ui.Components.Shared.Dialogs.Projects;

public partial class ProjectDialog
{
    [CascadingParameter] private IMudDialogInstance MudDialog { get; set; } = default!;
    [Parameter] public Project? Item { get; set; }
    private MudForm? _form;
    private Project _model = new();
    private DateTime? _contractDate;
    private DateTime? _startDate;
    private DateTime? _contractContinuousDate;
    private DateTime? _finishDate;
    private DateTime? _offerDate;

    protected override void OnInitialized()
    {
        if (Item is null)
        {
            _model = new Project();
            _contractDate = DateTime.Now;
            _startDate = DateTime.Now;
            _finishDate = DateTime.Now;
            _offerDate = DateTime.Now;
            _contractContinuousDate = DateTime.Now;
        }
        else
        {
            _model = new Project
            {
                Id = Item.Id,
                Code = Item.Code,
                No = Item.No,
                Name = Item.Name,
                ClientName = Item.ClientName,
                ContractorName = Item.ContractorName,
                BaseAmount = Item.BaseAmount,
                PlanType = Item.PlanType,
                ContractDate = Item.ContractDate,
                FinishDate = Item.FinishDate,
                Apply76574 = Item.Apply76574,
                Escalation = Item.Escalation,
                Location = Item.Location,
                Lock = Item.Lock,
                OfferDate = Item.OfferDate,
                ComponentType = Item.ComponentType,
                ConsultantName = Item.ConsultantName,
                StartDate = Item.StartDate,
                CreateTime = Item.CreateTime,
                EscalationDecimal = Item.EscalationDecimal,
                FehrestYear = Item.FehrestYear,
                IsFehrestic = Item.IsFehrestic,
                OfferFactor = Item.OfferFactor,
                OverheadFactor = Item.OverheadFactor,
                ContractContinuousDate = Item.ContractContinuousDate,
                ContractContinuousDays = Item.ContractContinuousDays,
                ContractDurationDays = Item.ContractDurationDays,
                EscalationBasePeriod = Item.EscalationBasePeriod,
                LastUpdateProgress = Item.LastUpdateProgress,
                SiteMobilizationFieldCode = Item.SiteMobilizationFieldCode
            };

            _contractDate = Item.ContractDate;
            _startDate = Item.StartDate;
            _finishDate = Item.FinishDate;
            _contractContinuousDate = Item.ContractDate;
            _offerDate = Item.OfferDate;
        }
    }

    private async Task Submit()
    {
        await _form!.Validate();
        if (_form.IsValid)
        {
            _model.ContractDate = _contractDate ?? DateTime.Now;
            _model.StartDate = _startDate ?? DateTime.Now;
            _model.FinishDate = _finishDate ?? DateTime.Now;
            _model.ContractDate = _contractContinuousDate ?? DateTime.Now;
            _model.OfferDate = _offerDate ?? DateTime.Now;

            MudDialog.Close(DialogResult.Ok(_model));

            _model = null;
        }
    }

    private void Cancel() => MudDialog.Cancel();

    private void OnValidated()
    {
    }
}