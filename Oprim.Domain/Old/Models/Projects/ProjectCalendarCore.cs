using GeneralServices.Calendars;
using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectCalendarCore : PersianCalendarCore
    {
        private readonly PersianCalendarDistribution _calendarDistribution;

        public ProjectCalendarCore(PersianCalendarDistribution calendarDistribution) : base(calendarDistribution)
        {
            _calendarDistribution = calendarDistribution;
            calendarDistribution.Initialize();
        }

        public PersianDateTime AddDays(PersianDateTime date, int days, int scheduleDayHours)
        {
            return AddHours(date, days * scheduleDayHours);
        }

        public double DayDurationByHour(PersianDateTime date)
        {
            return (double) _calendarDistribution[date].Duration / 60;
        }
    }
}
