using MD.PersianDateTime;
using Oprim.Domain.Old.Models.Contracting.Payments;

namespace Oprim.Domain.Old.Models.Contracting.Invoices.ViewModel
{
    public class InvoiceViewModel : Invoice
    {

        public PersianDateTime Send { get; set; }
        public PersianDateTime StartPeriod { get; set; }
        public PersianDateTime FinishPeriod { get; set; }
        public PersianDateTime ConsultantApprove { get; set; }
        public PersianDateTime ClientApprove { get; set; }
        public PersianDateTime Effective { get; set; }

        public List<InvoiceExtra> InvoiceExtras { get; set; }
        public List<InvoicePayment> InvoicePayments { get; set; }


      
    }
}
