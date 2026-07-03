using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Genres;

public class Genre : PersistentObject<byte>
{
    public required string GenreName { get; set; }
    public string? PersianGenreName { get; set; }
    public long? FileId { get; set; }
    public int? TmdbId { get; set; }
    public string? ImdbId { get; set; }
    public Files.Files.File? File { get; set; }
    public ICollection<MovieGenre> MovieGenres { get; set; } = [];
}