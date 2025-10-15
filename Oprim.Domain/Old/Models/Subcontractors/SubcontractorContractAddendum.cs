using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Subcontractors
{
    public class SubcontractorContractAddendum : ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ContractId")] public SubcontractorContract? Contract { get; set; }
        public int ContractId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [MaxLength(10)]
        public string StartDate { get; set; }

        [MaxLength(10)]
        public string FinishDate { get; set; }

        public long DifferAmount { get; set; }

        public string? Notes { get; set; }

        public string FullName
        {
            get
            {
                return $"{Code} - {Name}";
            }
        }

        public string[] DefaultCacheNames()=> new []{ ICacheModel.CreateCacheName(nameof(SubcontractorContractAddendum), ContractId)};
    }
}
