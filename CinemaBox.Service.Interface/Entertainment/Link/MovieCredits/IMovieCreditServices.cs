using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Model.Entertainment.Cast;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;

public interface IMovieCreditServices
{
    Task<List<MovieCredit>> CreateOrGetMovieCredit(List<CreditModel> creditModels, string path);
}
