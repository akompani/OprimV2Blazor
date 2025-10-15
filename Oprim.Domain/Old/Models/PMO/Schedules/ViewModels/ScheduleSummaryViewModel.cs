using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Plan;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class ScheduleSummaryViewModel : ProjectDay
    {
        public PersianDateTime Date { get; set; }
        public string Name { get; set; }

        public decimal CF_Show { get; set; }
        public decimal CCF_Show { get; set; }

        public decimal AC_Show { get; set; }
        public decimal CAC_Show { get; set; }


    }
}
