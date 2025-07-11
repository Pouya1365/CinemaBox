using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast.Credit;
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
        IEnumerable<People> peoples = await GetAllPeople();
        Dictionary<string, People> peopleDict = peoples.ToDictionary(x => x.Id, x => x);
        foreach (var creditModel in creditModels)
        {
            People people;
            if (!peopleDict.TryGetValue(creditModel.ImdbId, out People? existingPerson) ||
          existingPerson.UpdatedDate <= DateOnly.FromDateTime(DateTime.Today.AddYears(-1)))            
                people = await GetOrCreatePeople(creditModel, path);            
            else            
                people = existingPerson;          
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
        await _unitOfWork.Repository<MovieCredit>().AddRangeAsync(movieCredits);
        await _unitOfWork.CompleteAsync();
        return movieCredits;
    }
    private async Task<People> GetOrCreatePeople(CreditModel creditModel, string path) => await _peopleServices.CreateOrUpdatePeople(creditModel: creditModel, path: path);
    private async Task<IEnumerable<People>> GetAllPeople() => await _peopleServices.GetAllPeoplel();
    public async Task<IEnumerable<MovieCredit>> GetMovieCreditsAsync(string movieId) => await _unitOfWork.Repository<MovieCredit>().GetAllWithPredicateAsync(x => x.MovieId == movieId, x => x.CreditType, x => x.People, x => x.People.PeopleFiles);
    public async Task<bool> ChangeIsLeadRole(string peopleId, string movieId)
    {
        MovieCredit movieCredit = await _unitOfWork.Repository<MovieCredit>().FindAsync(x => x.PeopleId == peopleId && x.MovieId == movieId);
        if (movieCredit == null) return false;
        movieCredit.IsLead = !(movieCredit.IsLead ?? false);
        _unitOfWork.Repository<MovieCredit>().Update(movieCredit);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
