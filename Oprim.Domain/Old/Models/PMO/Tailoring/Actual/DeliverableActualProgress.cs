using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Scope;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    [Index(nameof(ScheduleActivityId), nameof(DeliverableId),nameof(Date), IsUnique = true)]
    public class DeliverableActualProgress : ICacheModel
    {
        public DeliverableActualProgress()
        {
            
        }

        public DeliverableActualProgress(long scheduleActivityId,long deliverableId,string date,decimal progress)
        {
            ScheduleActivityId = scheduleActivityId;
            DeliverableId = deliverableId;
            Progress = progress;
            Date = date;
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("DeliverableId")] public ProjectDeliverable Deliverable { get; set; }
        public long DeliverableId { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        public decimal Progress { get; set; }
        
        public string[] DefaultCacheNames()
        {
            return new []{ICacheModel.CreateCacheName(nameof(DeliverableActualProgress), DeliverableId)};
        }
    }

}
