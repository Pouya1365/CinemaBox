using CinemaBox.Domain.Shared.Statuses;
using CinemaBox.Service.Interface.Shared.Statuses;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Statuses;

public class StatusServices(IUnitOfWork unitOfWork) : IStatusServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<IEnumerable<Status>> GetAllStatuses() => await _unitOfWork.Repository<Status>().GetAllAsync();

    public async Task<Status?> GetStatusAsync(string statusesName)
    {
        if (string.IsNullOrWhiteSpace(statusesName))
            return null;
        return await _unitOfWork.Repository<Status>()
            .FindAsync(s => s.SatusName == statusesName);
    }
}