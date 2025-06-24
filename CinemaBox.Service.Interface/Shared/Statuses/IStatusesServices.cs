using CinemaBox.Domain.Shared.Statuses;

namespace CinemaBox.Service.Interface.Shared.Statuses;

public interface IStatusesServices
{
    Task<Status?> GetStatusAsync(string statusesName);
}
