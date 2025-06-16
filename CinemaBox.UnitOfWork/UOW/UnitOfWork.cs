using CinemaBox.Context.AppDbContext;
using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Division.CountryPartTypes;
using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Domain.Entertainment.CreditTypes;
using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Entertainment.Link.MovieFiles;
using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Entertainment.Link.MovieLocations;
using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Domain.Servers.ServerTypes;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Domain.Users.Users;
using CinemaBox.Repository.BaseRepository;
using CinemaBox.Repository.Interface.BaseRepository;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.UnitOfWork.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly CinemaBoxDbContext _context;

    // استفاده از DI به جای ایجاد نمونه به صورت دستی
    public IGenericRepository<Certificate> Certificates { get; }
    public IGenericRepository<Movie> Movies { get; }
    public IGenericRepository<People> Peoples { get; }
    public IGenericRepository<ServerType> ServerTypes { get; }
    public IGenericRepository<Server> Servers { get; }
    public IGenericRepository<Domain.Files.Files.File> Files { get; }
    public IGenericRepository<PeopleFile> PeopleFiles { get; }
    public IGenericRepository<CreditType> CreditTypes { get; }
    public IGenericRepository<MovieCredit> MovieCredits { get; }
    public IGenericRepository<DeathCause> DeathCauses { get; }
    public IGenericRepository<MovieFile> MovieFiles { get; }
    public IGenericRepository<Currency> Currencies { get; }
    public IGenericRepository<Company> Companies { get; }
    public IGenericRepository<MovieCompany> MovieCompanies { get; }
    public IGenericRepository<CountryPartType> CountryPartTypes { get; }
    public IGenericRepository<CountryPart> CountryParts { get; }
    public IGenericRepository<MovieCountry> MovieCountries { get; }
    public IGenericRepository<Genre> Genres { get; }
    public IGenericRepository<MovieGenre> MovieGenres { get; }
    public IGenericRepository<MovieLocation> MovieLocations { get; }
    public IGenericRepository<Language> Languages { get; }
    public IGenericRepository<MovieSpokenLanguage> MovieSpokenLanguages { get; }
    public IGenericRepository<MovieTagline> MovieTaglines { get; }
    public IGenericRepository<Keyword> Keywords { get; }
    public IGenericRepository<MovieKeyword> MovieKeywords { get; }
    public IGenericRepository<Format> Formats { get; }
    public IGenericRepository<UserMovieVideo> UserMovieVideos { get; }
    public IGenericRepository<UserMovieAudio> UserMovieAudios { get; }
    public IGenericRepository<UserMovieDisk> UserMovieDisks { get; }
    public IGenericRepository<Collection> Collections { get; }
    public IGenericRepository<User> Users { get; }
    // استفاده از یک دیکشنری برای ذخیره کردن repositoryها
    private readonly Dictionary<Type, object> _repositories;
    public UnitOfWork(CinemaBoxDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>
        {
            { typeof(Certificate), new GenericRepository<Certificate>(_context) },
            { typeof(Movie), new GenericRepository<Movie>(_context) },
            { typeof(People), new GenericRepository<People>(_context) },
            { typeof(ServerType), new GenericRepository<ServerType>(_context) },
            { typeof(Server), new GenericRepository<Server>(_context) },
            { typeof(Domain.Files.Files.File), new GenericRepository<Domain.Files.Files.File>(_context) },
            { typeof(PeopleFile), new GenericRepository<PeopleFile>(_context) },
            { typeof(CreditType), new GenericRepository<CreditType>(_context) },
            { typeof(MovieCredit), new GenericRepository<MovieCredit>(_context) },
            { typeof(DeathCause), new GenericRepository<DeathCause>(_context) },
            { typeof(MovieFile), new GenericRepository<MovieFile>(_context) },
            { typeof(Currency), new GenericRepository<Currency>(_context) },
            { typeof(Company), new GenericRepository<Company>(_context) },
            { typeof(MovieCompany), new GenericRepository<MovieCompany>(_context) },
            { typeof(CountryPartType), new GenericRepository<CountryPartType>(_context) },
            { typeof(CountryPart), new GenericRepository<CountryPart>(_context) },
            { typeof(MovieCountry), new GenericRepository<MovieCountry>(_context) },
            { typeof(Genre), new GenericRepository<Genre>(_context) },
            { typeof(MovieGenre), new GenericRepository<MovieGenre>(_context) },
            { typeof(MovieLocation), new GenericRepository<MovieLocation>(_context) },
            { typeof(Language), new GenericRepository<Language>(_context) },
            { typeof(MovieSpokenLanguage), new GenericRepository<MovieSpokenLanguage>(_context) },
            { typeof(MovieTagline), new GenericRepository<MovieTagline>(_context) },
            { typeof(Keyword), new GenericRepository<Keyword>(_context) },
            { typeof(MovieKeyword), new GenericRepository<MovieKeyword>(_context) },
            { typeof(Format), new GenericRepository<Format>(_context) },
            { typeof(UserMovieVideo), new GenericRepository<UserMovieVideo>(_context) },
            { typeof(UserMovieAudio), new GenericRepository<UserMovieAudio>(_context) },
            { typeof(UserMovieDisk), new GenericRepository<UserMovieDisk>(_context) },
            { typeof(Collection), new GenericRepository<Collection>(_context) },
            { typeof(User), new GenericRepository<User>(_context) }
        };
    }
    // متد برای دسترسی به هر Repository
    public IGenericRepository<T> Repository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
            return (IGenericRepository<T>)_repositories[typeof(T)];
        GenericRepository<T> repository = new GenericRepository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }
    // متد Complete برای ذخیره‌سازی
    public async Task<int> CompleteAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // در اینجا می‌توانید خطاها را لاگ کنید
            throw new Exception("Error during saving changes", ex);
        }
    }
    public void Dispose() =>
        _context.Dispose();

}

