using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.Invoices;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.Contracting.Escalation
{
    public class EscalationStatement: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("InvoiceId")] public Invoice Invoice { get; set; }
        public long InvoiceId { get; set; }

        [ForeignKey("ArticleId")] public WorkArticle Article { get; set; }
        public long ArticleId { get; set; }

        [Display(Name = "صورت وضعیت قبلی")]
        [ForeignKey("PrevStatementId")] public Invoice PrevStatement { get; set; }
        public long PrevStatementId { get; set; }

        [Display(Name = "صورت وضعیت فعلی")]
        [ForeignKey("ThisStatementId")] public Invoice ThisStatement { get; set; }
        public long ThisStatementId { get; set; }
        
        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(EscalationStatement), ArticleId)};
        }
    }
}
