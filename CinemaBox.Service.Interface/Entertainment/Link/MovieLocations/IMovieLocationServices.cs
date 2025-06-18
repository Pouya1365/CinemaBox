using CinemaBox.Domain.Entertainment.Link.MovieLocations;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;

public interface IMovieLocationServices
{
    Task<List<MovieLocation>> CreateMovieLocation(List<string> locationModels, string movieId);
}
