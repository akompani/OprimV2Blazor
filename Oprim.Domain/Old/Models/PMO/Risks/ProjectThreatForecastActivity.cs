using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Activities;

namespace Oprim.Domain.Old.Models.PMO.Risks
{
    public class ProjectThreatForecastActivity : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        [ForeignKey("ProjectThreatId")] public ProjectThreat? ProjectThreat { get; set; }
        public long ProjectThreatId { get; set; }

        public string FullName()
        {
            return $"{ProjectThreat?.Name ?? ""} - {ProjectItem?.Name ?? ""} ";
        }


        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectThreatForecastActivity), ProjectThreatId)};
        }
    }
}
