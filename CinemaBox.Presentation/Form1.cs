using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Service;
using CinemaBox.Service.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Movies;
namespace CinemaBox.Presentation;
public partial class Form1 : CesForm
{
    private readonly IImdbMovieScrapperServices _imdbScrapperServices;
    private readonly IMovieServices _movieServices;
    private readonly IMovieCompanyServices _movieCompanyServices;
    private readonly IMovieCountryServices _movieCountryServices;
    public Form1(IImdbMovieScrapperServices imdbScrapperServices,
        IMovieServices movieServices,
        IMovieCompanyServices movieCompanyServices,
        IMovieCountryServices movieCountryServices)
    {
        InitializeComponent();
        _imdbScrapperServices = imdbScrapperServices ?? throw new ArgumentNullException(nameof(imdbScrapperServices));
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _movieCompanyServices = movieCompanyServices ?? throw new ArgumentNullException(nameof(movieCompanyServices));
        _movieCountryServices = movieCountryServices ?? throw new ArgumentNullException(nameof(movieCountryServices));
    }

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        MovieModelScrapping movieModelScrapping = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);
        Movie movie = await _movieServices.CreateOrUpdate(model: movieModelScrapping);
        await _movieCompanyServices.CreateOrGetMovieCompanyAsync(movieId: Txt_Search.CesText, companieskeyValuePairs: movieModelScrapping.Companies);
        await _movieCountryServices.CreateOrGetMovieCountry(countryModels: movieModelScrapping.CountrieskeyValuePairs, movieId: Txt_Search.CesText);

    }
}
