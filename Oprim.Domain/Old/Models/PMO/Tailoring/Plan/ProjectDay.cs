using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Plan
{
    [Index(nameof(ProjectId), nameof(ScheduleId), nameof(Day), IsUnique = true)]
    public class ProjectDay : ICacheModel
    {
        public ProjectDay()
        {

        }

        public ProjectDay(int projectId, ProjectSchedule schedule, ScheduleTailoringRoles scheduleTailoringRole, string start, string date)
        {
            ProjectId = projectId;
            ScheduleId = schedule.Id;
            ScheduleTailoringRole = scheduleTailoringRole;
            Day = (date.ToPersianDateTime() - start.ToPersianDateTime()).Days + 1;
            Date = date;
        }
         public ProjectDay(int projectId, int scheduleId, ScheduleTailoringRoles scheduleTailoringRole, int day, string date)
        {
            ProjectId = projectId;
            ScheduleId = scheduleId;
            ScheduleTailoringRole = scheduleTailoringRole;
            Day = day;
            Date = date;
        }

         public ProjectDay(ProjectDay projectDay,string start,string date,ProjectSchedule schedule)
         {
             ProjectId = projectDay.ProjectId;
             ScheduleId = projectDay.ScheduleId;
             ScheduleTailoringRole = projectDay.ScheduleTailoringRole;

             var startDate = start.ToPersianDateTime();
             var dateObj = date.ToPersianDateTime();

             var finishDate = schedule.FinishDate.ToPersianDateTime();

             Day = (dateObj-startDate).Days +1;
             Date = date;
             Remain = (finishDate - dateObj).Days + 1;

             PP = projectDay.PP;
             PE = projectDay.PE;
             PL = projectDay.PL;
             RL = projectDay.RL;
             RP = projectDay.RP;
             AC = projectDay.AC;

             PlanAllowDays = projectDay.PlanAllowDays;
             PlanUnAllowDays = projectDay.PlanUnAllowDays;
             PlanAllowDelayFactor = projectDay.PlanAllowDelayFactor;
             PlanVariance = projectDay.PlanVariance;
             
             ForecastPlanFinish = projectDay.ForecastPlanFinish;
             ForecastPlanFinishDelay = projectDay.ForecastPlanFinishDelay;
             ForecastReScheduleFinish = projectDay.ForecastReScheduleFinish;
             ForecastReScheduleFinishDelay = projectDay.ForecastReScheduleFinishDelay;
             
             ReScheduleAllowDays = projectDay.ReScheduleAllowDays;
             ReScheduleAllowDelayFactor = projectDay.ReScheduleAllowDelayFactor;
             ReScheduleDelay = projectDay.ReScheduleDelay;
             ReScheduleEarnDay = projectDay.ReScheduleEarnDay;
             ReScheduleEarnDate = projectDay.ReScheduleEarnDate;
             ReScheduleUnAllowDays = projectDay.ReScheduleUnAllowDays;
             ReScheduleVariance = projectDay.ReScheduleVariance;
             
             QcValue = projectDay.QcValue;
             HseValue = projectDay.HseValue;
             
             CostValues = projectDay.CostValues;
             EarnValues = projectDay.EarnValues;
             
             PlanOverheadCost = projectDay.PlanOverheadCost;
             ActualOverheadCost = projectDay.ActualOverheadCost;
            
         }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public ScheduleTailoringRoles ScheduleTailoringRole { get; set; }

        public int Day { get; set; }

        [MaxLength(10)] public string Date { get; set; }

        public int Remain { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PP { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PL { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PE { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal RP { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal RL { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal AC { get; set; }

        //plan
        public string? PlanEarnDate { get; set; }
        public int PlanEarnDay { get; set; }
        public int PlanDelay { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal PlanAllowDays { get; set; }
        public int PlanUnAllowDays { get; set; }
        public decimal PlanVariance { get; set; }
        [DefaultValue(0)]
        [Column(TypeName = "decimal(7,2)")]
        public decimal PlanAllowDelayFactor { get; set; }
        public int ForecastPlanFinishDelay { get; set; }
        public string? ForecastPlanFinish { get; set; }

        //reschedule
        public string? ReScheduleEarnDate { get; set; }
        public int ReScheduleEarnDay { get; set; }
        public int ReScheduleDelay { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal ReScheduleAllowDays { get; set; }
        public int ReScheduleUnAllowDays { get; set; }
        public decimal ReScheduleVariance { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public decimal ReScheduleAllowDelayFactor { get; set; }
        public int ForecastReScheduleFinishDelay { get; set; }
        public string? ForecastReScheduleFinish { get; set; }


        //KPI
        public decimal QcValue { get; set; }
        public decimal HseValue { get; set; }


        //overhead
        public long PlanOverheadCost { get; set; }
        public long ActualOverheadCost { get; set; }


        //plan cost
        public string CostValues { get; set; }

        //earn plan
        public string EarnValues { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(ProjectDay), ProjectId,ScheduleTailoringRole),
                ICacheModel.CreateCacheName(nameof(ProjectDay), ProjectId,ScheduleTailoringRole,Date),
                ICacheModel.CreateCacheName(nameof(ProjectDayViewModel), ProjectId)
            };
        }
    }
}
