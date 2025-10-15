using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Risks;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ProjectDashboardModel
    {
        private readonly ScheduleTailoringRoles _tailoringRoles;
        private readonly byte _weekRange;
        private readonly PersianDateTime _dashboardDate;

        public ProjectDashboardModel(string projectName, PersianDateTime date,ScheduleTailoringRoles tailoringRoles = ScheduleTailoringRoles.WorkshopRole, byte weekRange = 4)
        {
            ProjectName = projectName;
            _tailoringRoles = tailoringRoles;
            _weekRange = weekRange;
            _dashboardDate = date.StartOfDay();
        }

        public PersianDateTime Date
        {
            get
            {
                return _dashboardDate;
            }
        }

        public byte WeekRange
        {
            get
            {
                return _weekRange;
            }
        }

        public ScheduleTailoringRoles TailoringRole
        {
            get
            {
                return _tailoringRoles;
            }
        }

        public string ProjectName { get; set; }

        public string PlanFinishDate { get; set; }
        public string RescheduleFinishDate { get; set; }

        public PersianDateTime EarnDate { get; set; }
        public int PlanDelay { get; set; }

        public decimal Spi { get; set; }
        public decimal Cpi { get; set; }


        public List<ScheduleActivityViewModel> ThisWeekActionActivities { get; set; }
        public List<ScheduleActivityViewModel> NextWeekActionActivities { get; set; }
        public string ActionActivitiesHistory { get; set; }
        public string ActionActivitiesCFW { get; set; }

        public List<ProjectThreat> Threats { get; set; }
        public string ThreatsHistory { get; set; }
        public string ThreatsCFW { get; set; }

        public int TotalActivities { get; set; }
        public int TotalCompletedActivities { get; set; }


        public PlanCategoryValue ThisProgress { get; set; }
        public WeekSummaryViewModel ThisWeek { get; set; }
        public WeekSummaryViewModel PrevWeek { get; set; }
        public List<WeekSummaryViewModel> WeekSummaries { get; set; }

        public decimal ActualProgress { get; set; }
        public long ActualCost { get; set; }
        public string ActualCostHistory { get; set; }
        public string ActualCostCFW { get; set; }

        public Dictionary<PersianDateTime, PlanCategoryValue> Progresses { get; set; }

        public Dictionary<ScheduleWbsViewModel, PlanCategoryValue> WbsProgress { get; set; }

        public string[] DirectResources { get; set; }
        public double[] PrevWeekDirectAverageResources { get; set; }
        public double[] ThisWeekDirectAverageResources { get; set; }


        public List<string> OverheadResources { get; set; }
        public Dictionary<string, List<double>> PrevWeekOverheadAverageResources { get; set; }
        public Dictionary<string, List<double>> ThisWeekOverheadAverageResources { get; set; }



    }
}
