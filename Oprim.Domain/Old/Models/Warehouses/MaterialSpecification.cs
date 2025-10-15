using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oprim.Domain.Old.Models.Warehouses
{
    public class MaterialSpecification : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("MaterialId")] public Material? Material { get; set; }
        public int MaterialId { get; set; }

        [ForeignKey("MaterialTypeSpecificationId")] public MaterialTypeSpecification? MaterialTypeSpecification { get; set; }
        public long MaterialTypeSpecificationId { get; set; }

        public string Value { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(MaterialTypeSpecification), MaterialId)};
        }
    }
}
