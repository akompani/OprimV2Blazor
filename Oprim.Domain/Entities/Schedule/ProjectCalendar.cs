using MD.PersianDateTime;
using Oprim.Domain.Common;

namespace Oprim.Domain.Entities.Schedule;

public class ProjectCalendar : BaseProjectEntity
{
    // 8:00 to 12:00 and 13:00 to 17:00
    public static readonly string DefaultTime = "8:00-12:00,13:00-17:00";
    public static readonly string HalfDefaultTime = "8:00-12:00";

    public string Code { get; set; }

    public string Name { get; set; }

    public bool Saturday { get; set; } = true;
    public string SaturdayTimes { get; set; } = DefaultTime;

    public bool Sunday { get; set; } = true;
    public string SundayTimes { get; set; } = DefaultTime;

    public bool Monday { get; set; } = true;
    public string MondayTimes { get; set; } = DefaultTime;

    public bool Tuesday { get; set; } = true;
    public string TuesdayTimes { get; set; } = DefaultTime;

    public bool Wednesday { get; set; } = true;
    public string WednesdayTimes { get; set; } = DefaultTime;

    public bool Thursday { get; set; } = true;
    public string ThursdayTimes { get; set; } = HalfDefaultTime;

    public bool Friday { get; set; }
    public string FridayTimes { get; set; } = "";

    private string GetDayTimes(PersianDayOfWeek day)
    {
        return GetType().GetProperty($"{Enum.GetName(day)}Times").GetValue(this, null)?.ToString() ?? "";
    }
}