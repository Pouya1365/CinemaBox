using CinemaBox.Domain.Shared.Qualities.QualityTypes;

namespace CinemaBox.Service.Interface.Shared.Qualities.QualityTypes;

public interface IQualityTypeServices
{
    Task<IEnumerable<QualityType>> GetAllQualityTypes();
    Task<QualityType?> GetQualityTypeAsync(string qualityTypeName);
}
