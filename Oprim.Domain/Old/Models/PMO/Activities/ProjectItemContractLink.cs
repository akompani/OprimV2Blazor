using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;

namespace Oprim.Domain.Old.Models.PMO.Activities
{
    public class ProjectItemContractLink: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem? ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        [ForeignKey("ContractItemId")] public ContractItem? ContractItem { get; set; }
        public int ContractItemId { get; set; }

        public double Factor { get; set; }

        [MaxLength(100)]
        public string? Notes { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectItemContractLink), ProjectItemId)};
        }
    }
}
