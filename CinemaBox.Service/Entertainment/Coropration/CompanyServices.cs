using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Service.Interface.Entertainment.Coropration;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Coropration;

public class CompanyServices(IUnitOfWork unitOfWork) : ICompanyServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Company?> CreateOrGetCompanyAsync(string companyId,string? CompanyName)
    {
        if (string.IsNullOrWhiteSpace(companyId))
            return null;
        Company? Company = await GetCompanyAsync(companyId);
        if (Company == null)
        {
            Company = new Company { Id= companyId, EnCompanyName = CompanyName.Trim() };
            await _unitOfWork.Repository<Company>().AddAsync(Company);
            await _unitOfWork.CompleteAsync();
        }
        return Company;
    }
    public async Task<Company?> GetCompanyAsync(string companyId)
    {
        if (string.IsNullOrWhiteSpace(companyId))
            return null;
        return await _unitOfWork.Repository<Company>()
            .FindAsync(c => c.Id == companyId);

    }
}
