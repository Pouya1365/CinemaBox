using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Strings;

namespace CinemaBox.Service.Shared.DeathCauses;

public class DeathCauseServices(IUnitOfWork unitOfWork) : IDeathCauseServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<DeathCause?> CreateOrGetDeathCauseAsync(string? deathCauseName)
    {
        if (string.IsNullOrWhiteSpace(deathCauseName))
            return null;
        DeathCause? deathCause = await GetDeathCauseAsync(deathCauseName: deathCauseName);
        if (deathCause == null)
        {
            deathCause = new DeathCause { EnDeathCauseName = deathCauseName };
            await _unitOfWork.Repository<DeathCause>().AddAsync(deathCause);
            await _unitOfWork.CompleteAsync();
        }
        return deathCause;
    }
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