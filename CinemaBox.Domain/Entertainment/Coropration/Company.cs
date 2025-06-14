using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Coropration;

public class Company : PersistentObject<string>
{
    public required string EnCompanyName { get; set; }
    public string? FaCompanyName { get; set; }
    public ICollection<MovieCompany> MovieCompanies { get; set; } = [];
}