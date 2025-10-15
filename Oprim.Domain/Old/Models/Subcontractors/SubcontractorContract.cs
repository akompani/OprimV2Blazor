using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorContract : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("SubcontractorId")] public Subcontractor Subcontractor { get; set; }
        public int SubcontractorId { get; set; }

        [MaxLength(10)]
        public string? StartDate { get; set; }

        [MaxLength(10)]
        public string? FinishDate { get; set; }

        [Column(TypeName = "decimal(10,8)")]
        public decimal OverheadFactor { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Amount { get; set; }

        public string FullName
        {
            get { return Name + (Subcontractor != null ? ("[" + Subcontractor.Name + "]") : "") + $"({Code})"; }
        }

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(SubcontractorContract),ProjectId) };
    }
}
