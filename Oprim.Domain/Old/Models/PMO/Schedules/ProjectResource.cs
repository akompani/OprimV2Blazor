using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ProjectResource: ICacheModel
    {
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }
        
        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        [ForeignKey("ProjectCalendarId")] public ProjectCalendar? ProjectCalendar { get; set; }
        public int ProjectCalendarId { get; set; }

        public string StartDate { get; set; }

        public string? FinishDate { get; set; }

        public double Maximum { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public double StandardPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public double OvertimePrice { get; set; }

        public double UseInCalendarEveryDay { get; set; }
        
        public bool UseCalendarTimeAtLeastOneHourUse { get; set; }
        
        public bool Overhead { get; set; }

        public string FullName
        {
            get
            {
                return Resource?.FullName ?? "";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectResource), ProjectId)};
        }
    }
}
