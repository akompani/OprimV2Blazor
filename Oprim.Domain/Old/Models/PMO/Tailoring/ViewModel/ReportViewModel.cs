using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;
using Oprim.Domain.Old.Models.WorkFlow.ViewModel;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class ReportViewModel : Report
    {
        public PersianDateTime PersianDate { get; set; }
        public string MiladyDate { get; set; }
        public List<WorkArticleViewModel> Articles { get; set; }

        public long LastArticleId
        {
            get
            {
                return Articles.Last().Id;
            }
        }
    }
}
