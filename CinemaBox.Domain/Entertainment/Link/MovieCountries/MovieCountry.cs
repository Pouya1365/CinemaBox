using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieCountries;

public class MovieCountry
{
    public required string MovieId { get; set; }
    public required long CountryPartId { get; set; }
    public CountryPart? CountryPart { get; set; }
    public Movie? Movie { get; set; }
}