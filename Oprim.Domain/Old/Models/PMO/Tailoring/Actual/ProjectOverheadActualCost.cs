using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Cost;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.Actual
{
    public class ProjectOverheadActualCost: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public int Day { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("ProjectCbsId")] public ProjectCbs? ProjectCbs { get; set; }
        public int ProjectCbsId { get; set; }

        public bool ManualEntry { get; set; }

        public string CreateDate { get; set; }

        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectOverheadActualCost),
                Date ?? PersianDateTime.Now.ToShortDateString())};
        }
    }
}
