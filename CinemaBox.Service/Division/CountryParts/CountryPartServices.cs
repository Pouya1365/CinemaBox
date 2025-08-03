using CinemaBox.Domain.Division.CountryParts;

using CinemaBox.Enumeration.Division.CountryPartsType;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;

namespace CinemaBox.Service.Division.CountryParts;

public class CountryPartServices(IUnitOfWork unitOfWork, ITranslate translate) : ICountryPartServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<CountryPart> CreateOrGetCountryPart(string countryPartName, string isoCode)
    {
        CountryPart CountryPart = await GetCountryPart(countryPartName: countryPartName);
        if (CountryPart == null)
        {
            string faCountryName =await GetFa(countryPartName:countryPartName);
            CountryPart = new CountryPart
            {
                EnCountryPartName = countryPartName,
                IsoCode = isoCode,
                CountryPartTypeId = (int)CountryPartTypeEnumeration.Country,
                FaCountryPartName = faCountryName
            };
            await _unitOfWork.Repository<CountryPart>().AddAsync(CountryPart);
            await _unitOfWork.CompleteAsync();
        }
        return CountryPart;
    }
    public async Task<CountryPart> GetCountryPart(string countryPartName) => await _unitOfWork.Repository<CountryPart>().FindAsync(x => x.EnCountryPartName == countryPartName || x.FaCountryPartName == countryPartName);
    private async Task<string> GetFa(string countryPartName) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: countryPartName));
    public async Task<List<CountryPart>?> GetAllCountryPartFaNull() => await _unitOfWork.Repository<CountryPart>()
             .GetAllListAsync(g => g.FaCountryPartName == null);
    public async Task UpdateFaCountryPart(List<CountryPart> countryParts)
    {
        foreach (CountryPart countryPart in countryParts)
            _unitOfWork.Repository<CountryPart>().Update(countryPart);
        if (countryParts.Any())
            await _unitOfWork.CompleteAsync();
    }
    public async Task<Dictionary<string, int>> GetMovieCountPerCountry()
    {
        IEnumerable<CountryPart> countryParts = await _unitOfWork.Repository<CountryPart>().GetAllWithIncludesAsync(x => x.MovieCountries);
        return countryParts.Select(cp => new
        {
            Name = cp.FaCountryPartName ?? cp.EnCountryPartName,
            Value = cp.MovieCountries.Count()
        })
          .OrderByDescending(x => x.Value)
          .ToDictionary(x => x.Name, x => x.Value);
    }
}