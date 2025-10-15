using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.CurrencyEscalation
{
    public class CurrencyEscalationStatementCover : ICacheModel 
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("StatementId")] public CurrencyEscalationStatement Statement { get; set; }
        public long StatementId { get; set; }

        public string Year { get; set; }

        public string Period { get; set; }

        public string PeriodFullname { get; set; }

        public int Days { get; set; }

        public string FactorText { get; set; }

        public string PeriodStartDate { get; set; }

        public string PeriodEndDate { get; set; }

        public string PeriodIndexType { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(CurrencyEscalationStatementCover), StatementId)
            };
        }
    }
}
