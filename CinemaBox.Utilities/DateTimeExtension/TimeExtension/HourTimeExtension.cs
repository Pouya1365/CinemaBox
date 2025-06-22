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
}
