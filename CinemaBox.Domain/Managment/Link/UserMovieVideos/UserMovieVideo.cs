using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Formats;

namespace CinemaBox.Domain.Managment.Link.UserMovieVideos;

public class UserMovieVideo:PersistentObject<string>
{
    public byte? FormatId { get; set; }
    public string? BitRate { get; set; }
    public string? FPS { get; set; }
    public string? AspectRatio { get; set; }
    public string? Resolution { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
}
