using Ces.WinForm.UI.CesForm;
using Ces.WinForm.UI.CesMessageBox;
using CinemaBox.Domain.Division.CountryParts;
using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Domain.Shared.Keywords;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Libretranslate;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Presentation.Entertainment.Movies.EditMovie;
using CinemaBox.Scrapping.Imdb.MovieExtractors;
using CinemaBox.Scrapping.Interface.Imdb.Service.Movie;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Link.MovieFiles;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieKeywords;
using CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Interface.Managment.Link.UserMovieVideos;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.Service.Interface.Shared.Formats;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.Service.Interface.Shared.Qualities.Qualities;
using CinemaBox.Service.Interface.Shared.Qualities.QualityTypes;
using CinemaBox.Service.Interface.Shared.Statuses;
using CinemaBox.UserController.Entertainment.Movies;
using Microsoft.VisualBasic.Devices;
using System;
using System.Threading.Tasks;
namespace CinemaBox.Presentation;
public partial class Frm_Movie : CesForm
{
    private readonly IImdbMovieScrapperServices _imdbScrapperServices;
    private readonly IMovieServices _movieServices;
    private readonly IMovieCompanyServices _movieCompanyServices;
    private readonly IMovieCountryServices _movieCountryServices;
    private readonly IMovieGenreServices _movieGenreServices;
    private readonly IMovieSpokenLanguageServices _movieSpokenLanguageServices;
    private readonly IMovieTaglineServices _movieTaglineServices;
    private readonly IMovieLocationServices _movieLocationServices;
    private readonly IMovieKeywordServices _movieKeywordServices;
    private readonly IMovieCreditServices _movieCreditServices;
    private readonly IMovieFileServices _movieFileServices;
    private readonly ICurrencyServices _currencyServices;
    private readonly ICertificateServices _certificateServices;
    private readonly IPeopleFileServices _peopleFileServices;
    private readonly IPeopleServices _peopleServices;
    private readonly IUserMovieDiskServices _userMovieDiskServices;
    private readonly IUserMovieVideoServices _userMovieVideoServices;
    private readonly IStatusServices _statusesServices;
    private readonly IFormatServices _formatServices;
    private readonly IUserMovieAudioServices _userMovieAudioServices;
    private readonly ILanguageServices _languageServices;
    private readonly IUserMovieFileServices _userMovieFileServices;
    private readonly ICollectionServices _collectionServices;
    private readonly IQualityServices _qualityService;
    private readonly IQualityTypeServices _qualityTypeService;
    private readonly IImdbOtherScrapperServices _imdbOtherScrapperServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private readonly ITranslate? _translate;
    private readonly IKeywordServices? _keywordServices;
    private readonly IGenreServices? _genreServices;
    private readonly ICountryPartServices? _countryPartServices;
    public Frm_Movie(IImdbMovieScrapperServices imdbScrapperServices,
        IMovieServices movieServices,
        IMovieCompanyServices movieCompanyServices,
        IMovieCountryServices movieCountryServices,
        IMovieGenreServices movieGenreServices,
        IMovieSpokenLanguageServices movieSpokenLanguageServices,
        IMovieTaglineServices movieTaglineServices,
        IMovieLocationServices movieLocationServices,
        IMovieKeywordServices movieKeywordServices,
        IMovieCreditServices movieCreditServices,
        IMovieFileServices movieFileServices,
        ICurrencyServices currencyServices,
        ICertificateServices certificateServices,
        IPeopleFileServices peopleFileServices,
        IPeopleServices peopleServices,
        IUserMovieDiskServices userMovieDiskServices,
        IUserMovieVideoServices userMovieVideoServices,
        IStatusServices statusesServices,
        IFormatServices formatServices,
        IUserMovieAudioServices userMovieAudioServices,
        ILanguageServices languageServices,
        IUserMovieFileServices userMovieFileServices,
        ICollectionServices collectionServices,
        IQualityServices qualityService,
        IQualityTypeServices qualityTypeService,
        IImdbOtherScrapperServices imdbOtherScrapperServices,
        IDeathCauseServices? deathCauseServices,
        ITranslate? translate,
        IKeywordServices? keywordServices,
        IGenreServices? genreServices,
        ICountryPartServices? countryPartServices
        )
    {
        InitializeComponent();
        _imdbScrapperServices = imdbScrapperServices ?? throw new ArgumentNullException(nameof(imdbScrapperServices));
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _movieCompanyServices = movieCompanyServices ?? throw new ArgumentNullException(nameof(movieCompanyServices));
        _movieCountryServices = movieCountryServices ?? throw new ArgumentNullException(nameof(movieCountryServices));
        _movieGenreServices = movieGenreServices ?? throw new ArgumentNullException(nameof(movieGenreServices));
        _movieSpokenLanguageServices = movieSpokenLanguageServices ?? throw new ArgumentNullException(nameof(movieSpokenLanguageServices));
        _movieTaglineServices = movieTaglineServices ?? throw new ArgumentNullException(nameof(movieTaglineServices));
        _movieLocationServices = movieLocationServices ?? throw new ArgumentNullException(nameof(movieLocationServices));
        _movieKeywordServices = movieKeywordServices ?? throw new ArgumentNullException(nameof(movieKeywordServices));
        _movieCreditServices = movieCreditServices ?? throw new ArgumentNullException(nameof(movieCreditServices));
        _movieFileServices = movieFileServices ?? throw new ArgumentNullException(nameof(movieFileServices));
        _currencyServices = currencyServices ?? throw new ArgumentNullException(nameof(currencyServices));
        _certificateServices = certificateServices ?? throw new ArgumentNullException(nameof(certificateServices));
        _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _userMovieDiskServices = userMovieDiskServices ?? throw new ArgumentNullException(nameof(userMovieDiskServices));
        _userMovieVideoServices = userMovieVideoServices ?? throw new ArgumentNullException(nameof(userMovieVideoServices));
        _statusesServices = statusesServices ?? throw new ArgumentNullException(nameof(statusesServices));
        _formatServices = formatServices ?? throw new ArgumentNullException(nameof(formatServices));
        _userMovieAudioServices = userMovieAudioServices ?? throw new ArgumentNullException(nameof(userMovieAudioServices));
        _languageServices = languageServices ?? throw new ArgumentNullException(nameof(languageServices));
        _userMovieFileServices = userMovieFileServices ?? throw new ArgumentNullException(nameof(userMovieFileServices));
        _collectionServices = collectionServices ?? throw new ArgumentNullException(nameof(collectionServices));
        _qualityService = qualityService ?? throw new ArgumentNullException(nameof(qualityService));
        _qualityTypeService = qualityTypeService ?? throw new ArgumentNullException(nameof(qualityTypeService));
        _imdbOtherScrapperServices = imdbOtherScrapperServices ?? throw new ArgumentNullException(nameof(imdbOtherScrapperServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
        _translate = translate ?? throw new ArgumentNullException(nameof(translate));
        _keywordServices = keywordServices ?? throw new ArgumentNullException(nameof(keywordServices));
        _genreServices = genreServices ?? throw new ArgumentNullException(nameof(genreServices));
        _countryPartServices = countryPartServices ?? throw new ArgumentNullException(nameof(countryPartServices));
    }
    private async Task<Movie?> GetMovie() => await _movieServices.GeMovieAsync(ImdbId: Txt_Search.CesText);

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        if (Txt_Search.CesText is null)
            return;
        Movie? getMovie = await GetMovie();
        if (getMovie.EnTitle is not null)
            return;
        MovieModelScrapping movieModelScrapping = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);
        movieModelScrapping = await _imdbOtherScrapperServices.ImdbScrapperServicesAsync(movieModelScrapping);
        Movie movie = await _movieServices.CreateOrUpdate(model: movieModelScrapping);
        await _movieCompanyServices.CreateOrGetMovieCompanyAsync(movieId: Txt_Search.CesText, companieskeyValuePairs: movieModelScrapping.Companies);
        await _movieCountryServices.CreateOrGetMovieCountry(countryModels: movieModelScrapping.CountrieskeyValuePairs, movieId: Txt_Search.CesText);
        await _movieGenreServices.CreateOrGetMovieGenre(genreModels: movieModelScrapping.Genres, movieId: Txt_Search.CesText);
        await _movieSpokenLanguageServices.CreateOrGetMovieLanguage(LanguagekeyValuePairs: movieModelScrapping.SpokenLanguageskeyValuePairs, movieId: Txt_Search.CesText);
        await _movieTaglineServices.CreateMovieTagline(taglineModels: movieModelScrapping.Taglines, movieId: Txt_Search.CesText);
        await _movieLocationServices.CreateMovieLocation(locationModels: movieModelScrapping.Locations, movieId: Txt_Search.CesText);
        await _movieKeywordServices.CreateOrGetMovieKeyword(keywordkeyValuePairs: movieModelScrapping.KeywordskeyValuePairs, movieId: Txt_Search.CesText);
        string path = Application.StartupPath;
        await _movieCreditServices.CreateOrGetMovieCredit(creditModels: movieModelScrapping.Credits, path: path);
        string endYear = movie.EndYear != null ? @$"-{movie.EndYear}" : "";
        string movieName = $@"{movie.EnTitle}_{movie.StartYear}{endYear}";
        await _movieFileServices.CreateOrUpdateMovieImage(path: path, imageUrl: movieModelScrapping.ImageUrl, movieId: movie.Id, movieName: movieName);
        CesMessageBoxOptions cesMessageBoxOptions = new()
        {
            Buttons = CesMessageBoxButtonsEnum.Ok,
            Icon = CesMessageBoxIconEnum.MessageSuccess,
            Title = "پایان",
            Size = CesMessageBoxSizeEnum.Small
        };

        CesMessage.Show("عملیات با موفقیت به پایان رسید", cesMessageBoxOptions);
        LoadMovie();
    }

