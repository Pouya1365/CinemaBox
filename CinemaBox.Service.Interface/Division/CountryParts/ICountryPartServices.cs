using CinemaBox.Domain.Division.CountryParts;

namespace CinemaBox.Service.Interface.Division.CountryParts;

public interface ICountryPartServices
{
    Task<CountryPart> CreateOrGetCountryPart(string CountryPartName, string isoCode);
    Task<CountryPart> GetCountryPart(string CountryPartName);
    Task<List<CountryPart>?> GetAllCountryPartFaNull();
    Task UpdateFaCountryPart(List<CountryPart> countryParts);
    Task<Dictionary<string, int>> GetMovieCountPerCountry();
}
