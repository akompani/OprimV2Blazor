using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Scope
{
    [Index(nameof(ProjectId), nameof(Code), IsUnique = true)]
    public class ProjectDepartmentItem: ICacheModel,ISummarize
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("DepartmentId")] public ProjectDepartment Department { get; set; }
        public int DepartmentId { get; set; }

        public int Row { get; set; }
        
        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public string FullName
        {
            get
            {
                return Id == 0 ? Name : ($"{Department?.Name ?? ""} - {Name}");
            }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectDepartmentItem), ProjectId)};
        }

        public SummarizeTemplate GetSummarize()
        {
            return new SummarizeTemplate(Id, FullName);
        }
    }
}
