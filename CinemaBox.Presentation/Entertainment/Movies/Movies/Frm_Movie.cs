using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Presentation.Entertainment.Movies.EditMovie;
using CinemaBox.Scrapping.Interface.Imdb.Service.Movie;
using CinemaBox.Service.Interface.Entertainment.Certificates;
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
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieVideos;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UserController.Entertainment.Movies;
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
        IUserMovieVideoServices userMovieVideoServices
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
    }

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        MovieModelScrapping movieModelScrapping = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);
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
    }

    private void Frm_Movie_Load(object sender, EventArgs e)
    {
        LoadMovie(null);
    }
    private async void LoadMovie(string search)
    {

        List<ShowMovieModel> movieModels =await GetMovieModels();
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
    private async Task<List<ShowMovieModel>>GetMovieModels()=> await _movieServices.GetMovieModelsAsync(null);
    private void MovieBox_PosterClicked(object sender, string movieId)
    {
        Frm_EditFormMovie frm_EditForm =new(
            movieServices: _movieServices,
            movieId:movieId,
            currencyServices: _currencyServices,
            movieGenreServices: _movieGenreServices,
            movieCountryServices:_movieCountryServices,
            movieSpokenLanguageServices:_movieSpokenLanguageServices,
            movieCompanyServices:_movieCompanyServices,
            movieLocationServices:_movieLocationServices,
            movieKeywordServices:_movieKeywordServices,
            movieTaglineServices:_movieTaglineServices,
            certificateServices:_certificateServices,
            movieFileServices:_movieFileServices,
            movieCreditServices:_movieCreditServices,
            peopleFileServices:_peopleFileServices,
            peopleServices:_peopleServices,
            userMovieDiskServices:_userMovieDiskServices,
            userMovieVideoServices:_userMovieVideoServices
            
            );
        frm_EditForm.ShowDialog();
    }
}