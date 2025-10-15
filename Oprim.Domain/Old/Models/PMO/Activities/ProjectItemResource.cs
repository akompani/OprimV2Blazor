using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Activities
{
    public class ProjectItemResource: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public OprimResourceTypes ResourceType { get; set; }

        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        public double Quantity { get; set; }
        
        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectItemResource), ProjectItemId)};
        }
    }
}
