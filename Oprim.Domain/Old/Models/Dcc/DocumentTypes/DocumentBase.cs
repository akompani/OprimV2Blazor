using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.WorkFlow.WorkBases;

namespace Oprim.Domain.Old.Models.Dcc.DocumentTypes
{
    [Index(nameof(ProjectId),nameof(PrefixCode),IsUnique = true)]
    public class DocumentBase:ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public bool DefaultSystemDocument { get; set; }

        [ForeignKey("DocumentTypeId")] public DocumentType DocumentType { get; set; }
        public int DocumentTypeId { get; set; }

        [MaxLength(3)]
        public string PrefixCode { get; set; }

        public string Name { get; set; }

        public string? FolderName { get; set; }

        [ForeignKey("WorkBaseId")] public WorkBase WorkBase { get; set; }
        public int WorkBaseId { get; set; }

        public bool LinkToWbs { get; set; }
        public bool LinkToProjectItem { get; set; }
        public bool LinkToDepartmentItem { get; set; }

        public bool HaveContractItemList { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(DocumentBase), ProjectId)};
        }
    }
}
