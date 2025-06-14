using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Collections;

public class Collection : PersistentObject<int>
{
    public required string EnCollectionName { get; set; }
    public string? FaCollectionName { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}
