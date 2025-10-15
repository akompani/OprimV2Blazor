using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Contracting.ListPrices
{
    public class ContractFactor:ICacheModel
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public ItemFactorTypes FactorType { get; set; }

        public bool ApplyOnBase { get; set; }
        
        public bool ApplyOnStar { get; set; }

        public bool ApplyOnFactorial { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(ContractFactor), ProjectId),
                ICacheModel.CreateCacheName(nameof(ContractFactor), ProjectId, ItemTypes.Fehrest),
                ICacheModel.CreateCacheName(nameof(ContractFactor), ProjectId, ItemTypes.Star),
                ICacheModel.CreateCacheName(nameof(ContractFactor), ProjectId, ItemTypes.NewItem),
                ICacheModel.CreateCacheName(nameof(ContractFactor), ProjectId, ItemTypes.Factori)
            };
        }
    }
}