    private async void Frm_Movie_Load(object sender, EventArgs e)
    {
        await Languages();
        await Keywords();
        await DeathCauses();
        await Taglines();
        await Peoples();
        await Genres();
        await CountryPart();

        LoadMovie();
    }
 
    private async Task Languages()
    {
        List<Language>? languages = await GetLanguageAsync();

        foreach (Language language in languages)
            language.FaLanguageName = await _translate.TranslateText(text: language.EnLanguageName);
        await SaveFaLanguageAsync(languages);
    }
    private async Task Keywords()
    {

        List<Keyword>? keywords = await GetKeywordAsync();
        foreach (Keyword keyword in keywords)        
            keyword.FaKeyowrdName = await _translate.TranslateText(text: keyword.EnKeyowrdName);     
        await SaveFaKeywordAsync(keywords: keywords);
    }
    private async Task DeathCauses()
    {

        List<DeathCause>? deathCauses = await GetDeathCauseAsync();
        foreach (DeathCause deathCause in deathCauses)
            deathCause.FaDeathCauseName = await _translate.TranslateText(text: deathCause.EnDeathCauseName);
        await SaveFaDeathCauseAsync(deathCauses: deathCauses);
    }
    private async Task Taglines()
    {

        List<MovieTagline>? movieTaglines = await GetMovieTaglineAsync();
        foreach (MovieTagline movieTagline in movieTaglines)
            movieTagline.FaTagline = await _translate.TranslateText(text: movieTagline.EnTagline);
        await SaveFaMovieTaglineAsync(movieTaglines: movieTaglines);
    }
    private async Task Peoples()
    {
        List<People>? peoples = await GetPeopleAsync();
        foreach (People people in peoples)
        {
            people.FaFullName = await _translate.TranslateText(text: people.EnFullName);
            people.FaMiniBiography = await _translate.TranslateText(text: people.EnMiniBiography);
        }
        await SaveFaPeopleAsync(peoples: peoples);
    }
    private async Task Genres()
    {
        List<Genre>? genres = await GetGenreAsync();
        foreach (Genre genre in genres)
            genre.FaGenreName = await _translate.TranslateText(text: genre.EnGenreName);        
        await SaveFaGenreAsync(genres: genres);
    }
    private async Task CountryPart()
    {
        List<CountryPart>? countryParts = await GetCountryPartAsync();
        foreach (CountryPart countryPart in countryParts)
            countryPart.FaCountryPartName = await _translate.TranslateText(text: countryPart.EnCountryPartName);
        await SaveFaCountryPartAsync(countryParts: countryParts);
    }
    private async Task<List<Language>?> GetLanguageAsync() => await _languageServices.GetAllLanguageFaNull();
    private async Task SaveFaLanguageAsync(List<Language> languages) => await _languageServices.UpdateFaLanguge(languages: languages);

