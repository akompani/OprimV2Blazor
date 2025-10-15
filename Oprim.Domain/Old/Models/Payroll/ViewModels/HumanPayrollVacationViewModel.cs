using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollVacationViewModel : HumanPayrollVacation
    {
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }
    }
}
