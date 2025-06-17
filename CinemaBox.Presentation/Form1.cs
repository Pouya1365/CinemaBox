using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Service;
using CinemaBox.Service.Interface.Entertainment.Movies;
namespace CinemaBox.Presentation;
public partial class Form1 : CesForm
{
    private readonly IImdbMovieScrapperServices _imdbScrapperServices;
    private readonly IMovieServices _movieServices;

    public Form1(IImdbMovieScrapperServices imdbScrapperServices, IMovieServices movieServices)
    {
        InitializeComponent();
        _imdbScrapperServices = imdbScrapperServices ?? throw new ArgumentNullException(nameof(imdbScrapperServices));
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
    }

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        MovieModelScrapping movieModelScrapping = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);
        Movie movie = await _movieServices.CreateOrUpdate(movieModelScrapping);
    }
}
