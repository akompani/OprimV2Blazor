using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Schedules;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class WeekSummaryViewModel
    {
        public WeekSummaryViewModel(PersianDateTime projectStartDate, ProjectDaysTool projectDays, PersianDateTime date)
        {
            var firstWeekFinishDate = projectStartDate.FinishWeekDate();

            var weekStartDate = date.StartWeekDate();
            var weekStartDateStr = date.StartWeekDate().ToShortDateString();

            var weekFinishDate = date.FinishWeekDate();
            var weekFinishDateStr = date.FinishWeekDate().ToShortDateString();

            WeekNo = 1 + (weekStartDate - firstWeekFinishDate.AddDays(1)).Days / 7;
            WeekDate = weekFinishDate.ToString("MMMM dd");
            WeekDateMonthName = weekFinishDate.MonthName;

            var firstOfWeekProjectDay = projectDays[weekStartDateStr];
            StartWeekProgress = new PlanCategoryValue(firstOfWeekProjectDay);

            var lastOfWeekProjectDay = projectDays[weekFinishDateStr];
            FinishWeekProgress = new PlanCategoryValue(lastOfWeekProjectDay);

            var dateStr = date.ToShortDateString();
            var thisProjectDay = projectDays[dateStr];
            var earnDay = projectDays.EarnDay(thisProjectDay.AC);

            EarnDate = earnDay.Date;
            PlanDelay = (date - earnDay.PersianDate).Days;

            if (date != weekFinishDate)
            {
                var values = FinishWeekProgress.Values;
                values[TailorModes.Actual] = thisProjectDay.AC;

                FinishWeekProgress = new PlanCategoryValue(values);
            }
            ThisWeekProgress = FinishWeekProgress.Subtract(StartWeekProgress);

            Spi = ThisWeekProgress.Spi();
        }

        public int WeekNo { get; set; }

        public string WeekDate { get; set; }

        public string WeekDateName { get; set; }

        public string WeekDateMonthName { get; set; }

        public PlanCategoryValue StartWeekProgress { get; set; }

        public PlanCategoryValue FinishWeekProgress { get; set; }

        public PlanCategoryValue ThisWeekProgress { get; set; }

        public string EarnDate { get; set; }

        public int PlanDelay { get; set; }

        public decimal Spi { get; set; }

        public decimal Cpi { get; set; }

        public int TotalDirectHuman { get; set; }

        public int TotalOverheadHuman { get; set; }

        public List<ReportActivityResource> DirectResources { get; set; }
        public List<ReportActivityResource> OverheadResources { get; set; }
        public List<ScheduleActivity> Activities { get; set; }

        public decimal DailyAverageHuman { get; set; }


    }
}
