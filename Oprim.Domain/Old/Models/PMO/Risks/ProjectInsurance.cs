using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Risks
{
    public class ProjectInsurance: ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectThreatId")] public ProjectThreat ProjectThreat { get; set; }
        public long ProjectThreatId { get; set; }
        
        [Required]
        public  InsuranceTypes Type { get; set; }

        [Required]
        [MaxLength(25)]
        public string StartDate { get; set; }

        [Required]
        [MaxLength(25)]
        public string FinishDate { get; set; }

        [MaxLength(25)]
        public string IssueDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Issuer { get; set; }

        public long Cost { get; set; }

        public string Name { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectInsurance), ProjectId)};
        }
    }
}
