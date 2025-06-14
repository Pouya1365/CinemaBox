using CinemaBox.Domain.Division.CountryPartTypes;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Division.CountryParts;

public class CountryPart : PersistentObject<long>
{
    public required string EnCountryPartName { get; set; }
    public string? FaCountryPartName { get; set; }
    public long? ParentId { get; set; }
    public string? IsoCode { get; set; }
    public byte? CountryPartTypeId { get; set; }
    public CountryPartType? CountryPartType { get; set; }
   // public ICollection<MovieCountry> MovieCountries { get; set; } = [];
}