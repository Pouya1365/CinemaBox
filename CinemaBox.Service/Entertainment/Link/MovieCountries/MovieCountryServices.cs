using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieCountries;

public class MovieCountryServices(IUnitOfWork unitOfWork,ICountryPartServices countryPartServices) : IMovieCountryServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ICountryPartServices _countryPartServices = countryPartServices ?? throw new ArgumentNullException(nameof(countryPartServices));
    public async Task<List<MovieCountry>> CreateOrGetMovieCountry(Dictionary<string, string> countryModels, string movieId)
    {
        List<MovieCountry> movieCountries = [];
        foreach (var countryModel in countryModels)
        {
            CountryPart Country =await GetCountryPartAsync( countryPartName: countryModel.Value,isoCode: countryModel.Key);
            if (Country != null)
                movieCountries.Add(new MovieCountry
                {
                    CountryPartId = Country.Id,
                    MovieId = movieId
                });
        }
        await _unitOfWork.Repository<MovieCountry>().AddRangeAsync([.. movieCountries.Distinct()]);
        await _unitOfWork.CompleteAsync();
        return movieCountries;
    }
    public async Task<CountryPart> GetCountryPartAsync(string countryPartName, string isoCode) =>await _countryPartServices.CreateOrGetCountryPart(CountryPartName: countryPartName, isoCode: isoCode);
    public async Task<IEnumerable<MovieCountry>> GetMovieCountry(string movieId) => await _unitOfWork.Repository<MovieCountry>().GetAllWithPredicateAsync(x => x.MovieId == movieId, x => x.CountryPart);
}