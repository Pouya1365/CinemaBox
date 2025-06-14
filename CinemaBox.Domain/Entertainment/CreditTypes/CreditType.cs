using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.CreditTypes;

public class CreditType : PersistentObject<byte>
{
    public required string EnCreditTypeName { get; set; }
    public string? FaCreditTypeName { get; set; }
   // public ICollection<MovieCredit> MovieCredits { get; set; } = [];
}