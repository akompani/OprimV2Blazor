using MD.PersianDateTime;
using Oprim.Domain.Old.Models.PMO.Schedules.ViewModels;
using Oprim.Domain.Old.Models.PMO.Tailoring.Daily;

namespace Oprim.Domain.Old.Models.PMO.Tailoring.ViewModel
{
    public class PeriodSummaryViewModel
    {
        public PeriodSummaryViewModel()
        {

        }

        public PeriodSummaryViewModel(PersianDateTime projectStartDate, ProjectDaysTool projectDays, PersianDateTime startDate,PersianDateTime finishDate)
        {
            StartDate = startDate;
            if(startDate < projectStartDate) startDate = projectStartDate;
            
            FinishDate = FinishDate;

            var startDateStr = startDate.ToShortDateString();
            var finishDateStr = finishDate.ToShortDateString();

            var fw = projectDays[startDate];
            StartProgress = new PlanCategoryValue(fw);

            var lw = projectDays[finishDate];
            FinishProgress = new PlanCategoryValue(lw);

            var earnDay = projectDays.EarnDay(lw.AC);

            FinishEarnDate = earnDay.Date;
            PlanDelay = (finishDate - earnDay.PersianDate).Days;

            ThisPeriodProgress = FinishProgress.Subtract(StartProgress);
            
            Spi = ThisPeriodProgress.Spi();
        }

        public int Period { get; set; }

        public PersianDateTime StartDate { get; set; }

        public PersianDateTime FinishDate { get; set; }

        public PlanCategoryValue StartProgress { get; set; }

        public PlanCategoryValue FinishProgress { get; set; }

        public PlanCategoryValue ThisPeriodProgress { get; set; }

        public string FinishEarnDate { get; set; }

        public int PlanDelay { get; set; }

        public decimal Spi { get; set; }

        public decimal Cpi { get; set; }
        
        public List<ReportActivity> PeriodProgresses { get; set; }

        public int TotalDirectHuman { get; set; }

        public int TotalOverheadHuman { get; set; }

        public decimal DailyAverageHuman { get; set; }

        public Dictionary<(int,int),int> DirectResources { get; set; }
        public Dictionary<(int,int),double> DirectResourcesAverages { get; set; }

        public Dictionary<(int,int),int> OverheadResources { get; set; }
        public Dictionary<(int,int),double> OverheadResourcesAverage { get; set; }
        


    }
}
