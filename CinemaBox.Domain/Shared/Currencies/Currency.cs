using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
namespace CinemaBox.Domain.Shared.Currencies;
public class Currency : PersistentObject<byte>
{
    public required string CurrencyName { get; set; }
    public required string PersianCurrencyName { get; set; }
    public required string CurrencyCode { get; set; }  // ISO 4217, e.g. "USD", "EUR", "IRR"
    public string? Symbol { get; set; }               // e.g. "$", "€", "﷼"
    public ICollection<Movie> MovieBudgets { get; set; } = [];
    public ICollection<Movie> MovieRevenues { get; set; } = [];
}