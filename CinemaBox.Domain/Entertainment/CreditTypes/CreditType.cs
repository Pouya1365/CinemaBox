using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Persistent;
namespace CinemaBox.Domain.Entertainment.CreditTypes;
public class CreditType : PersistentObject<byte>
{
    public required string CreditTypeName { get; set; }
    public string? PersianCreditTypeName { get; set; }
    public ICollection<MovieCredit> MovieCredits { get; set; } = [];
}