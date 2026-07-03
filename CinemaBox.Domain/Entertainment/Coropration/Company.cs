using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Coropration;

public class Company : PersistentObject<int>
{
    public required string CompanyName { get; set; }
    public string? Description { get; set; }
    public long? LogoPathFileId { get; set; }  // "/logos/warner-bros.png"
    public string? Headquarters { get; set; }  // "Burbank, California, USA"
    public string? Website { get; set; }
    // External IDs
    public int? TmdbId { get; set; }
    public string? ImdbId { get; set; }  // "co0002663"
    public long? CountryId{ get; set; }  // ISO 3166-1: "US", "IR"
    public int? FoundedYear { get; set; }
    public ICollection<MovieCompany> MovieCompanies { get; set; } = [];
    public CountryPart CountryPart { get; set; }
}