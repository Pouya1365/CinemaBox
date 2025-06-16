using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Users.Users;

namespace CinemaBox.Domain.Managment.Link.UserMovieVideos;

public class UserMovieVideo
{
    public byte? FormatId { get; set; }
    public string? UserId { get; set; }
    public string? MovieId { get; set; }
    public string? BitRate { get; set; }
    public string? FPS { get; set; }
    public string? AspectRatio { get; set; }
    public string? Resolution { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
    public User? User { get; set; }
}
