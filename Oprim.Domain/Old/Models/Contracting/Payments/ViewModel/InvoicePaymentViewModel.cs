using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Contracting.Payments.ViewModel
{
    public class InvoicePaymentViewModel : InvoicePayment
    {
        public PersianDateTime PaymentTime { get; set; }
        public PersianDateTime StartEffect { get; set; }
        public PersianDateTime FinishEffect { get; set; }
    }
}
