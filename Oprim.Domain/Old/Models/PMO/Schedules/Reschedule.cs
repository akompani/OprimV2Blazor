using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class Reschedule: ICacheModel
    {
        public Reschedule()
        {
            
        }

        public Reschedule(int projectId, int scheduleId, string date)
        {
            ProjectId = projectId;
            ScheduleId = scheduleId;
            Date = date;
        }

        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int ScheduleId { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(Reschedule), ProjectId)};
        }
    }
}
