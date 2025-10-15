using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.Warehouses
{
    public class MaterialDeal : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("WarehouseId")] public Warehouse? Warehouse { get; set; }
        public int WarehouseId { get; set; }

        [ForeignKey("MaterialId")] public Material? Material { get; set; }
        public int MaterialId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        [MaxLength(10)]
        public string Date { get; set; }

        public DealModes DealModes { get; set; }

        public double Quantity { get; set; }

        [MaxLength(25)]
        public string PaperNo { get; set; }

        [MaxLength(20)]
        public string TransporterMachineNo { get; set; }

        [MaxLength(100)]
        public string Notes { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(MaterialDeal), nameof(Warehouse), WarehouseId)};
        }
    }
}
