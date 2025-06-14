using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Person.Peoples;

namespace CinemaBox.Domain.Shared.DeathCauses;

public class DeathCause : PersistentObject<int>
{
    public required string EnDeathCauseName { get; set; }
    public string? FaDeathCauseName { get; set; }
    public ICollection<People> People { get; set; } = [];
}