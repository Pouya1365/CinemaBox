using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Strings;

namespace CinemaBox.Service.Shared.Keywords;

public class KeywordServices(IUnitOfWork unitOfWork) : IKeywordServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Keyword?> CreateOrGetKeywordAsync(string? keywordName)
    {
        if (string.IsNullOrWhiteSpace(keywordName))
            return null;
        Keyword? Keyword = await GetKeywordAsync(keywordName);
        if (Keyword == null)
        {
            Keyword = new Keyword { EnKeyowrdName = keywordName.Trim() };
            await _unitOfWork.Repository<Keyword>().AddAsync(Keyword);
            await _unitOfWork.CompleteAsync();
        }
        return Keyword;
    }
    public async Task<Keyword?> GetKeywordAsync(string keywordName)
    {
        if (string.IsNullOrWhiteSpace(keywordName))
            return null;
        string? nameToCompare = StringExtensions.NormalizeSafe(keywordName);
        if (string.IsNullOrEmpty(nameToCompare))
            return null;
        return await _unitOfWork.Repository<Keyword>()
            .FindAsync(c => c.EnKeyowrdName.ToLower() == nameToCompare || c.FaKeyowrdName == keywordName);
    }
}
