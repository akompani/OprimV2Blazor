using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.WorkFlow.ViewModel
{
    public class WorkViewModel:Work
    {
        public PersianDateTime PlanStartDateTime { get; set; }
        public PersianDateTime PlanFinishDateTime { get; set; }
        public PersianDateTime ActualStartDateTime { get; set; }
        public PersianDateTime ActualFinishDateTime { get; set; }

        public List<WorkArticleViewModel> Articles = new List<WorkArticleViewModel>();


        public string PlanStartDate { get; set; }
        public string PlanStartTime { get; set; }

        public string PlanFinishDate { get; set; }
        public string PlanFinishTime { get; set; }

        public void SetDateTimeStrings()
        {
            if (PlanStartDateTime != null)
            {
                PlanStartDate = PlanStartDateTime.ToShortDateString();
                PlanStartTime = PlanStartDateTime.ToString("HH:mm");
            }

            if (PlanFinishDateTime != null)
            {
                PlanFinishDate = PlanFinishDateTime.ToShortDateString();
                PlanFinishTime = PlanFinishDateTime.ToString("HH:mm");
            }
        }

        public void GetDateTimeFromString()
        {
            var sD = PersianDateTime.Parse(PlanStartDate);
            var sTs = PlanStartTime.Split(":");

            PlanStartDateTime = sD.AddHours(int.Parse(sTs[0])).AddMinutes(int.Parse(sTs[1]));
            PlanStart = PlanStartDateTime.FullDateTime();

            var fD = PersianDateTime.Parse(PlanFinishDate);
            var fTs = PlanFinishTime.Split(":");

            PlanFinishDateTime = fD.AddHours(int.Parse(fTs[0])).AddMinutes(int.Parse(fTs[1]));
            PlanFinish = PlanFinishDateTime.FullDateTime();
        }

    }
}
