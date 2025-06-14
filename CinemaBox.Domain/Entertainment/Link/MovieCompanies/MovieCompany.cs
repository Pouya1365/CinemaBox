using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieCompanies;

public class MovieCompany
{
    public required string MovieId { get; set; }
    public required string CompanyId { get; set; }
    public Company? Company { get; set; }
    public Movie? Movie { get; set; }
}