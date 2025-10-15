using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class RescheduleActivity
    {
        [Key]
        public long Id { get; set; }

        public int RescheduleId { get; set; }

        public long ScheduleActivityId { get; set; }

        [MaxLength(25)]
        public string Start { get; set; }

        [MaxLength(25)]
        public string Finish { get; set; }

        [MaxLength(25)]
        public string LateStart { get; set; }

        [MaxLength(25)]
        public string LateFinish { get; set; }

        public int Slack { get; set; }

        public bool IsCritical { get; set; }


        public void Clone(RescheduleActivity ra)
        {
            Start = ra.Start;
            Finish = ra.Finish;

            LateStart = ra.LateStart;
            LateFinish = ra.LateFinish;

            Slack = ra.Slack;
            IsCritical = ra.IsCritical;
        }

    }
}
