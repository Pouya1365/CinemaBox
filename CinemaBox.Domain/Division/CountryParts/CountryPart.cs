using CinemaBox.Domain.Division.CountryPartTypes;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Division.CountryParts;

public class CountryPart : PersistentObject<long>
{
    public required string CountryPartName { get; set; }
    public string? PersianCountryPartName { get; set; }
    public long? ParentId { get; set; }
    public string? IsoCode { get; set; }
    public byte? CountryPartTypeId { get; set; }
    public ICollection<CountryPart> Children { get; set; } = [];
    public CountryPartType? CountryPartType { get; set; }
    public ICollection<MovieCountry> MovieCountries { get; set; } = [];
}