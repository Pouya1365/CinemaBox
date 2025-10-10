using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;

namespace CinemaBox.Service.Shared.Keywords;

public class KeywordServices(IUnitOfWork unitOfWork, ITranslate translate) : IKeywordServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<Keyword?> CreateOrGetKeywordAsync(string? keywordId, string? keywordName)
    {
        if (string.IsNullOrWhiteSpace(keywordId))
            return null;
        Keyword? Keyword = await GetKeywordAsync(keywordId: keywordId);
        if (Keyword == null)
        {
            string faKeyowrdName = await GetFa(keyowrdName: keywordName);
            Keyword = new Keyword { EnKeywordName = HtmlDecode.HtmlDecoding(keywordName.Trim()), Id = keywordId, FaKeywordName = faKeyowrdName };
            await _unitOfWork.Repository<Keyword>().AddAsync(Keyword);
            await _unitOfWork.CompleteAsync();
        }
        return Keyword;
    }
    private async Task<string> GetFa(string keyowrdName) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: keyowrdName));
    public async Task<Keyword?> GetKeywordAsync(string keywordId)
    {
        if (string.IsNullOrEmpty(keywordId))
            return null;
        return await _unitOfWork.Repository<Keyword>()
            .FindAsync(c => c.Id == keywordId);
    }
    public async Task<List<Keyword>?> GetKeywordFaNulllAsync() => await _unitOfWork.Repository<Keyword>()
            .GetAllListAsync(k => k.FaKeywordName == null);
    public async Task UpdateKeyword(List<Keyword>? keywords)
    {
        foreach (Keyword keyword in keywords)
            _unitOfWork.Repository<Keyword>().Update(keyword);
        if (keywords.Any())
            await _unitOfWork.CompleteAsync();
    }



}
