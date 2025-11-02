using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
using Oprim.Domain.Common.Utilities;
using Oprim.Domain.Entities.Organization;
using Oprim.Domain.Entities.PMO;
using Oprim.Domain.Entities.Scope;

namespace Oprim.Domain.Entities.Quality
{
    public class PunchItem : BaseProjectEntity
    {
        //
        // [ForeignKey("WbsId")] public ProjectWbs ProjectWbs { get; set; }
        // public long WbsId { get; set; }
        //
        [ForeignKey("DepartmentItemId")] public ProjectDepartmentItem DepartmentItem { get; set; } = default!;
        public long? DepartmentItemId { get; set; }

        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; } = default!;
        public long? ProjectItemId { get; set; }

        public string Notes { get; set; }

        public DateTime CreateTime { get; set; }
        [NotMapped] public string CreatePersianTime => CreateTime.ToPersianTime();


        /// <summary>
        /// Creator id می تواند برای همه entity ها باشه
        /// </summary>
        // [ForeignKey("CreatorId")] public Stakeholder Creator { get; set; }
        // public long CreatorId { get; set; }

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