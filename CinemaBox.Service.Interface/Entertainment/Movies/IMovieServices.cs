using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Model.Statestics;

namespace CinemaBox.Service.Interface.Entertainment.Movies;

public interface IMovieServices
{
    Task<Movie> CreateOrUpdate(MovieModelScrapping model);
    Task<Movie?> GeMovieAsync(string? ImdbId);
    Task<List<ShowMovieModel>> GetMovieModelsAsync(string search);
    Task UpdateMovie(Movie movie);
    Task<List<ShowMovieModel>> GetMovieModelsAsync(List<string> movieId);
    Task<StatesticsModel> GetStatestics(StatesticsModel models);
}
