using GeneralServices;
using GeneralServices.Calendars;
using MD.PersianDateTime;

namespace Oprim.Domain.Old.Models.Projects
{
    public class ProjectCalendarDistribution : PersianCalendarDistribution
    {
        // date , percentage of availability ( 1404/01/02 , 1404/01/10 , 50 )
        private Dictionary<int,int> _availableDates;
        private readonly List<ProjectCalendarAvailable> _availableRanges;

        public ProjectCalendarDistribution(PersianCalendar calendar
            , List<PersianCalendarHoliday> holidays
            , List<ProjectCalendarAvailable> availableRanges
            , string start = null
            , string finish = null
            ) : base(calendar, holidays, start, finish)
        {
            //if no available date set ALL DATE IS AVAILABLE
            _availableRanges = availableRanges;
        }

        public override void Initialize()
        {
            _availableDates = GenerateAvailableRanges(_availableRanges);
            base.Initialize();
        }

        private Dictionary<int,int> GenerateAvailableRanges(List<ProjectCalendarAvailable> availableRanges)
        {
            var result = new Dictionary<int, int>();

            foreach (var range in availableRanges)
            {
                var start = range.Start.ToPersianDateTime();
                var finish = range.Finish.ToPersianDateTime();

                var tDate = start;

                do
                {
                    result.Add(tDate.ToShortDateInt(),range.AvailablePercentage);
                    tDate = tDate.AddDays(1);

                } while (tDate.ToShortDateInt() <= finish.ToShortDateInt());
            }



            return result;
        }

        protected override Dictionary<int, CalendarDayRange> GenerateDays(PersianDateTime startRange, PersianDateTime finishRange)
        {
            var tDate = startRange;

            var result = new Dictionary<int, CalendarDayRange>();
            uint startValue = 0;

            do
            {
                int availableFactor = 100;

                if (_availableDates.Count != 0)
                {
                     availableFactor = _availableDates.ContainsKey(tDate.ToShortDateInt())
                        ? _availableDates[tDate.ToShortDateInt()]
                        : 0;
                }

                var newDay = new CalendarDayRange(startValue, GetDateDuration(tDate), availableFactor);

                result.Add(tDate.ToShortDateInt(), newDay);

                startValue += newDay.Duration;
                tDate = tDate.AddDays(1);

            } while (tDate.ToShortDateInt() <= finishRange.ToShortDateInt());

            return result;
        }
    }
}
