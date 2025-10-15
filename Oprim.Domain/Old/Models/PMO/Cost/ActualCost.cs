using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Cost
{
    public class ActualCost
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectCbsId")] public ProjectCbs? ProjectCbs { get; set; }
        public int ProjectCbsId { get; set; }

        [ForeignKey("ResourceId")] public Resource? Resource { get; set; }
        public int ResourceId { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public long NetAmount { get; set; }

        public double TransportAmount { get; set; }

        public double TotalAmount { get; set; }
    }
}
