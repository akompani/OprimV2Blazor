using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.Invoices;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.Contracting.CurrencyEscalation
{
    public class CurrencyEscalationStatement: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("InvoiceId")] public Invoice Invoice { get; set; }
        public long InvoiceId { get; set; }

        [ForeignKey("ArticleId")] public WorkArticle Article { get; set; }
        public long ArticleId { get; set; }

        [ForeignKey("PrevStatementId")] public Invoice PrevStatement { get; set; }
        public long PrevStatementId { get; set; }

        [ForeignKey("ThisStatementId")] public Invoice ThisStatement { get; set; }
        public long ThisStatementId { get; set; }


        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(CurrencyEscalationStatement), InvoiceId) };
        }
    }
}
