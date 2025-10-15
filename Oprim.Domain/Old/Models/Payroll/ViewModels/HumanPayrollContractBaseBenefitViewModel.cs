using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollContractBaseBenefitViewModel : HumanPayrollContractBaseBenefit
    {
        public string BenefitTypeName { get; set; }
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }
    }
}
