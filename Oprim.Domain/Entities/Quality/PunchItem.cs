using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Common;
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
        [ForeignKey("DepartmentId")] public ProjectDepartmentItem DepartmentItem { get; set; }
        public long DepartmentItemId { get; set; }
        
        [ForeignKey("ProjectItemId")] public ProjectItem ProjectItem { get; set; }
        public long ProjectItemId { get; set; }

        public string Notes { get; set; } 
        public string OpponentLinks { get; set; }

    }
}
