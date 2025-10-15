using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Scope;

namespace Oprim.Domain.Old.Models.Dcc.Documents
{
    public class DocumentDepartment : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("DocumentId")] public Document? Document { get; set; }
        public long DocumentId { get; set; }

        public long ArticleId { get; set; }

        [ForeignKey("DepartmentItemId")] public ProjectDepartmentItem? DepartmentItem { get; set; }
        public long DepartmentItemId { get; set; }

        [DefaultValue(1)]
        public decimal PhysicalWeight { get; set; }

        public string[] DefaultCacheNames() => new []{ ICacheModel.CreateCacheName(nameof(DocumentDepartment), DocumentId)};
    }
}
