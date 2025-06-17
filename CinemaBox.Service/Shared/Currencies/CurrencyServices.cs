using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Strings;
using Microsoft.EntityFrameworkCore;

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
            await _unitOfWork.Repository<Currency>().AddAsync(Currency);
            await _unitOfWork.CompleteAsync();
        }
        return Currency;
    }
    public async Task<Currency?> GetCurrencyAsync(string CurrencyName)
    {
        if (string.IsNullOrWhiteSpace(CurrencyName))
            return null;

        string? nameToCompare = StringExtensions.NormalizeSafe(CurrencyName);
        if (string.IsNullOrEmpty(nameToCompare))
            return null;
        return await _unitOfWork.Repository<Currency>()
            .FindAsync(c =>c.CurrencyName.ToLower()== nameToCompare);
    }
}

