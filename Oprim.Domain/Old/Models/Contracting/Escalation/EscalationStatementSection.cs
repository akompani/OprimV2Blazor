using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.Escalation
{
    public class EscalationStatementSection: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("StatementId")] public EscalationStatement Statement { get; set; }
        public long StatementId { get; set; }

        public int FieldCode { get; set; }

        public int SectionCode { get; set; }

        public string FAmount { get; set; }

        public string SAmount { get; set; }

        public string ThisAmount { get; set; }

        public int PeriodNo { get; set; }

        public string PeriodYear { get; set; }

        public string PeriodNameInYear { get; set; }

        public string FactorText { get; set; }

        public long PeriodAmount { get; set; }

        public double BaseIndex { get; set; }

        public double ThisIndex { get; set; }

        public double EscalationFactor { get; set; }

        public long SectionEscalationAmount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(EscalationStatementSection), StatementId) };
        }
    }
}
