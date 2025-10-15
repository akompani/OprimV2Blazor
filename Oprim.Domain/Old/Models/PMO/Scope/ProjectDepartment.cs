using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Scope
{
    [Index(nameof(ProjectId), nameof(Code), IsUnique = true)]
    public class ProjectDepartment : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [MaxLength(5)]
        public string Code { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectDepartment), ProjectId)};
        }
    }
}
