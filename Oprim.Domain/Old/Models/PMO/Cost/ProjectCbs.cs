using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Cost
{
    [Index(nameof(Code), IsUnique = true)]
    public class ProjectCbs : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }


        [Range(1, 20)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public long? TopLevelId { get; set; }

        public long EstimateCost { get; set; }

        public long TotalCost { get; set; }
        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectCbs), ProjectId)};
        }
    }
}
