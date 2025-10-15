using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Activities
{
    public class ProjectActivityProgress : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        public int Day { get; set; }

        [MaxLength(10)]
        public string DayDate { get; set; }

        public decimal Progress { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectActivityProgress), ProjectId)};
        }
    }
}
