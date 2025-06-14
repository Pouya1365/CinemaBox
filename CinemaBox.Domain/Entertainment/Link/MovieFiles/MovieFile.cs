using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieFiles;

public class MovieFile
{
    public required string MovieId { get; set; }
    public required long FileId { get; set; }
    public Movie? Movie { get; set; }
    public Files.Files.File? File { get; set; }

}