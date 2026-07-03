using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieCompanies;

public class MovieCompany
{
    public required int MovieId { get; set; }
    public required int CompanyId { get; set; }
    public Company? Company { get; set; }
    public Movie? Movie { get; set; }
}