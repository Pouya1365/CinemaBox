using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Statuses;
using CinemaBox.Domain.Users.Users;

namespace CinemaBox.Domain.Managment.Link.UserMovieDisks;

public class UserMovieDisk
{
    public int? MyTime { get; set; }
    public string? PositionMovie { get; set; }
    public int? MovieNumber { get; set; }
    public string? FileName { get; set; }
    public decimal? FileSize { get; set; }
    public bool? IsDubbed { get; set; }
    public bool? IsSubtitle { get; set; }
    public byte? StatusId { get; set; }
    public string? MovieId { get; set; }
    public string? UserId { get; set; }
    public Movie? Movie { get; set; }
    public Status? Status { get; set; }
    public User? User { get; set; }
}