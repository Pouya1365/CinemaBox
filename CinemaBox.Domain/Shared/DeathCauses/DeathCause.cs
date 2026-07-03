using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Person.Peoples;

namespace CinemaBox.Domain.Shared.DeathCauses;

public class DeathCause : PersistentObject<int>
{
    public required string DeathCauseName { get; set; }
    public string? PersianDeathCauseName { get; set; }
    public ICollection<People> People { get; set; } = [];
}