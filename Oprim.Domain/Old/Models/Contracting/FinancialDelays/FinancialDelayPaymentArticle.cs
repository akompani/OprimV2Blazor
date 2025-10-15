using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    public class FinancialDelayPaymentArticle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("FinancialDelayId")] public FinancialDelay FinancialDelay { get; set; }
        public int FinancialDelayId { get; set; }

        public int Row { get; set; }

        [MaxLength(10)]
        public string PaymentDate { get; set; }

        public int Duration { get; set; }

        [MaxLength(10)]
        public string PaymentType { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long BoostedAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long CumulativeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Result { get; set; }
    }
}
