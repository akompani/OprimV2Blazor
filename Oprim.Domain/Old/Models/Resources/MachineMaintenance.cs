using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Resources
{
    public class MachineMaintenance: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("MachineId")] public Resource? Machine { get; set; }
        public int MachineId { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EstimateCost { get; set; }

        public string StartDate { get; set; }

        public string FinishDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ActualCost { get; set; }

        public string Notes { get; set; }

        public string[] DefaultCacheNames()
        {
            return new[] { ICacheModel.CreateCacheName(nameof(MachineMaintenance), ProjectId) };
        }
    }
}
