using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.UserManager.Users;

namespace CinemaBox.Domain.Managment.Link.UserMovieFiles;

public class UserMovieFile
{
    public required byte UserId { get; set; }
    public required int MovieId { get; set; }
    public long? PosterPathFileId { get; set; }
    public Movie? Movie { get; set; }
    public User? User { get; set; }
    public Files.Files.File? File { get; set; }

}