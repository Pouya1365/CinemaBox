namespace CinemaBox.Utilities.Enums;

public static class EnumExtension
{
    public static bool TryGetEnumNumericValue<TEnum>(string input, out int value) where TEnum : struct, Enum
    {
        value = default;
        if (Enum.TryParse(input, true, out TEnum result))
            if (Enum.IsDefined(result))
            {
                value = Convert.ToInt32(result);
                return true;
            }
        return false;
    }
}