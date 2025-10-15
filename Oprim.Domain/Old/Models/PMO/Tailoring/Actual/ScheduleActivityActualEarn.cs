using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    public class ScheduleActivityActualEarn: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public int Day { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("ProjectItemId")] public ContractItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public bool ManualEntry { get; set; }

        public string CreateDate { get; set; }

        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ScheduleActivityActualEarn), ScheduleActivityId)};
        }
    }
}
