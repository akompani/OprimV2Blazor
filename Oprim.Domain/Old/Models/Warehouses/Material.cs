using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Warehouses
{
    [Index(nameof(Code), IsUnique = true)]
    public class Material : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MaterialTypeId")] public MaterialType MaterialType { get; set; }
        public int MaterialTypeId { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        public string Name { get; set; }

        public double UnitFactor2 { get; set; }

        public double UnitFactor3 { get; set; }

        public double MinimumValue { get; set; }

        public double MaximumValue { get; set; }

        public double StepValue { get; set; }

        public double AlertValue { get; set; }

        public List<MaterialSpecification> Specifications { get; set; } = new List<MaterialSpecification>();


        public string FullName
        {
            get
            {
                var strSpecifications = "";

                foreach (var ms in Specifications)
                {
                    strSpecifications += (strSpecifications.Length > 0 ? " , " : "") +
                                         $"{ms.MaterialTypeSpecification.Name}:{ms.Value}";
                }

                return $"{MaterialType?.Name ?? ""} [ {MaterialType?.Unit ?? ""} ] : {strSpecifications}";
            }
        }

        public string[] DefaultCacheNames() => new[] { nameof(Material) };
    }
}
