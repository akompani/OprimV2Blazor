using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public static class ProjectDaysToolFunctions
    {
        public static ProjectDayViewModel EarnDay(this List<ProjectDayViewModel> projectDays, decimal actual,
            int scheduleId)
        {
            return projectDays.LastOrDefault(p => p.PP <= actual & p.ScheduleId == scheduleId) ?? projectDays.First();
        }
        public static ProjectDayViewModel EarnDay(this List<ProjectDayViewModel> projectDays, ProjectDayViewModel actualDay)
        {
            return projectDays.LastOrDefault(p => p.PP <= actualDay.AC & p.ScheduleId == actualDay.ScheduleId) ?? projectDays.First();
        }
        
        public static ProjectDayViewModel EarnDay(this List<ProjectDayViewModel> projectDays, ProjectDay actualDay)
        {
            return projectDays.LastOrDefault(p => p.PP <= actualDay.AC & p.ScheduleId == actualDay.ScheduleId) ?? projectDays.First();
        }
    }

    public class ProjectDaysTool
    {
        private readonly Dictionary<string, ProjectDayViewModel> _projectDays;
        private readonly List<ProjectDayViewModel> _projectDaysList;

        public ProjectDaysTool(Dictionary<string,ProjectDayViewModel> projectDays)
        {
            _projectDays = projectDays;
            _projectDaysList = projectDays.Values.ToList();
        }

        public ProjectDayViewModel this[PersianDateTime date] => this[date.ToShortDateString()];

        public ProjectDayViewModel this[string date]
        {
            get
            {
                if (_projectDays.ContainsKey(date)) return _projectDays[date];

                var tDate = date.ToPersianDateTime();
                
                var first = _projectDays.First().Key.ToPersianDateTime();
                if (tDate.ToShortDateInt() < first.ToShortDateInt()) return _projectDays.First().Value;

                var last = _projectDays.Last().Key.ToPersianDateTime();
                if (tDate.ToShortDateInt() > last.ToShortDateInt()) return _projectDays.Last().Value;

                throw new Exception("ErrorInProjectDayFound");
            }
        }

        public List<ProjectDayViewModel> List => _projectDaysList;

        public int Count
        {
            get
            {
                return _projectDays.Count;
            }
        }

        public ProjectDayViewModel FirstDay
        {
            get
            {
                return _projectDays.First().Value;
            }
        } 
        public ProjectDayViewModel LastDay
        {

            get
            {
                return _projectDays.Last().Value;
            }
        }

        public ProjectDayViewModel EarnDay(decimal actual)
        {
            return _projectDaysList.LastOrDefault(p => p.PP <= actual) ?? FirstDay;
        }

        public PersianDateTime EarnDate(decimal actual)
        {
            return EarnDay(actual).PersianDate;
        }

        public int PlanDelay(decimal actual, string date = null)
        {
            return PlanDelay(actual,date.ToPersianDateTime());
        }

        public int PlanDelay(decimal actual, PersianDateTime date)
        {
            var earnDate = EarnDate(actual);

            return (date - earnDate).Days;
        }
    }
}
