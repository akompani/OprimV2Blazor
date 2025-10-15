using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentAttach: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        [ForeignKey("DocumentTypeBaseAttachId")] public DocumentBasePredecessor DocumentTypeBaseAttach { get; set; }
        public int DocumentTypeBaseAttachId { get; set; }

        [ForeignKey("AttachDocumentId")] public Document AttachDocument { get; set; }
        public long AttachDocumentId { get; set; }

        [MaxLength(20)]
        public string AttachTime { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        public string[] DefaultCacheNames() => new []{ICacheModel.CreateCacheName(nameof(DocumentAttach), DocumentId)};
    }
}
