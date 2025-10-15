using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class RescheduleActivityViewModel:RescheduleActivity
    {
        public PersianDateTime StartTime { get; set; }
        public PersianDateTime FinishTime { get; set; }
        public PersianDateTime LateStartTime { get; set; }
        public PersianDateTime LateFinishTime { get; set; }
    }
}
