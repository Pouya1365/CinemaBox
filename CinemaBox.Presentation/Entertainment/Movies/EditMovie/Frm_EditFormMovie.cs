using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Utilities.DateTimeExtension.DateExtensions;
using CinemaBox.Utilities.DateTimeExtension.TimeExtension;

namespace CinemaBox.Presentation.Entertainment.Movies.EditMovie;

public partial class Frm_EditFormMovie : CesForm
{
    private readonly IMovieServices? _movieServices;
    private readonly ICurrencyServices? _currencyServices;
    private readonly string? _movieId;
    public Frm_EditFormMovie(IMovieServices movieServices, string? movieId, ICurrencyServices? currencyServices)
    {
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _currencyServices = currencyServices ?? throw new ArgumentNullException(nameof(currencyServices));
        _movieId = movieId;
        InitializeComponent();
        SetMovieBasicFields();
    }

    private async void SetMovieBasicFields()
    {
        Movie movie = await GetMovie(imdbId: _movieId);
        Currency currency =await GetCurrency(movie.BudgetCurrencyId);
        Txt_EnTitle.CesText = movie.EnTitle;
        Txt_FaTitle.CesText = movie.FaTitle;
        Txt_Plot.CesText = movie.EnPlot;
        Txt_Year.CesText = movie.StartYear.ToString();
        Txt_EndYear.CesText = movie.EndYear?.ToString();
        Txt_OriginalTitle.CesText = movie.OriginalTitle;
        Txt_RunTime.CesText = movie.RunTimeMinutes?.ToString();
        Txt_HourTime.CesText = HourTimeExtension.ToHourTime((long)movie.RunTimeMinutes);
        Txt_Budget.CesText = movie.Budget?.ToString();       
        Txt_Currency.CesText = currency.CurrencyName;
        Txt_Imdb.CesText = movie.Id;
        Txt_TopRanking.CesText = movie.TopRank.ToString();
        Txt_AggregateRating.CesText = movie.AggregateRating.ToString();
        Txt_VoteCount.CesText = movie.VoteCount.ToString();
        Txt_EnStoryline.CesText = movie.EnStoryline;
        Txt_OscarWins.CesText = movie.OscarWins.ToString();
        Txt_OscarNominate.CesText = movie.OscarNominations.ToString();
        Txt_Wins.CesText = movie.Winner.ToString();
        Txt_Nominate.CesText = movie.Nomination.ToString();
        Txt_ReleaseYear.CesText = movie.ReleaseYear.ToString();
        Txt_ReleaseMonth.CesText = movie.ReleaseMonth.ToString();
        Txt_ReleaseDay.CesText = movie.ReleaseDay.ToString();
        Txt_ShamsiYear.CesText = $"{Pcal.ToToJalali((int)(movie.ReleaseYear ?? 1900), (int)(movie.ReleaseMonth ?? 01), (int)(movie.ReleaseDay ?? 01))[..4]}";

    }
    private async Task<Movie?> GetMovie(string? imdbId) => await _movieServices.GeMovieAsync(ImdbId: imdbId);
    private async Task<Currency?> GetCurrency(byte? currencyId) => await _currencyServices.GetCurrencyAsync(currencyId);
}