    private async Task<List<Keyword>?> GetKeywordAsync() => await _keywordServices.GetKeywordFaNulllAsync();
    private async Task SaveFaKeywordAsync(List<Keyword> keywords) => await _keywordServices.UpdateKeyword(keywords: keywords);

    private async Task<List<DeathCause>?> GetDeathCauseAsync() => await _deathCauseServices.GetAllDeathCauseFaNull();
    private async Task SaveFaDeathCauseAsync(List<DeathCause> deathCauses) => await _deathCauseServices.UpdateFaDeathCause(deathCauses: deathCauses);

    private async Task<List<MovieTagline>?> GetMovieTaglineAsync() => await _movieTaglineServices.GetAllMovieTaglineFaNull();
    private async Task SaveFaMovieTaglineAsync(List<MovieTagline> movieTaglines) => await _movieTaglineServices.UpdateFaMovieTagline(movieTaglines: movieTaglines);

    private async Task<List<People>?> GetPeopleAsync() => await _peopleServices.GetPeopleFaNull();
    private async Task SaveFaPeopleAsync(List<People> peoples) => await _peopleServices.UpdateFaPeople(peoples: peoples);

    private async Task<List<Genre>?> GetGenreAsync() => await _genreServices.GetAllGenreFaNull();
    private async Task SaveFaGenreAsync(List<Genre> genres) => await _genreServices.UpdateFaGenre(genres: genres);


