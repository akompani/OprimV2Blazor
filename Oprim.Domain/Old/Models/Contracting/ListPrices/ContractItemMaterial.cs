using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Warehouses;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractItemMaterial:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ItemId")] public ContractItem Item { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("MaterialTypeId")] public MaterialType MaterialType { get; set; }
        public int MaterialTypeId { get; set; }

        public decimal NetQuantity { get; set; }

        public decimal QuantityFactor { get; set; }

        public decimal Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ContractItemMaterial), ItemId)};
        }
    }
}
