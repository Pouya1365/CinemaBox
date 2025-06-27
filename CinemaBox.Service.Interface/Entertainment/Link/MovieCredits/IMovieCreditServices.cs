using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Model.Entertainment.Cast.Credit;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;

public interface IMovieCreditServices
{
    Task<List<MovieCredit>> CreateOrGetMovieCredit(List<CreditModel> creditModels, string path);
    Task<IEnumerable<MovieCredit>> GetMovieCreditsAsync(string movieId);
    Task<bool> ChangeIsLeadRole(string peopleId, string movieId);
}
