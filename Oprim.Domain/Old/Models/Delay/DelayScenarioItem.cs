using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Delay
{
    public class DelayScenarioItem : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScenarioId")] public DelayScenario Scenario { get; set; }
        public int ScenarioId { get; set; }

        [ForeignKey("DelayItemId")] public DelayItem DelayItem { get; set; }
        public long DelayItemId { get; set; }

        public bool Active { get; set; }

        //public bool OverrideDates { get; set; }

        //[MaxLength(10)]
        //public string OverrideStartDate { get; set; }
        
        //[MaxLength(10)]
        //public string OverrideFinishDate { get; set; }
        
        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(DelayScenarioItem), ScenarioId) };
        }
    }
}
