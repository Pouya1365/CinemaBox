using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Shared.Currencies;

public class CurrencyServices(IUnitOfWork unitOfWork) : ICurrencyServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Currency?> CreateOrGetCurrencyAsync(string? CurrencyName)
    {
        if (string.IsNullOrWhiteSpace(CurrencyName))
            return null;
        var Currency = await GetCurrencyAsync(CurrencyName);
        if (Currency == null)
        {
            Currency = new Currency { CurrencyName = CurrencyName.Trim() };
            await _unitOfWork.Currencies.AddAsync(Currency);
            await _unitOfWork.CompleteAsync();
        }
        return Currency;
    }
    public async Task<Currency?> GetCurrencyAsync(string CurrencyName)
    {
        if (string.IsNullOrWhiteSpace(CurrencyName))
            return null;
        return await _unitOfWork.Currencies
            .FindAsync(c => c.CurrencyName != null &&
                       c.CurrencyName.Equals(CurrencyName.Trim(), StringComparison.OrdinalIgnoreCase));
    }
}

