using GeneralServices.Calendars;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectCalendarHoliday : PersianCalendarHoliday, ICacheModel
    {
        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(ProjectCalendarHoliday), CalendarId) };
    }
}
