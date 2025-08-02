using System.Drawing;

namespace CinemaBox.Model.Chart;

public class ChartModel
{
    public string? Name { get; set; }
    public Color SeriColor { get; set; }
    public Color AreaColor { get; set; }
    public string Type { get; set; }= "Pie";
}
