using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class ProjectScheduleViewModel:ProjectSchedule
    {
        public PersianDateTime Apply { get; set; }
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }

    }
}
