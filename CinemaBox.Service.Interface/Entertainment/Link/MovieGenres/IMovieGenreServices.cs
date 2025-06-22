using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Link.MovieGenres;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;

public interface IMovieGenreServices
{
    Task<List<MovieGenre>> CreateOrGetMovieGenre(List<string> genreModels, string movieId);
    Task<Genre> GetMovieGenreAsync(string genreName);
    Task<IEnumerable<MovieGenre>> GetMovieGenre(string movieId) ;
}
