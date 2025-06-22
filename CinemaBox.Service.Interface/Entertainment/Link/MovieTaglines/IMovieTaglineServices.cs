using CinemaBox.Domain.Entertainment.Link.MovieTaglines;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;

public interface IMovieTaglineServices
{
    Task<List<MovieTagline>> CreateMovieTagline(List<string> taglineModels, string movieId);
    Task<IEnumerable<MovieTagline?>> GetMovieTagline(string movieId);
}
