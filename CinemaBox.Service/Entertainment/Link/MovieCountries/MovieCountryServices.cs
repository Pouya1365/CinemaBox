using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieCountries;

public class MovieGenreServices(IUnitOfWork unitOfWork,ICountryPartServices countryPartServices) : IMovieCountryServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ICountryPartServices _countryPartServices = countryPartServices ?? throw new ArgumentNullException(nameof(countryPartServices));
    public async Task<List<MovieCountry>> CreateOrGetMovieCountry(Dictionary<string, string> countryModels, string movieId)
    {
        List<MovieCountry> MovieCountries = [];
        foreach (var CountryModel in countryModels)
        {
            CountryPart Country =await GetCountryPartAsync( countryPartName: CountryModel.Value,isoCode: CountryModel.Key);
            if (Country != null)
                MovieCountries.Add(new MovieCountry
                {
                    CountryPartId = Country.Id,
                    MovieId = movieId
                });
        }
        await _unitOfWork.Repository<MovieCountry>().AddRangeAsync(MovieCountries);
        await _unitOfWork.CompleteAsync();
        return MovieCountries;
    }
    public async Task<CountryPart> GetCountryPartAsync(string countryPartName, string isoCode) =>await _countryPartServices.CreateOrGetCountryPart(CountryPartName: countryPartName, isoCode: isoCode);
}