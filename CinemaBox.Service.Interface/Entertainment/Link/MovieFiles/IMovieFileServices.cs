using CinemaBox.Domain.Entertainment.Link.MovieFiles;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieFiles;

public interface IMovieFileServices
{
    Task CreateOrUpdateMovieImage(string path, string imageUrl, string movieId, string movieName);
    Task<MovieFile> GetMovieFile(string movieId);
}
