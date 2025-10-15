using GeneralServices;
using GeneralServices.Calendars;
using MD.PersianDateTime;
using Oprim.Domain.Old.Models.WorkFlow.Works;

namespace Oprim.Domain.Old.Models.WorkFlow
{
    //نوع اعمال جریمه 
    public enum PenaltyApplyTypes : byte
    {
        All = 0,
        DividedByWeight = 1,
        DividedByPerson = 2,
        AllForGuiltyPersons = 3
    }

    //نوع اعمال امتیاز 
    public enum ScoreApplyTypes : byte
    {
        All = 0,
        DividedByWeight = 1,
        DividedByPerson = 2,
    }

    public enum ArticleActions : byte
    {
        Do = 1,
        Audit = 2,
    }

    public enum DoerSelectModes : byte
    {
        Stakeholder = 0,
        Role = 1
    }

    public enum AuditorSelectModes : byte
    {
        Stakeholder = 0,
        Role = 1,
    }

    public enum ArticleSituations : byte
    {
        NotCompleted = 0,
        Completed = 1,
        Diverted = 9
    }

    public enum MinuteItemSituations : byte
    {
        None = 0,
        Ongoing = 1,
        Late = 2,
        CompletedOnTime = 3,
        CompletedByDelay = 4,
    }

    public enum WorkFlowRepeatModes : byte
    {
        None = 0,
        Daily = 1,
        SelectedDays = 2,
        Weekly = 3,
        Monthly = 4,
        Yearly = 5
    }

    public static class WorkFlowGeneralFunctions
    {
        public const int DefaultCustomWorkBaseArticle = -1;
        public const int DefaultCustomCheckBaseArticle = -2;

        public static double GetFactor(bool critical, bool important)
        {
            double result = 1;

            if (critical) result *= 0.8;
            if (important) result *= 0.7;

            return result;
        }

        public static PersianDateTime NextTime(this ScheduleWork scheduleWork, PersianDateTime start)
        {
            switch (scheduleWork.RepeatMode)
            {
                case WorkFlowRepeatModes.Daily:
                    start = start.AddDays(scheduleWork.RepeatFactor);
                    break;

                case WorkFlowRepeatModes.Weekly:
                    start = start.AddDays(7 * scheduleWork.RepeatFactor);
                    break;

                case WorkFlowRepeatModes.Monthly:
                    start = start.AddMonths(scheduleWork.RepeatFactor);
                    break;

                case WorkFlowRepeatModes.Yearly:
                    start = start.AddYears(scheduleWork.RepeatFactor);
                    break;

                case WorkFlowRepeatModes.SelectedDays:

                    var selectionDays = scheduleWork.DaySelection.GetDaySelectionFromString();

                    for (int i = 0; i < 7; i++)
                    {
                        start = start.AddDays(1);

                        if (selectionDays.Contains(start.PersianDayOfWeek)) break;
                    }

                    break;

                default:
                    break;
            }

            return start;
        }
        public static PersianDateTime NextTime(this ScheduleWork scheduleWork, string start)
        {
            return NextTime(scheduleWork, start.ToPersianDateTime());
        }



        public static PersianDateTime NextTimeCalendarBase(this ScheduleWork scheduleWork, string start, PersianCalendarCore calendar)
        {
            return NextTimeCalendarBase(scheduleWork, start.ToPersianDateTime(), calendar);
        } 
        
        public static PersianDateTime NextTimeCalendarBase(this ScheduleWork scheduleWork, PersianDateTime start, PersianCalendarCore calendar)
        {
            var result = NextTime(scheduleWork, start);

            return calendar.ExactWorkStartTime(result);
        }

        public static string AddDaySelection(this string daySelection, PersianDayOfWeek day)
        {
            if (string.IsNullOrEmpty(daySelection)) daySelection = "0000000";

            var result = "";

            for (int i = 0; i < daySelection.Length; i++)
            {
                if (i == (int)day)
                {
                    result += "1";
                }
                else
                {
                    result += daySelection[i];
                }
            }

            return result;
        }

        public static PersianDayOfWeek[] GetDaySelectionFromString(this string daySelection)
        {
            var result = new List<PersianDayOfWeek>();

            for (int i = 0; i < Math.Min(7, daySelection.Length); i++)
            {
                if (daySelection[i] == '1')
                {
                    result.Add((PersianDayOfWeek)i);
                }
            }

            return result.ToArray();
        }

    }

    public class WorkFilter
    {
        public int[] WorkBaseIds { get; set; }

        public int[] StakeholderIds { get; set; }

        public bool IsMine { get; set; }

        public bool AllWorks { get; set; }

        public string Sort { get; set; }

        //All,Completed,NotCompleted,Diverted
        public string Situation { get; set; }
    }
}
