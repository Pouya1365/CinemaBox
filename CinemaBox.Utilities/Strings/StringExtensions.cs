namespace CinemaBox.Utilities.Strings;

public static class StringExtensions
{
    public static string? NormalizeSafe(this string? value) => value?.Trim().ToLower();
}
