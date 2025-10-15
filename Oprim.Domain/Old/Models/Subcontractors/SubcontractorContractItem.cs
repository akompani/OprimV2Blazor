using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorContractItem : ICacheModel
    {

        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ContractId")] public SubcontractorContract Contract { get; set; }
        public int ContractId { get; set; }

        [ForeignKey("AddendumId")] public SubcontractorContractAddendum Addendum { get; set; }
        public long? AddendumId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        [Required]
        [MaxLength(20)]
        public string UnitName { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long Price { get; set; }

        public decimal EstimateQuantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EstimateAmount { get; set; }
        public string? Notes { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} ({Code})";
            }
        }

        public string[] DefaultCacheNames() => new[] { ICacheModel.CreateCacheName(nameof(SubcontractorContractItem), ContractId) };
    }
}
