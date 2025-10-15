using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.Escalation
{
    public class EscalationStatementCover: ICacheModel
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("StatementId")] public EscalationStatement Statement { get; set; }
        public long StatementId { get; set; }

        public string Year { get; set; }

        public string Period { get; set; }

        public string PeriodFullname { get; set; }

        public int Days { get; set; }

        public string FactorText { get; set; }

        public DateTime PeriodStartDate { get; set; }

        public DateTime PeriodEndDate { get; set; }

        public string PeriodIndexType { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(EscalationStatementCover), StatementId) };
        }
    }
}
