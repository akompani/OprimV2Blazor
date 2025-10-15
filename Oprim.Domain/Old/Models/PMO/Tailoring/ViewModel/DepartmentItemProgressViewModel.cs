using System.ComponentModel.DataAnnotations.Schema;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Scope;
using Oprim.Domain.Old.Models.PMO.Tailoring.Actual;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class DepartmentItemProgressViewModel
    {
        public ProjectDepartmentItem DepartmentItem { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Actual { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Plan { get; set; }
        public decimal Var { get; set; }
        
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }

        public decimal WeightFactor { get; set; }
        public List<ScheduleActivityActualProgress> Progresses { get; set; }
    }
}
