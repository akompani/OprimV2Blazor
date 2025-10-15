using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectCalendarAvailable : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CalendarId")] public ProjectCalendar Calendar { get; set; }
        public int CalendarId { get; set; }

        public string Start { get; set; }
        public string Finish { get; set; }

        public int AvailablePercentage { get; set; }

        public string[] DefaultCacheNames() => new[]
            { ICacheModel.CreateCacheName(nameof(ProjectCalendarAvailable), CalendarId) };
    }
}
