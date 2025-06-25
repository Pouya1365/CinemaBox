using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Managment.Link.UserMovieFiles;

public class UserMovieFile
{
    public required string MovieId { get; set; }
    public required long FileId { get; set; }
    public Movie? Movie { get; set; }
    public Files.Files.File? File { get; set; }

}