    private async Task<List<CountryPart>?> GetCountryPartAsync() => await _countryPartServices.GetAllCountryPartFaNull();
    private async Task SaveFaCountryPartAsync(List<CountryPart> countryParts) => await _countryPartServices.UpdateFaCountryPart(countryParts: countryParts);



    private async void LoadMovie()
    {
        Flw_ShowMovie.Controls.Clear();
        List<ShowMovieModel> movieModels = await GetMovieModels();
        List<ShowMovieIcon> ShowMovieIcons = [];
        ShowMovieIcons.AddRange(from movie in movieModels
                                let control = new ShowMovieIcon(
            posterPath: Path.Combine(Application.StartupPath, movie.PosterPath),
            enTitle: movie.EnTitle,
            faTitle: movie.FaTitle,
            year: (long)movie.StartYear,
            endYear: movie.EndYear, movieId: movie.MovieId)
                                select AttachHandler(control));
        ShowMovieIcon AttachHandler(ShowMovieIcon ctrl)
        {
            ctrl.PosterClicked += MovieBox_PosterClicked;
            return ctrl;
        }
        Flw_ShowMovie.Controls.AddRange([.. ShowMovieIcons]);
    }
    private async Task<List<ShowMovieModel>> GetMovieModels() => await _movieServices.GetMovieModelsAsync(search: Txt_Search.CesText);
    private void MovieBox_PosterClicked(object sender, string movieId)
    {
        Frm_EditFormMovie frm_EditForm = new(
            movieServices: _movieServices,
            movieId: movieId,
            currencyServices: _currencyServices,
            movieGenreServices: _movieGenreServices,
            movieCountryServices: _movieCountryServices,
            movieSpokenLanguageServices: _movieSpokenLanguageServices,
            movieCompanyServices: _movieCompanyServices,
            movieLocationServices: _movieLocationServices,
            movieKeywordServices: _movieKeywordServices,
            movieTaglineServices: _movieTaglineServices,
            certificateServices: _certificateServices,
            movieFileServices: _movieFileServices,
            movieCreditServices: _movieCreditServices,
            peopleFileServices: _peopleFileServices,
            peopleServices: _peopleServices,
            userMovieDiskServices: _userMovieDiskServices,
            userMovieVideoServices: _userMovieVideoServices,
            statusesServices: _statusesServices,
            formatServices: _formatServices,
            userMovieAudioServices: _userMovieAudioServices,
            languageServices: _languageServices,
            userMovieFileServices: _userMovieFileServices,
            collectionServices: _collectionServices,
            qualityServices: _qualityService,
            qualityTypeServices: _qualityTypeService,
            deathCauseServices: _deathCauseServices

            );
        frm_EditForm.ShowDialog();
    }

    private void Btn_Search_Click(object sender, EventArgs e)
    {
        LoadMovie();
    }
}