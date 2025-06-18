using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Service;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Movies;
namespace CinemaBox.Presentation;
public partial class Form1 : CesForm
{
    private readonly IImdbMovieScrapperServices _imdbScrapperServices;
    private readonly IMovieServices _movieServices;
    private readonly IMovieCompanyServices _movieCompanyServices;
    private readonly IMovieCountryServices _movieCountryServices;
    private readonly IMovieGenreServices _movieGenreServices;
    private readonly IMovieSpokenLanguageServices _movieSpokenLanguageServices;
    public Form1(IImdbMovieScrapperServices imdbScrapperServices,
        IMovieServices movieServices,
        IMovieCompanyServices movieCompanyServices,
        IMovieCountryServices movieCountryServices,
        IMovieGenreServices movieGenreServices,
         IMovieSpokenLanguageServices movieSpokenLanguageServices
        )
    {
        InitializeComponent();
        _imdbScrapperServices = imdbScrapperServices ?? throw new ArgumentNullException(nameof(imdbScrapperServices));
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _movieCompanyServices = movieCompanyServices ?? throw new ArgumentNullException(nameof(movieCompanyServices));
        _movieCountryServices = movieCountryServices ?? throw new ArgumentNullException(nameof(movieCountryServices));
        _movieGenreServices = movieGenreServices ?? throw new ArgumentNullException(nameof(movieGenreServices));
        _movieSpokenLanguageServices = movieSpokenLanguageServices ?? throw new ArgumentNullException(nameof(movieSpokenLanguageServices));
    }

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        MovieModelScrapping movieModelScrapping = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);
        Movie movie = await _movieServices.CreateOrUpdate(model: movieModelScrapping);
        await _movieCompanyServices.CreateOrGetMovieCompanyAsync(movieId: Txt_Search.CesText, companieskeyValuePairs: movieModelScrapping.Companies);
        await _movieCountryServices.CreateOrGetMovieCountry(countryModels: movieModelScrapping.CountrieskeyValuePairs, movieId: Txt_Search.CesText);
        await _movieGenreServices.CreateOrGetMovieGenre(genreModels: movieModelScrapping.Genres, movieId: Txt_Search.CesText);
        await _movieSpokenLanguageServices.CreateOrGetMovieLanguage(LanguagekeyValuePairs:movieModelScrapping.SpokenLanguageskeyValuePairs, movieId: Txt_Search.CesText);
    }
}
