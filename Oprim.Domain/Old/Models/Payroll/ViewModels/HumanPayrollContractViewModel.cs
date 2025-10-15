using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollContractViewModel : HumanPayrollContract
    {
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }
    }
}
