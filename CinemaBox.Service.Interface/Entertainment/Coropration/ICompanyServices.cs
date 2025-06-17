using CinemaBox.Domain.Entertainment.Coropration;

namespace CinemaBox.Service.Interface.Entertainment.Coropration;

public interface ICompanyServices
{
    Task<Company?> CreateOrGetCompanyAsync(string companyId, string? CompanyName);
    Task<Company?> GetCompanyAsync(string companyId);
}
