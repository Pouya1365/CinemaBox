using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Coropration;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.UnitOfWork.Interface.UOW;
using System.Threading.Tasks;

namespace CinemaBox.Service.Entertainment.Link.MovieCompanies;

public class MovieCompanyServices(IUnitOfWork unitOfWork, ICompanyServices companyServices) : IMovieCompanyServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ICompanyServices _companyServices = companyServices ?? throw new ArgumentNullException(nameof(companyServices));
    public async Task<bool?> CreateOrGetMovieCompanyAsync(string movieId, Dictionary<string, string>? companieskeyValuePairs)
    {
        if (string.IsNullOrWhiteSpace(movieId))
            return null;
        List<MovieCompany> movieCompanies = [];
        foreach (KeyValuePair<string, string> companykeyValuePairs in companieskeyValuePairs)
        {
            Company? company = await GetCompany(companyId: companykeyValuePairs.Key, companyName: companykeyValuePairs.Value);
            if (company == null)
                return false;
            MovieCompany? MovieCompany = await GetMovieCompanyAsync(movieId: movieId,companyId: company.Id);
            if (MovieCompany == null)
            {
                movieCompanies.Add( new MovieCompany { CompanyId = company.Id, MovieId = movieId });
              
            }
        }
        await _unitOfWork.Repository<MovieCompany>().AddRangeAsync(movieCompanies);
        await _unitOfWork.CompleteAsync();
        return true;
    }
    public async Task<MovieCompany?> GetMovieCompanyAsync(string movieId, string companyId)
    {
        if (string.IsNullOrWhiteSpace(movieId))
            return null;
        if (string.IsNullOrWhiteSpace(companyId))
            return null;
        return await _unitOfWork.Repository<MovieCompany>()
            .FindAsync(mc => mc.MovieId == movieId && mc.CompanyId == companyId);

    }
    public async Task<Company?> GetCompany(string companyId, string companyName) => await _companyServices.CreateOrGetCompanyAsync(companyId: companyId, CompanyName: companyName);
}