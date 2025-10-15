using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.FinancialDelays
{
    public class FinancialDelayOverlapArticle
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("FinancialDelayId")] public FinancialDelay FinancialDelay { get; set; }
        public int FinancialDelayId { get; set; }

        public int Row { get; set; }

        public string Name { get; set; }

        public string EffectiveDate { get; set; }

        public string PaymentDate { get; set; }

        public int Delay { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long DelayAmount { get; set; }

        public int ContinuousDay { get; set; }

        public string StartEffectDate { get; set; }
    }
}
