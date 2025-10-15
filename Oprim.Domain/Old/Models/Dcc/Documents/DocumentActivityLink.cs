using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Activities;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentActivityLink: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        [ForeignKey("DocumentId")] public Document Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        public decimal WeightInDocument { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(DocumentActivityLink), DocumentId)};
        }
    }
}
