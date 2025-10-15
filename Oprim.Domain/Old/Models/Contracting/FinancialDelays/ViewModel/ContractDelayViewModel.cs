using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays.ViewModel
{
    public class ContractDelayViewModel : FinancialDelay
    {

        public PersianDateTime CalculatePersianDateTime { get; set; }
        public PersianDateTime StartPeriodPersianDateTime { get; set; }
        public PersianDateTime EffectivePeriodPersianDateTime { get; set; }
        public PersianDateTime FinishPeriodPersianDateTime { get; set; }

    }
}
