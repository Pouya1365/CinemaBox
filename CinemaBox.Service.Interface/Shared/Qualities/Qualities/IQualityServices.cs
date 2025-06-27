using CinemaBox.Domain.Shared.Qualities.Qualities;

namespace CinemaBox.Service.Interface.Shared.Qualities.Qualities;

public interface IQualityServices
{
    Task<IEnumerable<Quality>> GetAllQualities();
    Task<Quality?> GetQualityAsync(string qualityName);
}
