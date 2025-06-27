using CinemaBox.Domain.Shared.Qualities.Qualities;
using CinemaBox.Service.Interface.Shared.Qualities.Qualities;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Qualities.Qualities;

public class QualityServices(IUnitOfWork unitOfWork) : IQualityServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<IEnumerable<Quality>> GetAllQualities() => await _unitOfWork.Repository<Quality>().GetAllAsync();

    public async Task<Quality?> GetQualityAsync(string qualityName)
    {
        if (string.IsNullOrWhiteSpace(qualityName))
            return null;
        return await _unitOfWork.Repository<Quality>()
            .FindAsync(q => q.QualityName == qualityName);
    }
}