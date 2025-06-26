namespace CinemaBox.Utilities.DateTimeExtension.TimeExtension;

public static class HourTimeExtension
{
    public static string? ToHourTime(long RunTime)
    {
        long minute = RunTime % 60;
        long hour = RunTime / 60;
        string hourTime = $"ساعت:{hour:00} دقیقه:{minute:00} ";
        return hourTime;
    }
    public static double ConvertTextToRunTime(double totalMinutes)
    {
        double totalHours = (totalMinutes / 60) / 60;
        int hours = (int)totalHours * 60;
        double remainingMinutes = (totalMinutes / 60) % 60;
        int minutes = (int)remainingMinutes;
        double decimalSeconds = (remainingMinutes - minutes) * 60;
        int seconds = (int)decimalSeconds;
        return hours + minutes + (seconds > 30 ? 1 : 0);
    }
    public static string FormatHourMinutesToTimeString(int totalMinutes)
    {
        if (totalMinutes < 0)
            throw new ArgumentOutOfRangeException(nameof(totalMinutes), "Minutes cannot be negative");
        double totalHours = (totalMinutes / 60);
        double remainingMinutes = (totalMinutes % 60)== 0?totalMinutes: (totalMinutes % 60) ;
        int minutes = (int)remainingMinutes;
        double decimalSeconds = (remainingMinutes - minutes) * 60;
        int seconds = (int)decimalSeconds;
        return $"{totalHours}h{minutes:D2}m";
    }
}
