using CinemaBox.Domain.Entertainment.Link.MovieCompanies;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;

public interface IMovieCompanyServices
{
    Task<bool?> CreateOrGetMovieCompanyAsync(string movieId, Dictionary<string, string>? companieskeyValuePairs);
    Task<MovieCompany?> GetMovieCompanyAsync(string movieId, string companyId);
}
