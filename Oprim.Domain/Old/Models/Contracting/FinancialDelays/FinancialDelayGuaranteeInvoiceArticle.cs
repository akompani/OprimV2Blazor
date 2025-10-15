using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    public class FinancialDelayGuaranteeInvoiceArticle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("InvoiceId")]
        public FinancialDelayGuaranteeInvoice FinancialDelayGuaranteeInvoice { get; set; }
        public long InvoiceId { get; set; }

        public int Row { get; set; }

        public string Name { get; set; }

        public string EffectiveDate { get; set; }

        public double EffectiveDateIndex { get; set; }

        public string PaymentDate { get; set; }

        public double PaymentDateIndex { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EffectiveAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Result { get; set; }

        public void Calculate()
        {
            if (EffectiveDateIndex > 0)
            {
                Result = (long)(((PaymentDateIndex / EffectiveDateIndex) - 1) * EffectiveAmount);
            }
        }
    }
}
