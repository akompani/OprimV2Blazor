using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ProjectSchedule: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public ScheduleTailoringRoles ScheduleTailoringMode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte VersionOrder { get; set; }

        [MaxLength(10)] public string ApplyDate { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string FinishDate { get; set; }


        public int WorkHoursInDay { get; set; }

        public int Duration { get; set; }

        public int MonthDuration { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long MonthFixedCost { get; set; }

        public decimal SafetyStockFactor { get; set; }

        public decimal ManagementStockFactor { get; set; }

        [ForeignKey("DefaultCalendarId")] public ProjectCalendar? DefaultCalendar { get; set; }
        public int DefaultCalendarId { get; set; }

        public bool InActive { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ProjectSchedule),ProjectId),
                ICacheModel.CreateCacheName(nameof(ProjectDashboardModel),ProjectId,ScheduleTailoringRoles.ClientRole)
            };


        }
    }
}
