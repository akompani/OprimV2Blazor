using GeneralServices;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.Projects;

namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public class ScheduleActivityViewModel : ScheduleActivity,ISummarize
    {
        public Dictionary<TailorModes, PersianDateTime> Starts = new Dictionary<TailorModes, PersianDateTime>();

        public Dictionary<TailorModes, PersianDateTime> Finishes = new Dictionary<TailorModes, PersianDateTime>();

        public PersianDateTime ConstraintPersianDateTime { get; set; }

        public List<ActivityRelationViewModel> PredecessorsList { get; set; } = new List<ActivityRelationViewModel>();

        public List<ActivityRelationViewModel> SuccessorsList { get; set; } = new List<ActivityRelationViewModel>();

        public string Error { get; set; }
        public int RescheduleSlack { get; set; }
        public bool IsRescheduleCritical { get; set; }
        public decimal ActionWeightFactor { get; set; }

        public decimal ActualProgress { get; set; }
        public decimal PlanProgress { get; set; }
        public decimal PlanLateProgress { get; set; }
        public decimal PlanEarlyProgress { get; set; }

        public decimal RescheduleProgress { get; set; }
        public decimal RescheduleLateProgress { get; set; }

        public PersianDateTime PossibleStart { get; set; }

        private List<PersianDateRange> splits { get; set; } = new List<PersianDateRange>();

        public void AddSplit(PersianDateTime start,PersianDateTime finish)
        {
            if (splits.Count > 0)
            {
                foreach (var split in splits)
                {
                    if (start.IsInPersianRange(split.Start, split.Finish) |
                        finish.IsInPersianRange(split.Start, split.Finish))
                    {
                        if (start < split.Start)
                        {
                            split.Start = start;
                        }

                        if (finish > split.Finish)
                        {
                            split.Finish = finish;
                        }
                    }
                    else
                    {
                        splits.Add(new PersianDateRange(start,finish));
                    }
                }
            }
            else
            {
                splits.Add(new PersianDateRange(start,finish));
            }
        }

        public List<(int id,string name)> StakeholderList { get; set; } = new List<(int id, string name)>();
        public List<(long id,string name)> DeliverableList { get; set; } = new List<(long, string)>();

        #region Functions

        public void SetFinishByStart(TailorModes tailorMode, Dictionary<int, ProjectCalendarCore> calendarDic, int dayHours)
        {
            Finishes[tailorMode] = calendarDic[ProjectCalendarId].AddHours(Starts[tailorMode], Duration * dayHours);
        }
        public void SetStartByFinish(TailorModes tailorMode, Dictionary<int, ProjectCalendarCore> calendarDic, int dayHours)
        {
            Starts[tailorMode] = calendarDic[ProjectCalendarId].AddHours(Finishes[tailorMode], -Duration * dayHours);
        }

        public void SetStarts()
        {
            PlanStartDate = Starts[TailorModes.Plan].ToShortDateString();
            EarlyStartDate = Starts[TailorModes.EarlyPlan].ToShortDateString();
            LateStartDate = Starts[TailorModes.LatePlan].ToShortDateString();
        }


        public void SetFinishes()
        {
            PlanFinishDate = Finishes[TailorModes.Plan].ToShortDateString();
            EarlyFinishDate = Finishes[TailorModes.EarlyPlan].ToShortDateString();
            LateFinishDate = Finishes[TailorModes.LatePlan].ToShortDateString();
        }

        public void SetDates()
        {
            SetStarts();
            SetFinishes();
        }

        public void SetForecastToRescheduleDates(Dictionary<int, ProjectCalendarCore> calendarCores, decimal workHoursInDay, PersianDateTime rescheduleDate, decimal progress)
        {
            var rescheduleFinish = ForecastFinishDate(calendarCores, workHoursInDay, rescheduleDate);

            var startByConstraintFinishDate = calendarCores[ProjectCalendarId].AddHours(ConstraintPersianDateTime,
                (int)(-1 * ((1 - progress) * Duration * workHoursInDay)));

            switch (ConstraintMode)
            {
                case ActivityConstraintModes.StartNoEarlierThan:
                    if (rescheduleDate < ConstraintPersianDateTime) rescheduleDate = ConstraintPersianDateTime;
                    break;

                case ActivityConstraintModes.StartNoLaterThan:
                    if (rescheduleDate > ConstraintPersianDateTime) Error = $"Activity can not start later than {ConstraintDate}"; ;
                    break;

                case ActivityConstraintModes.FinishNoEarlierThan:
                    if (rescheduleFinish < ConstraintPersianDateTime) rescheduleDate = startByConstraintFinishDate;
                    break;

                case ActivityConstraintModes.FinishNoLaterThan:
                    if (rescheduleFinish > ConstraintPersianDateTime) Error = $"Activity can not finish later than {ConstraintDate}";
                    break;

                case ActivityConstraintModes.StartOn:
                    if (rescheduleDate > ConstraintPersianDateTime)
                    {
                        Error = Error = $"Activity must be start on {ConstraintDate}";
                    }
                    else
                    {
                        rescheduleDate = ConstraintPersianDateTime;
                    }
                    break;

                case ActivityConstraintModes.FinishOn:
                    if (rescheduleFinish > ConstraintPersianDateTime)
                    {
                        Error = Error = $"Activity must be finish on {ConstraintDate}";
                    }
                    else
                    {
                        rescheduleDate = startByConstraintFinishDate;
                    }
                    break;

            }

            if (rescheduleDate < Starts[TailorModes.Plan]) rescheduleDate = Starts[TailorModes.Plan];

            Starts[TailorModes.ReSchedule] = progress > 0 ? Starts[TailorModes.Plan] : rescheduleDate;
            rescheduleFinish = ForecastFinishDate(calendarCores, workHoursInDay, rescheduleDate);

            Finishes[TailorModes.ReSchedule] = rescheduleFinish;

            SetDates();
        }

        public void PlanCalculate(Dictionary<int, ProjectCalendarCore> calendarCores, PersianDateTime date)
        {
            PlanProgress = calendarCores[ProjectCalendarId]
                .Progress(date, Starts[TailorModes.Plan], Finishes[TailorModes.Plan]) / 100;

            PlanEarlyProgress = calendarCores[ProjectCalendarId]
                .Progress(date, Starts[TailorModes.EarlyPlan], Finishes[TailorModes.EarlyPlan]) / 100;

            PlanLateProgress = calendarCores[ProjectCalendarId]
                .Progress(date, Starts[TailorModes.LatePlan], Finishes[TailorModes.LatePlan]) / 100;

            Slack = (Starts[TailorModes.LatePlan] - Starts[TailorModes.Plan]).Days;
            IsCritical = Slack == 0;
        }

        public void RescheduleCalculate(Dictionary<int, ProjectCalendarCore> calendarCores, PersianDateTime date)
        {
            RescheduleProgress = calendarCores[ProjectCalendarId]
                .Progress(date, Starts[TailorModes.ReSchedule], Finishes[TailorModes.ReSchedule]) / 100;

            RescheduleLateProgress = calendarCores[ProjectCalendarId]
                .Progress(date, Starts[TailorModes.LateReSchedule], Finishes[TailorModes.LateReSchedule]) / 100;

            RescheduleSlack = (Starts[TailorModes.LateReSchedule] - Starts[TailorModes.ReSchedule]).Days;
            IsRescheduleCritical = RescheduleSlack == 0;
        }

        public PersianDateTime ForecastFinishDate(Dictionary<int, ProjectCalendarCore> calendarCores, decimal workHoursInDay, PersianDateTime date)
        {
            var remainHours = (int)Math.Round((1 - ActualProgress) * workHoursInDay * Duration, 0);
            if (remainHours == 0 & ActualProgress < 1 & Duration > 0) remainHours = 1;

            remainHours += CalculateSplitDuration(calendarCores[ProjectCalendarId], date);

            return calendarCores[ProjectCalendarId].AddHours(date, remainHours);
        }

        public PersianDateTime BackwardStartDate(Dictionary<int, ProjectCalendarCore> calendarCores, decimal workHoursInDay, PersianDateTime date)
        {
            var remainHours = (int)Math.Round((1 - ActualProgress) * workHoursInDay * Duration, 0);
            if (remainHours == 0 & ActualProgress < 1 & Duration > 0) remainHours = 1;

            remainHours += CalculateSplitDuration(calendarCores[ProjectCalendarId], date);

            return calendarCores[ProjectCalendarId].AddHours(date, -remainHours);
        }


        private int CalculateSplitDuration(ProjectCalendarCore calendarCore, PersianDateTime date)
        {
            int result = 0;

            foreach (var split in splits.Where(s => s.Finish > date))
            {
                if (date.IsInPersianRange(split.Start, split.Finish))
                {
                    result +=(int) calendarCore.DurationByHour(date, split.Finish);
                }
                else
                {
                    result +=(int) calendarCore.DurationByHour(split.Start, split.Finish);
                }
            }

            return result;
        }

        public string GetDurationCalendarString()
        {
            return $"{Duration}-{ProjectCalendarId}";
        }


        #endregion

        public SummarizeTemplate GetSummarize()
        {
            return new SummarizeTemplate(Id, FullName);
        }
    }
}
