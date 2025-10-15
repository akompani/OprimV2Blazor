using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using MD.PersianDateTime;
using Microsoft.EntityFrameworkCore;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    [Index(nameof(ScheduleId), nameof(Code), IsUnique = true)]
    public class ScheduleActivity : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule? Schedule { get; set; }
        [Required]
        public int ScheduleId { get; set; }

        public string Name { get; set; }

        public string SimpleName { get; set; }

        [ForeignKey("WbsId")] public ScheduleWbs? Wbs { get; set; }
        public long WbsId { get; set; }

        public ActivityCategories ActivityType { get; set; }

        public bool Planned { get; set; }

        public int IdentityNumber { get; set; }

        [Required]
        public string Code { get; set; }

        [Display(Name = "ردیف")]
        public int Row { get; set; }

        public decimal Quantity { get; set; }

        public bool IsCritical { get; set; }

        public int Priority { get; set; }

        public int Slack { get; set; }

        public int Duration { get; set; }

        [DefaultValue(0)]
        public ActivityConstraintModes ConstraintMode { get; set; }
        public string? ConstraintDate { get; set; }

        public string? Predecessors { get; set; }
        public string? Successors { get; set; }

        [Column(TypeName = "decimal(25,22)")] public decimal WeightFactor { get; set; }

        [Column(TypeName = "decimal(25,22)")] public decimal TimeWeight { get; set; }

        [Column(TypeName = "decimal(25,22)")] public decimal CostWeight { get; set; }

        [Column(TypeName = "decimal(25,22)")] public decimal EarnWeight { get; set; }

        [Column(TypeName = "decimal(25,22)")] public decimal PhysicalWeight { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Earn { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        [ForeignKey("ProjectCalendarId")] public ProjectCalendar? ProjectCalendar { get; set; }
        public int ProjectCalendarId { get; set; }

        [ForeignKey("DepartmentItemId")] public ProjectDepartmentItem? DepartmentItem { get; set; }
        public long DepartmentItemId { get; set; }

        public string? Stakeholders { get; set; }
        public string? Deliverables { get; set; }

        public string OutlineCode { get; set; }
        public byte OutlineLevel { get; set; }

        [Required]
        [MaxLength(20)] public string PlanStartDate { get; set; }

        [Required]
        [MaxLength(20)] public string PlanFinishDate { get; set; }

        [Required]
        [MaxLength(20)] public string EarlyStartDate { get; set; }

        [Required]
        [MaxLength(20)] public string EarlyFinishDate { get; set; }

        [Required]
        [MaxLength(20)] public string LateStartDate { get; set; }

        [Required]
        [MaxLength(20)] public string LateFinishDate { get; set; }

        public string? ActualStart { get; set; }
        public string? ActualFinish { get; set; }
        public int ActualDuration { get; set; }

        public decimal Delay { get; set; }
        public decimal AcceptedDelay { get; set; }
        public decimal UnacceptedDelay { get; set; }


        #region Realationships
        public List<ScheduleActivityResource> ScheduleActivityResources = new List<ScheduleActivityResource>();
        public List<ScheduleActivityEarn> ScheduleActivityEarns = new List<ScheduleActivityEarn>();
        #endregion

        #region Functions
        public string FullName
        {
            get
            {
                return $"{Code} - {Name ?? ""}";
            }
        }

        public string FullNameAndPlanDates
        {
            get
            {
                return $"{FullName} - [ {PlanStartDate} - {PlanFinishDate} ]";
            }
        }


        public decimal DailyWeightFactor
        {
            get
            {
                return WeightFactor / (Duration != 0 ? Duration : 1);
            }
        }

        public decimal DailyProgress
        {
            get
            {
                return Decimal.Round((decimal)1 / (Duration != 0 ? Duration : 1), 2);
            }
        }

        public void CalculateWeightFactor(decimal timeFactor, decimal costFactor, decimal earnFactor, decimal physicalFactor)
        {
            WeightFactor = timeFactor * TimeWeight + costFactor * CostWeight + earnFactor * Earn + physicalFactor * PhysicalWeight;
        }

        public void SetFinish(PersianDateTime start, PersianDateTime finish, Dictionary<int,ProjectCalendarCore> calendarCores)
        {
            var planStart = PlanStartDate.ToPersianDateTime();
            

            if ((start - planStart).Days > 10 & start == finish)
            {
                ActualStart = PlanStartDate;
                start = planStart;
                finish = PlanFinishDate.ToPersianDateTime();
            }

            ActualFinish = finish.ToShortDateString();

            ActualDuration = calendarCores[ProjectCalendarId].DurationDays(start, finish);

            if (Duration == 0 & ActualDuration == 1) ActualDuration = 0;

        }

        public void CalculateDelay(PersianDateTime finish,Dictionary<int,ProjectCalendarCore> calendarCores)
        {
            var planFinish = PlanFinishDate.ToPersianDateTime();

            Delay = 0;
            AcceptedDelay = 0;
            UnacceptedDelay = 0;

            if (planFinish < finish)
            {
                Delay = calendarCores[ProjectCalendarId].DurationDays(planFinish, finish);
                UnacceptedDelay = Delay;
            }

        }

        public void ResetActual()
        {
            ActualStart = null;
            ActualFinish = null;
            ActualDuration = 0;
        }

        #endregion

        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(ScheduleActivity), ScheduleId),
                ICacheModel.CreateCacheName(nameof(ScheduleActivity),nameof(Stakeholder), ScheduleId)
            };
        }

    }
}

