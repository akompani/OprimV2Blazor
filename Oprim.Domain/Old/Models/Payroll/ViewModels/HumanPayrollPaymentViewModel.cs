using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Payroll.ViewModels
{
    public class HumanPayrollPaymentViewModel: HumanPayrollPayment
    {
        public PersianDateTime PersianDate { get; set; }

        public string ContractName { get; set; }
    }
}
