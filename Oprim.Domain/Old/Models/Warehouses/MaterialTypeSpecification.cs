using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.Warehouses
{
    public class MaterialTypeSpecification: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("MaterialTypeId")] public MaterialType? MaterialType { get; set; }
        public int MaterialTypeId { get; set; }

        public string Name { get; set; }

        public SpecificationTypes Type { get; set; }

        public string[] DefaultCacheNames()
        {
            return new string[]
            {
                ICacheModel.CreateCacheName(nameof(MaterialTypeSpecification), MaterialTypeId),
                nameof(MaterialType)
        };
        }
    }
}
