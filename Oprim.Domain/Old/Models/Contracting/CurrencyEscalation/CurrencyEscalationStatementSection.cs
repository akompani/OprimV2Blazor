using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.CurrencyEscalation
{
    public class CurrencyEscalationStatementSection : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("StatementId")] public CurrencyEscalationStatement Statement { get; set; }
        public long StatementId { get; set; }

        public int  FieldNo { get; set; }

        public int SectionNo { get; set; }

        public string PrevAmount { get; set; }

        public string Amount { get; set; }

        public string ThisAmount { get; set; }

        public int PeriodNo { get; set; }

        public string PeriodYear { get; set; }

        public string PeriodNameInYear { get; set; }

        public string FactorText { get; set; }

        public long PeriodAmount { get; set; }

        public double BaseIndex { get; set; }

        public double ThisIndex { get; set; }

        public double EscalationFactor { get; set; }

        public long SectionAmount { get; set; }


        //پارامترهای بخشنامه ارز
        public double T { get; set; }
        public double Q { get; set; }


        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(CurrencyEscalationStatementSection), StatementId)
            };
        }
    }
}
