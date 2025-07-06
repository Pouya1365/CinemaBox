using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Keywords;

public class KeywordServices(IUnitOfWork unitOfWork) : IKeywordServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Keyword?> CreateOrGetKeywordAsync(string? keywordId, string? keywordName)
    {
        if (string.IsNullOrWhiteSpace(keywordId))
            return null;
        Keyword? Keyword = await GetKeywordAsync(keywordId: keywordId);
        if (Keyword == null)
        {
            Keyword = new Keyword { EnKeyowrdName = keywordName.Trim(), Id = keywordId };
            await _unitOfWork.Repository<Keyword>().AddAsync(Keyword);
            await _unitOfWork.CompleteAsync();
        }
        return Keyword;
    }
    public async Task<Keyword?> GetKeywordAsync(string keywordId)
    {
        if (string.IsNullOrEmpty(keywordId))
            return null;
        return await _unitOfWork.Repository<Keyword>()
            .FindAsync(c => c.Id == keywordId);
    }
    public async Task<List<Keyword>?> GetKeywordFaNulllAsync() => await _unitOfWork.Repository<Keyword>()
            .GetAllListAsync(k => k.FaKeyowrdName == null);
    public async Task UpdateKeyword(List<Keyword>? keywords)
    {
        foreach (Keyword keyword in keywords)
            _unitOfWork.Repository<Keyword>().Update(keyword);
        if (keywords.Any())
            await _unitOfWork.CompleteAsync();
    }



}
