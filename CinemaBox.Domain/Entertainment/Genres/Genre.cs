using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Genres;

public class Genre : PersistentObject<byte>
{
    public required string EnGenreName { get; set; }
    public string? FaGenreName { get; set; }
    public long? FileId { get; set; }
    public Files.Files.File? File { get; set; }
   // public ICollection<MovieGenre> MovieGenres { get; set; } = [];
}