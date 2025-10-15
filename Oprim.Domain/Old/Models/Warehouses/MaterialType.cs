using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Warehouses
{
    [Index(nameof(Code), IsUnique = true)]
    public class MaterialType : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(6)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int AlertLagDays { get; set; }

        public string Unit { get; set; }

        [MaxLength(50)]
        public string? UnitName2 { get; set; }

        [MaxLength(50)]
        public string? UnitName3 { get; set; }

        public double MinimumValue { get; set; }

        public double MaximumValue { get; set; }

        public double StepValue { get; set; }

        public double AlertValue { get; set; }

        public List<MaterialTypeSpecification> MaterialTypeSpecifications { get; set; }

        public string FullName
        {
            get
            {
                return $"{Code} - {Name} [ {Unit}" 
                       +(string.IsNullOrEmpty(UnitName2) ? "" : $" - {UnitName2}") 
                       + (string.IsNullOrEmpty(UnitName3) ? "" : $" - {UnitName3}")
                       + " ]";
            }
        }

        public string[] DefaultCacheNames() => new[] { nameof(MaterialType) };
    }
}
