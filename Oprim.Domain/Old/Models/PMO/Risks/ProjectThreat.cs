using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Roles;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Risks
{
    public class ProjectThreat: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("RiskTypeId")] public RiskType RiskType { get; set; }
        public int RiskTypeId { get; set; }

        public RiskResponseTypes RiskResponse { get; set; }

        public string Name { get; set; }

        [ForeignKey("OwnerRoleId")] public OrganizationRole OwnerRole { get; set; }
        public int OwnerRoleId { get; set; }

        [ForeignKey("AuditorRoleId")] public OrganizationRole AuditorRole { get; set; }
        public int AuditorRoleId { get; set; }

        [ForeignKey("RefereeRoleId")] public OrganizationRole RefereeRole { get; set; }
        public int RefereeRoleId { get; set; }

        public string ProbabilityStartDate { get; set; }

        public string ProbabilityFinishDate { get; set; }

        public decimal Probability { get; set; }
        public RiskImpactTypes Impact { get; set; }

        public DelayCategories DelayCategory { get; set; }

        public int EstimateWasteTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long EstimateDamageAmount { get; set; }

        public string? PlanStartDate { get; set; }
        public string? PlanFinishDate { get; set; }

        public string? Notes { get; set; }

        public bool AcceptableDelay { get; set; }

        public int ActualWasteTime { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:#,##0}")]
        public long ActualDamageAmount { get; set; }
        
        public string? ActualStartDate { get; set; }

        public string? ActualFinishDate { get; set; }

        public bool OwnerFinalized { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectThreat), ProjectId)};
        }
    }
}
