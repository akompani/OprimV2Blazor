using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;
using Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class ProjectActivityOnDateViewModel
    {
        public ProjectActivityOnDateViewModel()
        {
            Previous = new ProjectDayTailorViewModel();
            ThisDay = new ProjectDayTailorViewModel();
        }

        public ScheduleActivity ScheduleActivity { get; set; }

        public bool Planned { get; set; }

        public ProjectDayTailorViewModel Previous { get; set; }

        public ProjectDayTailorViewModel ThisDay { get; set; }

        public void CalculateThisDay(PersianDateTime date, Dictionary<int, ProjectCalendarCore> calendarDictionary, ScheduleActivityViewModel scheduleActivity)
        {
            Previous.Progresses.AddValue(ThisDay.Progresses);
            Previous.Costs.AddValue(ThisDay.Costs);
            Previous.Earns.AddValue(ThisDay.Earns);

            Previous.ActivityResources.AddList(ThisDay.ActivityResources);

            foreach (var key in Previous.Progresses.Keys)
            {
                ThisDay.Progresses[key] =
                    calendarDictionary[scheduleActivity.ProjectCalendarId].Progress(date, scheduleActivity.Starts[key], scheduleActivity.Finishes[key]);

                ThisDay.ActivityResources[key] = new List<ProjectDayResource>();

                if (ThisDay.Progresses[key] > 0)
                {
                    foreach (var resource in scheduleActivity.ScheduleActivityResources)
                    {
                        var allocate = resource.Allocate(Previous.Progresses[key], ThisDay.Progresses[key], date, calendarDictionary);

                        if (allocate != null)
                        {
                            ThisDay.ActivityResources[key].Add(allocate);
                        }
                    }

                    foreach (var earn in scheduleActivity.ScheduleActivityEarns)
                    {
                        var earnAllocate = earn.Allocate(Previous.Progresses[key], ThisDay.Progresses[key]);

                        ThisDay.Earns[key] += earnAllocate;
                    }
                }

                ThisDay.Costs[key] = ThisDay.ActivityResources[key].Sum(a => a.Amount);

            }
        }

    }
}
