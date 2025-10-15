using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Cost;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Activities
{
    public class ProjectItem : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectCbsId")] public ProjectCbs? ProjectCbs { get; set; }
        public int ProjectCbsId { get; set; }

        [MaxLength(20)]
        public string Code { get; set; }

        public string Name { get; set; }

        public int EngineeringLead { get; set; }

        public int ProcurementLead { get; set; }

        public string? Unit { get; set; }

        public double QuantityForOneHour { get; set; }

        public double EstimateQuantity { get; set; }

        public double TotalQuantity { get; set; }

        public double EstimateUnitCost { get; set; }

        public double EstimateCost { get; set; }

        public double TotalCost { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectItem), ProjectId)};
        }
    }
}
