using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Service.Interface.Shared.Formats;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Formats;

public class FormatServices(IUnitOfWork unitOfWork) : IFormatServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Format?> CreateOrGetFormatAsync( string? formatName)
    {
        if (string.IsNullOrWhiteSpace(formatName))
            return null;
        Format? format = await GetFormatAsync(formatName:formatName);
        if (format == null)
        {
            format = new Format { FormatName=formatName };
            await _unitOfWork.Repository<Format>().AddAsync(format);
            await _unitOfWork.CompleteAsync();
        }
        return format;
    }
    public async Task<Format?> GetFormatAsync(string formatName)
    {
        if (string.IsNullOrEmpty(formatName))
            return null;
        return await _unitOfWork.Repository<Format>()
            .FindAsync(c => c.FormatName == formatName);
    }
}
