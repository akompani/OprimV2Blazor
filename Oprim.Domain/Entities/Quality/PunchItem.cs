using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Projects;


namespace Oprim.Domain.Entities.Quality
{
    public class PunchItem : BaseEntity
    {

        [ForeignKey("ProjectId")] public Project Project { get; set; }
        public int ProjectId { get; set; }
        //
        // [ForeignKey("WbsId")] public ProjectWbs ProjectWbs { get; set; }
        // public long WbsId { get; set; }
        //
        // [ForeignKey("DepartmentId")] public ProjectDepartmentItem DepartmentItem { get; set; }
        // public int DepartmentItemId { get; set; }
        //
        // [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        // public int ProjectItemId { get; set; }

        public string Notes { get; set; }

        public string CreateTime { get; set; }

        // [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        // public int CreatorId { get; set; }

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
