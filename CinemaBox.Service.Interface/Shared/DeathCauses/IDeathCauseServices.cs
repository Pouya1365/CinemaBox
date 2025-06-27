using CinemaBox.Domain.Shared.DeathCauses;

namespace CinemaBox.Service.Interface.Shared.DeathCauses;

public interface IDeathCauseServices
{
    Task<DeathCause?> CreateOrGetDeathCauseAsync(string? deathCauseName);
    Task<DeathCause?> GetDeathCauseAsync(string deathCauseName);
    Task<IEnumerable<DeathCause>?> GetDeathCauseAllAsync();
}
