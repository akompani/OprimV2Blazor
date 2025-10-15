using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Organization.Roles;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.WorkFlow.WorkBases
{
    public class WorkBaseArticle : ICacheModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ProjectId")] public Project? Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("WorkBaseId")] public WorkBase? WorkBase { get; set; }
        public int WorkBaseId { get; set; }

        [ForeignKey("RoleId")] public OrganizationRole? Role { get; set; }
        public int RoleId { get; set; }

        public byte Order { get; set; }

        public int FixTime { get; set; }

        public int FitOnBaseTimeDurationIndex { get; set; }

        public decimal Weight { get; set; }

        public ArticleActions ArticleAction { get; set; }

        public bool SendNotificationOnCreate { get; set; }

        public int DurationBySituation(bool critical, bool important)
        {
            return FixTime + (int)Math.Floor(WorkFlowGeneralFunctions.GetFactor(critical, important) * FitOnBaseTimeDurationIndex);
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(WorkBaseArticle), WorkBaseId)};
        }
    }
}
