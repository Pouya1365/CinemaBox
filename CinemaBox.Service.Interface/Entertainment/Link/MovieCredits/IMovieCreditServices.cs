using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Model.Imdb.Cast;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;

public interface IMovieCreditServices
{
    Task<List<MovieCredit>> CreateOrGetMovieCredit(List<CreditModel> creditModels, string path);
}
