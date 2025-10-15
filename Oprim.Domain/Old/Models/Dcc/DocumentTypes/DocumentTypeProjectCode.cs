using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    public class DocumentTypeProjectCode : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("DocumentTypeId")] public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }

        public string Code { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                $"{nameof(DocumentTypeProjectCode)}-{ProjectId}",
                $"{nameof(DocumentTypeProjectCode)}-SelectList,{ProjectId}",
                $"{nameof(DocumentTypeProjectCode)}-CreatableSelectList,{ProjectId}",
            };
        }
    }
}
