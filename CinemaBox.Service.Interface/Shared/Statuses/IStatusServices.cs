using CinemaBox.Domain.Shared.Statuses;

namespace CinemaBox.Service.Interface.Shared.Statuses;

public interface IStatusServices
{
    Task<IEnumerable<Status>> GetAllStatuses();
    Task<Status?> GetStatusAsync(string statusesName);
}
