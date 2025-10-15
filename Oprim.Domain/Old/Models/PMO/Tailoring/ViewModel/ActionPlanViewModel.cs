using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ActionPlanViewModel
    {
        public string FinishDate { get; set; }
        public string RescheduleFinishDate { get; set; }

        public Dictionary<string, List<ScheduleActivityViewModel>> Activities { get; set; } =
            new Dictionary<string, List<ScheduleActivityViewModel>>();

        public Dictionary<string, decimal> PeriodProgresses { get; set; } = new Dictionary<string, decimal>();

        public Dictionary<string, List<ProjectItem>> Items { get; set; } = new Dictionary<string, List<ProjectItem>>();

        public Dictionary<string, PlanCategoryValue> CurveProgresses { get; set; }

    }
}
