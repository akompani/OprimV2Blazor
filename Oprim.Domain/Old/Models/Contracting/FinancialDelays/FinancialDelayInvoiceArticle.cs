using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    public class FinancialDelayInvoiceArticle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("FinancialDelayId")] public FinancialDelay FinancialDelay { get; set; }
        public int FinancialDelayId { get; set; }

        public int Row { get; set; }

        public string Name { get; set; }

        public string SendDate { get; set; }

        public string EffectiveDate { get; set; }
        
        public int Duration { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long CumulativeAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Result { get; set; }
    }
}
