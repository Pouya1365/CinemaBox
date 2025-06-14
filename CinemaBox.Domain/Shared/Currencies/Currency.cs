using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Currencies;

public class Currency : PersistentObject<byte>
{
    public required string CurrencyName { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}