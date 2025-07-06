using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.People;
using CinemaBox.Scrapping.Interface.Imdb.Service.People;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.DateTimeExtension.DateExtensions;
using CinemaBox.Utilities.Html;

namespace CinemaBox.Service.Person.Peoples;
public class PeopleServices(
    IUnitOfWork unitOfWork,
    IImdbPeopleScrapperServices imdbPeopleScrapperServices,
    IDeathCauseServices deathCauseServices,
    IPeopleFileServices peopleFileServices,
    ITranslate translate) : IPeopleServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IImdbPeopleScrapperServices _imdbPeopleScrapperServices = imdbPeopleScrapperServices ?? throw new ArgumentNullException(nameof(imdbPeopleScrapperServices));
    private readonly IDeathCauseServices _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
    private readonly IPeopleFileServices _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<People> CreateOrUpdatePeople(CreditModel creditModel, string path)
    {
        People existingPerson = await GetPeople(creditModel.ImdbId);
        PeopleModelScrapping peopleModel;
        if (existingPerson == null)
        {
            peopleModel = await GetPeopleModelFromImdb(creditModel.ImdbId);
            existingPerson = await CreatePeopleEntity(peopleModel);
            if (!string.IsNullOrEmpty(creditModel.ImageUrl))
                await GetOrCreatePeopleFile(path: path, imageUrl: creditModel.ImageUrl, peopleId: existingPerson.Id, peopleName: existingPerson.EnFullName);
        }
        else if (existingPerson != null && existingPerson.UpdatedDate <= DateOnly.FromDateTime(DateTime.Today.AddYears(-1)))
        {
            peopleModel = await GetPeopleModelFromImdb(creditModel.ImdbId);
            if (peopleModel == null)
                return null;
            await UpdatePeopleEntity(existingPerson, peopleModel);
            await GetOrCreatePeopleFile(path: path, imageUrl: creditModel.ImageUrl, peopleId: existingPerson.Id, peopleName: existingPerson.EnFullName);
            return existingPerson;
        }
        return existingPerson;
    }
    public async Task<People> GetPeople(string peopleId) => await _unitOfWork.Repository<People>().FindAsync(x => x.Id == peopleId);
    private async Task<string> GetFa(string str) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: str));
    private async Task<PeopleModelScrapping> GetPeopleModelFromImdb(string imdbId) => await _imdbPeopleScrapperServices.ImdbPeopleScrapperServicesAsync(imdbId: imdbId);
    private async Task<People> CreatePeopleEntity(PeopleModelScrapping peopleModel)
    {
        DeathCause? deathCause = await DeathCause(deathCauseName: peopleModel.DeathCause);
        string faFullName = await GetFa(peopleModel.EnFullName);
        string faMiniBiography = await GetFa(peopleModel.EnMiniBiography);
        People people = new()
        {
            Id = peopleModel.ImdbId,
            EnFullName = peopleModel.EnFullName,
            NickName = peopleModel.NickName,
            BirthName = peopleModel.BirthName,
            BornPlace = peopleModel.BornPlace,
            EnMiniBiography = peopleModel.EnMiniBiography,
            Height = peopleModel?.Height,
            AddedDate = DateOnly.FromDateTime(DateTime.Today),
            UpdatedDate = DateOnly.FromDateTime(DateTime.Today),
            BornDate = Pcal.ToGeorgian(peopleModel.BornDate),
            DeathDate = !string.IsNullOrWhiteSpace(peopleModel?.DeathDate) ? Pcal.ToGeorgian(peopleModel.DeathDate) : null,
            DeathPlace = !string.IsNullOrWhiteSpace(peopleModel?.DeathPlace) ? peopleModel.DeathPlace : null,
            DeathCauseId = !string.IsNullOrWhiteSpace(deathCause?.EnDeathCauseName) ? deathCause.Id : null,
            FaFullName = faFullName,
            FaMiniBiography = faMiniBiography,
        };
        await _unitOfWork.Repository<People>().AddAsync(people);
        await _unitOfWork.CompleteAsync();
        return people;
    }
    private async Task<DeathCause?> DeathCause(string deathCauseName) => await _deathCauseServices.CreateOrGetDeathCauseAsync(deathCauseName: deathCauseName);
    private async Task UpdatePeopleEntity(People existing, PeopleModelScrapping model)
    {
        DeathCause deathCause = await DeathCause(deathCauseName: model.DeathCause);
        existing.FaFullName = await GetFa(existing.EnFullName);
        existing.FaMiniBiography = await GetFa(existing.EnMiniBiography);
        existing.EnFullName = model.EnFullName;
        existing.NickName = model.NickName;
        existing.BirthName = model.BirthName;
        existing.BornPlace = model.BornPlace;
        existing.DeathPlace = model.DeathPlace;
        existing.EnMiniBiography = model.EnMiniBiography;
        existing.Height = model.Height;
        existing.BornDate = Pcal.ToGeorgian(model.BornDate);
        existing.UpdatedDate = DateOnly.FromDateTime(DateTime.Today);
        existing.DeathDate = !string.IsNullOrWhiteSpace(model.DeathDate) ? Pcal.ToGeorgian(model.DeathDate) : null;
        existing.DeathPlace = !string.IsNullOrWhiteSpace(model.DeathPlace) ? model.DeathPlace : null;
        existing.DeathCauseId = !string.IsNullOrWhiteSpace(deathCause.EnDeathCauseName) ? deathCause.Id : null;
        _unitOfWork.Repository<People>().Update(existing);
        await _unitOfWork.CompleteAsync();
    }
    private async Task GetOrCreatePeopleFile(string path, string imageUrl, string peopleId, string peopleName) => await _peopleFileServices.CreateOrUpdatePeopleImage(path: path, imageUrl: imageUrl, peopleId: peopleId, peopleName: peopleName);
    public async Task<List<People>?> GetPeopleFaNull() => await _unitOfWork.Repository<People>()
         .GetAllListAsync(p => p.FaFullName == null);
    public async Task UpdateFaPeople(List<People> peoples)
    {
        foreach (People people in peoples)
            _unitOfWork.Repository<People>().Update(people);
        if (peoples.Any())
            await _unitOfWork.CompleteAsync();
    }


}