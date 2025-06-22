using CinemaBox.Domain.Shared.Currencies;

namespace CinemaBox.Service.Interface.Shared.Currencies;

public interface ICurrencyServices
{
    Task<Currency?> CreateOrGetCurrencyAsync(string? CurrencyName);
    Task<Currency?> GetCurrencyAsync(string CurrencyName);
    Task<Currency?> GetCurrencyAsync(byte? currencyId);
}
