using System.Drawing;

namespace CinemaBox.Utilities.Lables;

public class LabelExtension
{
    public static Color GetRandomPastelColor()
    {
        Random rnd = new();
        return Color.FromArgb(rnd.Next(150, 255), rnd.Next(150, 255), rnd.Next(150, 255));
    }
    public static Color GetContrastColor(Color bgColor)
    {
        int luminance = (int)(0.299 * bgColor.R + 0.587 * bgColor.G + 0.114 * bgColor.B);
        return luminance > 150 ? Color.Black : Color.White;
    }
}