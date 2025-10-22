using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Entities.PMO;

namespace Oprim.Domain.Entities.Quality
{
    public class PunchItem : BaseProjectEntity
    {
        
        //
        // [ForeignKey("WbsId")] public ProjectWbs ProjectWbs { get; set; }
        // public long WbsId { get; set; }
        //
        // [ForeignKey("DepartmentId")] public ProjectDepartmentItem DepartmentItem { get; set; }
        // public int DepartmentItemId { get; set; }
        //
        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        public int ProjectItemId { get; set; }

        public string Notes { get; set; }

        public string CreateTime { get; set; }

        
        /// <summary>
        /// Creator id می تواند برای همه entity ها باشه
        /// </summary>
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
