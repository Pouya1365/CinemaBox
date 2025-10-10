using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Statestics;
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
            byte creditTypeId = 0;
            if (EnumExtension.TryGetEnumNumericValue<CreditEnumeration>(creditModel.CreditType, out int value))
                creditTypeId = byte.Parse(value.ToString());
            if (!movieCredits.Any(x => x.PeopleId == people.Id && x.CreditTypeId == creditTypeId))
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
    public async Task<List<string>> GetPeopleMovie(string peopleId)
    {
        IEnumerable<MovieCredit> movieCredit = await _unitOfWork.Repository<MovieCredit>().GetAllAsync(X => X.PeopleId == peopleId);
        return [.. movieCredit.Select(x => x.MovieId)];
    }
    public async Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel)
    {
        IEnumerable<MovieCredit> getCredit = await _unitOfWork.Repository<MovieCredit>().GetAllAsync();
        statesticsModel.ActorsTotalCount = getCredit.Where(x => x.CreditTypeId == (int)CreditEnumeration.Cast).Distinct().Count();
        statesticsModel.DirectorsTotalCount = getCredit.Where(x => x.CreditTypeId == (int)CreditEnumeration.Director).Distinct().Count();
        statesticsModel.WritersTotalCount = getCredit.Where(x => x.CreditTypeId == (int)CreditEnumeration.Writer).Distinct().Count();
        statesticsModel.ProducerTotalCount = getCredit.Where(x => x.CreditTypeId == (int)CreditEnumeration.Producer).Distinct().Count();
        return statesticsModel;
    }
    public async Task<IEnumerable<MovieCredit>> GetMaxCrews()
    {
        IEnumerable<MovieCredit> result = await _unitOfWork.Repository<MovieCredit>()
       .GetAllWithIncludesAsync(x => x.CreditType, x => x.People, x => x.People.PeopleFiles);


        // گام 1: شمارش حضور هر فرد در هر گروه
        var creditCounts = result
            .GroupBy(mc => new { mc.CreditTypeId, mc.PeopleId })
            .Select(g => new
            {
                g.Key.CreditTypeId,
                g.Key.PeopleId,
                CreditCount = g.Count()
            })
            .ToList();

        // گام 2: انتخاب یک نفر با بیشترین تعداد در هر گروه (با استفاده از GroupBy + OrderByDescending)
        var topPeoplePerCreditType = creditCounts
            .GroupBy(x => x.CreditTypeId)
            .Select(g => g
                .OrderByDescending(x => x.CreditCount)
                .First()) // فقط یکی برمی‌گردونه (مثل ROW_NUMBER = 1)
            .ToList();
        var keyTuples = topPeoplePerCreditType
     .Where(tp => tp.PeopleId != null)
     .Select(tp => (tp.CreditTypeId, tp.PeopleId))
     .ToList();

        HashSet<(byte CreditTypeId, string PeopleId)> topPeopleSet = [.. keyTuples];


        List<MovieCredit> finalCredits = [.. result
            .Where(mc => topPeopleSet.Contains((mc.CreditTypeId, mc.PeopleId))).DistinctBy(x =>new { x.PeopleId,x.CreditTypeId})];

        return finalCredits;

    }
}
