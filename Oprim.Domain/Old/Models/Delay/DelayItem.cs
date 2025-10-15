using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO;
using Oprim.Domain.Old.Models.PMO.Schedules;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayItem : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleId")] public ProjectSchedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }

        public bool All { get; set; }

        public string ScheduleActivityLinks { get; set; }

        public string WbsLinks { get; set; }

        public string DepartmentLinks { get; set; }

        public DelayCategories DelayCategory { get; set; }

        public string Notes { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} [ {StartDate} - {FinishDate} ]";
            }
        }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DelayItem), ScheduleId) };
        }
    }
}
