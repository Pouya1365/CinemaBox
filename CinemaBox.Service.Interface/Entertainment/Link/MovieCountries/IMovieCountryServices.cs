using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;

namespace CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;

public interface IMovieCountryServices
{
    Task<List<MovieCountry>> CreateOrGetMovieCountry(Dictionary<string, string> countryModels, string movieId);
     Task<CountryPart> GetCountryPartAsync(string countryPartName, string isoCode);
}
