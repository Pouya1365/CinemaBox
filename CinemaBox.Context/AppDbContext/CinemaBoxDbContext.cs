using CinemaBox.Configuration.Division.CountryParts;
using CinemaBox.Configuration.Division.CountryPartTypes;
using CinemaBox.Configuration.Entertainment.Certificates;
using CinemaBox.Configuration.Entertainment.Collections;
using CinemaBox.Configuration.Entertainment.Coroprations;
using CinemaBox.Configuration.Entertainment.Link.MovieCompanies;
using CinemaBox.Configuration.Entertainment.Link.MovieCountries;
using CinemaBox.Configuration.Entertainment.Movies;
using CinemaBox.Configuration.Files.Files;
using CinemaBox.Configuration.Person.Peoples;
using CinemaBox.Configuration.Servers.Servers;
using CinemaBox.Configuration.Servers.ServerTypes;
using CinemaBox.Configuration.Shared.Currencies;
using CinemaBox.Configuration.Shared.DeathCauses;
using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Division.CountryPartTypes;
using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Domain.Entertainment.Coropration;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Domain.Servers.ServerTypes;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Domain.Shared.DeathCauses;
using Microsoft.EntityFrameworkCore;

namespace CinemaBox.Context.AppDbContext;


public class CinemaBoxDbContext(DbContextOptions<CinemaBoxDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<MovieCompany> MovieCompanies { get; set; }
    public DbSet<CountryPartType> CountryPartTypes { get; set; }
    public DbSet<CountryPart> CountryParts { get; set; }
    public DbSet<MovieCountry> MovieCountries { get; set; }
    public DbSet<People> Peoples { get; set; }
    public DbSet<DeathCause> DeathCauses { get; set; }
    public DbSet<ServerType> ServerTypes { get; set; }
    public DbSet<Server> Servers { get; set; }
    public DbSet<Domain.Files.Files.File> Files { get; set; }
    //public DbSet<PeopleFile> PeopleFiles { get; set; }
    //public DbSet<CreditType> CreditTypes { get; set; }
    //public DbSet<MovieCredit> MovieCredits { get; set; }
    //
    //public DbSet<MovieFile> MovieFiles { get; set; }
    //
    //
    //public DbSet<Genre> Genres { get; set; }
    //public DbSet<MovieGenre> MovieGenres { get; set; }
    //public DbSet<MovieLocation> MovieLocations { get; set; }
    //public DbSet<Language> Languages { get; set; }
    //public DbSet<MovieSpokenLanguage> MovieSpokenLanguages { get; set; }
    //public DbSet<MovieTagline> MovieTaglines { get; set; }
    //public DbSet<Keyword> Keywords { get; set; }
    //public DbSet<MovieKeyword> MovieKeywords { get; set; }
    //public DbSet<Format> Formats { get; set; }
    //public DbSet<UserMovieVideo> UserMovieVideos { get; set; }
    //public DbSet<UserMovieAudio> UserMovieAudios { get; set; }
    //public DbSet<UserMovieDisk> UserMovieDisks { get; set; }
    //

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SD5KJ4K;Database=TvTime;Trusted_Connection=True;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
        modelBuilder.ApplyConfiguration(new CollectionConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new MovieCompanyConfiguration());
        modelBuilder.ApplyConfiguration(new CountryPartTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CountryPartConfiguration());
        modelBuilder.ApplyConfiguration(new MovieCountryConfiguration());
        modelBuilder.ApplyConfiguration(new PeopleConfiguration());
        modelBuilder.ApplyConfiguration(new DeathCauseConfiguration());
        modelBuilder.ApplyConfiguration(new ServerTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ServerConfiguration());
        modelBuilder.ApplyConfiguration(new FileConfiguration());
        //modelBuilder.ApplyConfiguration(new PeopleFileConfiguration());
        //modelBuilder.ApplyConfiguration(new CreditTypeConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieCreditCounfiguration());
        //
        //modelBuilder.ApplyConfiguration(new MovieFileConfiguration());
        //
        //
        //modelBuilder.ApplyConfiguration(new GenreConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieLocationConfiguration());
        //modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieSpokenLanguageConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieTaglineConfiguration());
        //modelBuilder.ApplyConfiguration(new KeywordConfiguration());
        //modelBuilder.ApplyConfiguration(new MovieKeywordConfiguration());
        //modelBuilder.ApplyConfiguration(new FormatConfiguration());
        //modelBuilder.ApplyConfiguration(new UserMovieVideoConfiguration());
        //modelBuilder.ApplyConfiguration(new UserMovieAudioConfiguration());
        //modelBuilder.ApplyConfiguration(new UserMovieDiskConfiguration());
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaBoxDbContext).Assembly);
    }

}