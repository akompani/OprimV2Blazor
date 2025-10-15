using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Subcontractors.ViewModel
{
    public class SubcontractorContractViewModel:SubcontractorContract
    {
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }
    }
}
