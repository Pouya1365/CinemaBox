using Ces.WinForm.UI.CesForm;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Service;
namespace CinemaBox.Presentation;
public partial class Form1 : CesForm
{
    private readonly IImdbMovieScrapperServices _imdbScrapperServices;

    public Form1(IImdbMovieScrapperServices imdbScrapperServices)
    {
        InitializeComponent();
        _imdbScrapperServices = imdbScrapperServices ?? throw new ArgumentNullException(nameof(imdbScrapperServices));
    }

    private async void Btn_GetInfo_Click(object sender, EventArgs e)
    {
        MovieModelScrapping movie = await _imdbScrapperServices.ImdbScrapperServicesAsync(imdbId: Txt_Search.CesText);

    }
}
