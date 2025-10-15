using System.Globalization;

namespace Oprim.Domain.Extensions.Methods;

public static class Converting
{
    public static int ToInt(this string value, int defaultValue = 0)
    {
        return int.TryParse(value, out var result) ? result : defaultValue;
    }

    public static long ToLong(this string value, long defaultValue = 0)
    {
        return long.TryParse(value, out var result) ? result : defaultValue;
    }

    public static double ToDouble(this string value, double defaultValue = 0.0)
    {
        return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;
    }

    public static decimal ToDecimal(this string value, decimal defaultValue = 0m)
    {
        return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : defaultValue;
    }

    public static bool ToBool(this string value, bool defaultValue = false)
    {
        return bool.TryParse(value, out var result) ? result : defaultValue;
    }

    public static DateTime ToDateTime(this string value, DateTime? defaultValue = null)
    {
        return DateTime.TryParse(value, out var result) ? result : defaultValue ?? DateTime.MinValue;
    }

    public static Guid ToGuid(this string value, Guid? defaultValue = null)
    {
        return Guid.TryParse(value, out var result) ? result : defaultValue ?? Guid.Empty;
    }
}