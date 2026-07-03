using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieCountries;

public class MovieCountry
{
    public required int MovieId { get; set; }
    public required int CountryPartId { get; set; }
    public CountryPart? CountryPart { get; set; }
    public Movie? Movie { get; set; }
}