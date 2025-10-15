using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Organization.Stakeholders
{
    public class ProjectStakeholder: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("StakeholderId")] public Stakeholder? Stakeholder { get; set; }
        public int StakeholderId { get; set; }

        public StakeholderSituations CurrentSituation { get; set; }

        public StakeholderSituations ExpectedSituation { get; set; }

        public StakeholderSituations TargetSituation { get; set; }

        [Range(1,10)]
        public byte PowerScore { get; set; }

        [Range(1,10)]
        public byte InterestScore { get; set; }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ProjectStakeholder), ProjectId)};
        }
    }
}
