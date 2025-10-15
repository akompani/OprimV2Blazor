using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Scope;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ScheduleActivityDeliverable : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("ProjectDeliverableId")] public ProjectDeliverable? ProjectDeliverable { get; set; }
        public long ProjectDeliverableId { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ScheduleActivityDeliverable),nameof(ScheduleActivity),ScheduleActivityId),
                ICacheModel.CreateCacheName(nameof(ScheduleActivityDeliverable),nameof(ProjectDeliverable),ProjectDeliverableId)
            };
        }
    }
}
