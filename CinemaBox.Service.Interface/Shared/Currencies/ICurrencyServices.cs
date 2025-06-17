using CinemaBox.Domain.Shared.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBox.Service.Interface.Shared.Currencies
{
    public interface ICurrencyServices
    {
        Task<Currency?> CreateOrGetCurrencyAsync(string? CurrencyName);
        Task<Currency?> GetCurrencyAsync(string CurrencyName);
    }
}
