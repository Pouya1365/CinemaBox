using System.Globalization;

namespace CinemaBox.Utilities.DateTimeExtension.DateExtensions;

public static class Pcal
{
    public static DateOnly? ToGeorgian(string gregorianDateString)
    {
        if (DateTime.TryParseExact(gregorianDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            return DateOnly.FromDateTime(date);
        else
            return null;
    }
    public static string? ToToJalali(int year, int month, int day)
    {
        DateTime gregorianDate = new(year, month, day);
        PersianCalendar persianCalendar = new();
        int pYear = persianCalendar.GetYear(gregorianDate);
        int pMonth = persianCalendar.GetMonth(gregorianDate);
        int pDay = persianCalendar.GetDayOfMonth(gregorianDate);
        string persianDate = $"{pYear:0000}/{pMonth:00}/{pDay:00}";
        return persianDate;
    }
}
