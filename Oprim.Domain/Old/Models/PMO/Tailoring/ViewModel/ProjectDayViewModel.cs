using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ProjectDayViewModel : ProjectDay
    {
        public PersianDateTime PersianDate { get; set; }
        
        public PlanCategoryValue Cost { get; set; }
        public PlanCategoryValue Earn { get; set; }

        public override string ToString()
        {
            
            return $"{ScheduleId} - {Date} [PP:{PP}] [PE:{PE}] " +
                   $"[PL:{PL}] [RP:{RP}] [AC:{AC}] ";
        }
    }
}
