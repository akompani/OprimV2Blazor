using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectRelation: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ContainerId")] public Project? Container { get; set; }
        public int ContainerId { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public double Weight { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(ProjectRelation) };
        }
    }
}
