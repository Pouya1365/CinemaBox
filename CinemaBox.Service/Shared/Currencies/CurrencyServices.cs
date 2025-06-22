using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Strings;

namespace CinemaBox.Service.Shared.Currencies;

public class CurrencyServices(IUnitOfWork unitOfWork) : ICurrencyServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Currency?> CreateOrGetCurrencyAsync(string? currencyName)
    {
        if (string.IsNullOrWhiteSpace(currencyName))
            return null;
        Currency? Currency = await GetCurrencyAsync(currencyName);
        if (Currency == null)
        {
            Currency = new Currency { CurrencyName = currencyName.Trim() };
            await _unitOfWork.Repository<Currency>().AddAsync(Currency);
            await _unitOfWork.CompleteAsync();
        }
        return Currency;
    }
    public async Task<Currency?> GetCurrencyAsync(string currencyName)
    {
        if (string.IsNullOrWhiteSpace(currencyName))
            return null;

        string? nameToCompare = StringExtensions.NormalizeSafe(currencyName);
        if (string.IsNullOrEmpty(nameToCompare))
            return null;
        return await _unitOfWork.Repository<Currency>()
            .FindAsync(c =>c.CurrencyName.ToLower()== nameToCompare);
    }
    public async Task<Currency?> GetCurrencyAsync(byte? currencyId)
    {
        return await _unitOfWork.Repository<Currency>()
            .FindAsync(c => c.Id == currencyId);
    }
}

