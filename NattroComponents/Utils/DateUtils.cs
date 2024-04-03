using System.Globalization;

namespace NattroComponents.Utils;
public static class DateUtils
{
    public static string ToYYYYMMDD(this DateTime? myDate)
    {
        return myDate != null ? ((DateTime)myDate).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : string.Empty;
    }
    public static string ToYYYYMMDD(this DateTime myDate)
    {
        return myDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}
