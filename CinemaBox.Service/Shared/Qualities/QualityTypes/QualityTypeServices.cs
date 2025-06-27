using CinemaBox.Domain.Shared.Qualities.QualityTypes;
using CinemaBox.Service.Interface.Shared.Qualities.QualityTypes;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Qualities.QualityTypes;

public class QualityTypeServices(IUnitOfWork unitOfWork) : IQualityTypeServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<IEnumerable<QualityType>> GetAllQualityTypes() => await _unitOfWork.Repository<QualityType>().GetAllAsync();

    public async Task<QualityType?> GetQualityTypeAsync(string qualityTypeName)
    {
        if (string.IsNullOrWhiteSpace(qualityTypeName))
            return null;
        return await _unitOfWork.Repository<QualityType>()
            .FindAsync(q => q.QualityTypeName == qualityTypeName);
    }
}