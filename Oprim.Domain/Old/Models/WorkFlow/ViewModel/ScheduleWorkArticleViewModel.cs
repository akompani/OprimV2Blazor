using MD.PersianDateTime;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.WorkFlow.ViewModel
{
    public class ScheduleWorkArticleViewModel:ScheduleWorkArticle
    {
        public PersianDateTime ScheduleDateTime { get; set; }
        public PersianDateTime DocumentDateTime { get; set; }
    }
}
