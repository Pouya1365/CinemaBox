using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Enums;

namespace CinemaBox.Service.Entertainment.Link.MovieCredits;

public class MovieCreditServices(IUnitOfWork unitOfWork, IPeopleServices peopleServices) : IMovieCreditServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IPeopleServices _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
    public async Task<List<MovieCredit>> CreateOrGetMovieCredit(List<CreditModel> creditModels, string path)
    {
        List<MovieCredit> movieCredits = [];
        foreach (var creditModel in creditModels)
        {
            People people = await GetOrCreatePeople(creditModel: creditModel, path: path);
            if (people != null)
            {
                byte creditTypeId = 0;
                if (EnumExtension.TryGetEnumNumericValue<CreditEnumeration>(creditModel.CreditType, out int value))
                    creditTypeId = byte.Parse(value.ToString());
                movieCredits.Add(new MovieCredit
                {
                    MovieId = creditModel.MovieId,
                    RoleName = creditModel.Role,
                    PeopleId = people.Id,
                    IsLead = creditModel.IsLead,
                    CreditTypeId = creditTypeId,
                });
            }
        }
        await _unitOfWork.Repository<MovieCredit>().AddRangeAsync(movieCredits);
        await _unitOfWork.CompleteAsync();
        return movieCredits;
    }
    private async Task<People> GetOrCreatePeople(CreditModel creditModel, string path) => await _peopleServices.CreateOrUpdatePeople(creditModel: creditModel, path: path);
}
