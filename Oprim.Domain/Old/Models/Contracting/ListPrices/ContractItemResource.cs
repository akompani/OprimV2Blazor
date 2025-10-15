using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractItemResource:ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ItemId")] public ContractItem Item { get; set; }
        public int ItemId { get; set; }

        [ForeignKey("ResourceId")] public Resource Resource { get; set; }
        public int ResourceId { get; set; }

        public decimal Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ContractItemResource), ItemId)};
        }
    }
}
