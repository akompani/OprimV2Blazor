using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public enum ErrorType : byte
    {
        None = 0,
        ThreatRequired = 1,
        ResourceRequired = 2,
    }

    public class ReportActivityViewModel : ReportActivity
    {
        public Dictionary<TailorModes, int> Delays { get; set; } = new Dictionary<TailorModes, int>();

        public List<ErrorType> Errors { get; set; } = new List<ErrorType>();

        public bool NoEnoughProgress { get; set; }
        public bool PredecessorNotCompleted { get; set; }

        public List<ReportActivityResource> Resources = new List<ReportActivityResource>();

        public List<ReportActivityThreat> Threates = new List<ReportActivityThreat>();

        public List<(int id,string name)> ScheduleActivityStakeholderList { get; set; } = new List<(int id,string name)>();

        public void CalculateDelay(PersianDateTime thisDate, Dictionary<int, ProjectCalendarCore> calendarCores, ScheduleActivityViewModel actView)
        {
            Delays = new Dictionary<TailorModes, int>();

            foreach (TailorModes value in Enum.GetValues(typeof(TailorModes)))
            {
                if (value != TailorModes.Actual)
                {
                    var tDate = calendarCores[actView.ProjectCalendarId].EarnDate(CumProgress, actView.Starts[value], actView.Finishes[value]);

                    Delays.Add(value, Math.Max(0, (int)(thisDate - tDate).TotalDays));
                }
            }

            CheckError();
        }

        public void CheckError()
        {
            Errors = new List<ErrorType>();
            PredecessorNotCompleted = false;
            NoEnoughProgress = false;

            if (DailyProgress == 0)
            {
                if (ReportActivityType == ReportActivityTypes.ActionPlan & Threates.Count == 0)
                {
                    Errors.Add(ErrorType.ThreatRequired);
                }
            }
            else
            {
                if (DailyProgress < ScheduleActivity.DailyProgress * 100)
                {
                    NoEnoughProgress = true;
                }

                if (Resources.Count == 0)
                {
                    Errors.Add(ErrorType.ResourceRequired);
                }
            }

        }
    }
}
