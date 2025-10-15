using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Oprim.Domain.Old.Models.Resources
{
    [Index(nameof(CustomAllocationModeId), nameof(Progress), IsUnique = true)]
    public class CustomAllocationModeArticle : ICacheModel
    {
        public CustomAllocationModeArticle(decimal progress, double value)
        {
            Progress = progress;
            Value = value;
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")] public decimal Progress { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")] public double Value { get; set; }

        [Required]
        [ForeignKey("CustomAllocationModeId")] public virtual CustomAllocationMode? CustomAllocationMode { get; set; }
        public int CustomAllocationModeId { get; set; }

        public string[] DefaultCacheNames() => new []{ ICacheModel.CreateCacheName(nameof(CustomAllocationModeArticle), CustomAllocationModeId)};
    }
}
