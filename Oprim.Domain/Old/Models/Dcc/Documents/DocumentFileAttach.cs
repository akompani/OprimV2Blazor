using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.Dcc.FileManager;
using Oprim.Domain.Old.Models.Organization.Stakeholders;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentFileAttach: ICacheModel
    {
        public DocumentFileAttach()
        {
            
        }

        public DocumentFileAttach(long documentId, long articleId, long fileId, int joinerId)
        {
            DocumentId = documentId;
            ArticleId = articleId;
            FileId = fileId;
            JoinerId = joinerId;
            AttacheTime = PersianDateTime.Now.FullDateTime();
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        [ForeignKey("FileId")] public FileModel File { get; set; }
        public long FileId { get; set; }

        [ForeignKey("JoinerId")] public Stakeholder Joiner { get; set; }
        public int JoinerId { get; set; }

        [MaxLength(20)]
        public string AttacheTime { get; set; }

        public string[] DefaultCacheNames() => new[]
            { ICacheModel.CreateCacheName(nameof(DocumentFileAttach), DocumentId) };
    }
}
