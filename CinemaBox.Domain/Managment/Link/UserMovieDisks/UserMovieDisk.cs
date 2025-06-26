using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Statuses;

namespace CinemaBox.Domain.Managment.Link.UserMovieDisks;

public class UserMovieDisk:PersistentObject<string>
{
    public int? MyTime { get; set; }
    public string? PositionMovie { get; set; }
    public int? MovieNumber { get; set; }
    public string? FileName { get; set; }
    public decimal? FileSize { get; set; }
    public bool? IsDubbed { get; set; }
    public bool? IsSubtitle { get; set; }
    public byte? StatusId { get; set; }
    public string? Description { get; set; }
    public Movie? Movie { get; set; }
    public Status? Status { get; set; }
}