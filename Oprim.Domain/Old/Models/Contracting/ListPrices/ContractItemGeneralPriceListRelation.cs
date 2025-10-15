using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractItemGeneralPriceListRelation : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ItemId")] public ContractItem ContractItem { get; set; }
        public int ItemId { get; set; }



        public short FieldCode { get; set; }

        [MaxLength(12)]
        public string ItemCode { get; set; }

        public double Factor { get; set; }
        public string[] DefaultCacheNames()
        {
            return new[]
            {
                ICacheModel.CreateCacheName(nameof(ContractItemGeneralPriceListRelation), ItemId)
            };
        }
    }
}
