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
using CinemaBox.Repository.Interface.BaseRepository;

namespace CinemaBox.UnitOfWork.Interface.UOW;

public interface IUnitOfWork
{
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
    Task<int> CompleteAsync();

}
