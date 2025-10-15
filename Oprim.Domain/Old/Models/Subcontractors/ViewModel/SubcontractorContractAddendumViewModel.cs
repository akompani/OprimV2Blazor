using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Subcontractors.ViewModel
{
    public class SubcontractorContractAddendumViewModel:SubcontractorContractAddendum
    {
        public PersianDateTime Start { get; set; }
        public PersianDateTime Finish { get; set; }
    }
}
