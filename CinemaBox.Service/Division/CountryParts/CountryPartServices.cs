using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Enumeration.Division.CountryPartsType;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Division.CountryParts;

public class CountryPartServices(IUnitOfWork unitOfWork) : ICountryPartServices
{
    public async Task<CountryPart> CreateOrGetCountryPart(string countryPartName, string isoCode)
    {
        CountryPart CountryPart = await GetCountryPart(countryPartName: countryPartName);
        if (CountryPart == null)
        {
            CountryPart = new CountryPart { EnCountryPartName = countryPartName, IsoCode = isoCode, CountryPartTypeId = (int)CountryPartTypeEnumeration.Country };
            await unitOfWork.Repository<CountryPart>().AddAsync(CountryPart);
            await unitOfWork.CompleteAsync();
        }
        return CountryPart;
    }
    public async Task<CountryPart> GetCountryPart(string countryPartName) => await unitOfWork.Repository<CountryPart>().FindAsync(x => x.EnCountryPartName == countryPartName || x.FaCountryPartName== countryPartName);
}