using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Contracting.Payments.ViewModel
{
    public class PaymentViewModel : Payment
    {
        public PersianDateTime ActualPersianDateTime { get; set; }
        public PersianDateTime EslahiPersianDateTime { get; set; }

    }
}
