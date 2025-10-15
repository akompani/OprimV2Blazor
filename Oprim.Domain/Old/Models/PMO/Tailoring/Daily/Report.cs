using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices;
using GeneralServices.Models.Weather;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.Dcc.DocumentTypes;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Daily
{
    public class Report : ICacheModel
    {
        public void Initialize(WeatherInfo weather, string date = null)
        {
            Date = date ?? PersianDateTime.Now.ToShortDateString();
            Situation = WorkshopSituations.Active;

            //weather
            WeatherCode = weather.WeatherType.Code;
            MaximumTemperature = weather.MaximumTemperature;
            MinimumTemperature = weather.MinimumTemperature;
            Wind = weather.Wind;
            Humidity = weather.Humidity;
        }

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("DocumentBaseId")] public DocumentBase DocumentBase { get; set; }
        public int DocumentBaseId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [MaxLength(20)]
        public string CreateTime { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        [ForeignKey("WorkId")] public Work Work { get; set; }
        public long WorkId { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public int Day { get; set; }

        public string DayOfWeek { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PlanProgress { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal ReScheduleProgress { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal ActualProgress { get; set; }

        public int PlanDelayDay { get; set; }

        public int ReScheduleDelayDay { get; set; }

        public int PlanTotalDays { get; set; }

        public int PlanDuration { get; set; }

        public int RemainDays { get; set; }

        public WorkshopSituations Situation { get; set; }

        [ForeignKey("ManagerId")] public Stakeholder Manager { get; set; }
        public int ManagerId { get; set; }

        [ForeignKey("WeatherCode")] public WeatherType WeatherType { get; set; }
        public int WeatherCode { get; set; }

        public string? Atmospheric { get; set; }

        public decimal MinimumTemperature { get; set; }

        public decimal MaximumTemperature { get; set; }

        public decimal Wind { get; set; }

        public decimal Humidity { get; set; }

        public string? Notes { get; set; }

        public bool Lock { get; set; }

        public DataEntrySituations ReportActivitiesSituation { get; set; }

        public DataEntrySituations HumanSituation { get; set; }

        public override string ToString()
        {
            return $"Day {Day} : {Date}";
        }

        public void RefreshInfo(ProjectDayViewModel projectDay, string projectFinishDate)
        {
            var thisDate = PersianDateTime.Parse(Date);
            Day = projectDay.Day;
            DayOfWeek = thisDate.PersianDayOfWeek.GetPersianDayOfWeek();
            Name = "ProjectReport-" + thisDate.ToShortDateString();

            var finishDate = PersianDateTime.Parse(projectFinishDate);

            ActualProgress = projectDay.AC;
            ReScheduleProgress = projectDay.RP;
            PlanProgress = projectDay.PP;

            RemainDays = Math.Max(0, (finishDate - thisDate).Days);
            PlanTotalDays = RemainDays + Day;

            PlanDelayDay = Math.Max(Day - projectDay.PlanEarnDay, 0);
            ReScheduleDelayDay = Math.Max(Day - projectDay.ReScheduleEarnDay, 0);
        }

        public string Fullname
        {
            get { return $"{Code} - {Name}"; }
        }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(Report), ProjectId),
                ICacheModel.CreateCacheName(nameof(ReportViewModel), ProjectId),
            };
        }

    }
}
