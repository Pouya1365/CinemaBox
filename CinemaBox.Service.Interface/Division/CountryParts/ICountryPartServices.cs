using CinemaBox.Domain.Division.CountryParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBox.Service.Interface.Division.CountryParts
{
   public interface ICountryPartServices
    {
        Task<CountryPart> CreateOrGetCountryPart(string CountryPartName, string isoCode);
        Task<CountryPart> GetCountryPart(string CountryPartName);
    }
}
