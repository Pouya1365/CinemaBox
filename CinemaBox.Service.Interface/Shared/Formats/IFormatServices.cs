using CinemaBox.Domain.Shared.Formats;

namespace CinemaBox.Service.Interface.Shared.Formats;

public interface IFormatServices
{
    Task<Format?> CreateOrGetFormatAsync(string? formatName);
    Task<Format?> GetFormatAsync(string formatName);
}
