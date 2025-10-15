using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    public class ScheduleActivityActualCost: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public int Day { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("ProjectActivityId")] public ScheduleActivity? ProjectActivity { get; set; }
        public long ProjectActivityId { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public bool ManualEntry { get; set; }

        public string CreateDate { get; set; }

        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []
            {
                ICacheModel.CreateCacheName(nameof(ScheduleActivityActualCost), ProjectActivityId),
                ICacheModel.CreateCacheName("ActionPlan",Date)
            };
        }

    }
}
