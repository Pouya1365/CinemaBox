using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Collections;

public class Collection : PersistentObject<int>
{
    public required string CollectionName { get; set; }
    public string? PersianCollectionName { get; set; }
    public int? TotalMoviesInCollection { get; set; }
    public string? Description { get; set; }           // e.g. "The story of..."
    public long? PosterPathFileId { get; set; }            // Collection poster
    public long? BackdropPathFileId { get; set; }          // Collection backdrop
    public ICollection<Movie> Movies { get; set; } = [];
}
