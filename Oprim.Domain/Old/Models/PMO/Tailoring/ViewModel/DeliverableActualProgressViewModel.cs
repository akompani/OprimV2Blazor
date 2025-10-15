using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Actual;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class DeliverableActualProgressViewModel:DeliverableActualProgress
    {
        public PersianDateTime PersianDate { get; set; }
    }
}
