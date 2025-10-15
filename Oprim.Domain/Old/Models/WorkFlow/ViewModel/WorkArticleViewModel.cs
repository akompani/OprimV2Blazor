using MD.PersianDateTime;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.WorkFlow.ViewModel
{
    public class WorkArticleViewModel : WorkArticle
    {
        public PersianDateTime PlanStartTime { get; set; }
        public PersianDateTime PlanFinishTime { get; set; }

        public PersianDateTime ActualFinishTime { get; set; }

        public int RemainDays { get; set; }

        public bool EditAccess { get; set; }

        public string DifferTime()
        {
            if (string.IsNullOrEmpty(ActualFinish))
            {
                return "";
            }
            else
            {
                var af = PersianDateTime.Parse(ActualFinish);

                var td = PersianDateTime.Now;

                if (td.ToShortDateInt() == af.ToShortDateInt())
                {
                    return $"{(td - af).Hours} hoursago";
                }
                else
                {
                    return $"{(td - af).Days} daysago";
                }
            }
        }

    }
}
