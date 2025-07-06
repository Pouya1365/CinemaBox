using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;
using CinemaBox.Utilities.Strings;

namespace CinemaBox.Service.Shared.DeathCauses;

public class DeathCauseServices(IUnitOfWork unitOfWork, ITranslate translate) : IDeathCauseServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<DeathCause?> CreateOrGetDeathCauseAsync(string? deathCauseName)
    {
        if (string.IsNullOrWhiteSpace(deathCauseName))
            return null;
        DeathCause? deathCause = await GetDeathCauseAsync(deathCauseName: deathCauseName);
        if (deathCause == null)
        {
            string faDeathCauseName = await GetFa(deathCause: deathCauseName);
            deathCause = new DeathCause { EnDeathCauseName = deathCauseName,FaDeathCauseName=faDeathCauseName };
            await _unitOfWork.Repository<DeathCause>().AddAsync(deathCause);
            await _unitOfWork.CompleteAsync();
        }
        return deathCause;
    }
    private async Task<string> GetFa(string deathCause) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: deathCause));
    public async Task<DeathCause?> GetDeathCauseAsync(string deathCauseName)
    {
        if (string.IsNullOrEmpty(deathCauseName))
            return null;
        string? normal = StringExtensions.NormalizeSafe(deathCauseName);
        return await _unitOfWork.Repository<DeathCause>()
            .FindAsync(c => c.EnDeathCauseName.ToLower() == deathCauseName);
    }
    public async Task<IEnumerable<DeathCause>?> GetDeathCauseAllAsync() => await _unitOfWork.Repository<DeathCause>()
            .GetAllAsync();

    public async Task<List<DeathCause>?> GetAllDeathCauseFaNull() => await _unitOfWork.Repository<DeathCause>()
         .GetAllListAsync(dc=> dc.FaDeathCauseName == null);
    public async Task UpdateFaDeathCause(List<DeathCause> deathCauses)
    {
        foreach (DeathCause deathCause in deathCauses)
            _unitOfWork.Repository<DeathCause>().Update(deathCause);
        if (deathCauses.Any())
            await _unitOfWork.CompleteAsync();
    }
}