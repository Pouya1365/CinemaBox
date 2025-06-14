using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Movies;

namespace CinemaBox.Domain.Entertainment.Link.MovieGenres;

public class MovieGenre
{
    public required string MovieId { get; set; }
    public required byte GenreId { get; set; }
    public Genre? Genre { get; set; }
    public Movie? Movie { get; set; }
}