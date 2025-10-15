using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    [Index(nameof(ScheduleActivityId), nameof(Date), IsUnique = true)]
    public class ScheduleActivityActualProgress : ICacheModel
    {
        public ScheduleActivityActualProgress()
        {
            
        }

        public ScheduleActivityActualProgress(int projectId, int date, long scheduleActivityId, decimal progress, decimal weightFactor)
        {
            ProjectId = projectId;
            Date = date;
            ScheduleActivityId = scheduleActivityId;
            Progress = progress;
            WeightFactor = weightFactor;
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public int Date { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [Column(TypeName = "decimal(5,4)")] public decimal Progress { get; set; }

        [Column(TypeName = "decimal(25,22)")]
        public decimal WeightFactor { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []
            {
                ICacheModel.CreateCacheName(nameof(ScheduleActivityActualProgress), ProjectId, Date),
                ICacheModel.CreateCacheName(nameof(ProjectDashboardModel), ProjectId),
                ICacheModel.CreateCacheName(Date),
            };
        }

    }
}
