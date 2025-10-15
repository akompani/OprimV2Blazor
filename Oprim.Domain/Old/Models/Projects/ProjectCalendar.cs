using System.ComponentModel.DataAnnotations.Schema;
using GeneralServices.Calendars;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectCalendar : PersianCalendar, ICacheModel
    {
        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(ProjectCalendar), ProjectId) };
        }
    }
}
