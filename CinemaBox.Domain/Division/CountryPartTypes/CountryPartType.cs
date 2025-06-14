using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Division.CountryPartTypes;

public class CountryPartType : PersistentObject<byte>
{
    public required string CountryPartTypeName { get; set; }
     public ICollection<CountryPart> CountryParts { get; set; } = [];
}