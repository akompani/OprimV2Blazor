using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Old.Models.Organization.Stakeholders;
using Oprim.Domain.Old.Models.PMO.Activities;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.Quality
{
    public class PunchItem : BaseEntity
    {
        public long Id { get; set; }

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("WbsId")] public ProjectWbs ProjectWbs { get; set; }
        public long WbsId { get; set; }

        [ForeignKey("DepartmentId")] public ProjectDepartmentItem DepartmentItem { get; set; }
        public int DepartmentItemId { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public string Notes { get; set; }

        public string CreateTime { get; set; }

        [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        public int CreatorId { get; set; }

        public string OpponentLinks { get; set; }

        // public string[] DefaultCacheNames()
        // {
        //     return new []
        //     {
        //         ICacheModel.CreateCacheName(nameof(PunchItem), ProjectId)
        //     };
        // }
    }
}
