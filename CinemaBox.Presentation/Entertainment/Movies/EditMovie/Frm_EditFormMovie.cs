using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Link.MovieCompanies;
using CinemaBox.Domain.Entertainment.Link.MovieCountries;
using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using CinemaBox.Domain.Entertainment.Link.MovieKeywords;
using CinemaBox.Domain.Entertainment.Link.MovieLocations;
using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Service.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieKeywords;
using CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Utilities.DateTimeExtension.DateExtensions;
using CinemaBox.Utilities.DateTimeExtension.TimeExtension;
using CinemaBox.Utilities.Lables;

namespace CinemaBox.Presentation.Entertainment.Movies.EditMovie;

public partial class Frm_EditFormMovie : CesForm
{
    private readonly IMovieServices? _movieServices;
    private readonly ICurrencyServices? _currencyServices;
    private readonly IMovieGenreServices? _movieGenreServices;
    private readonly IMovieCountryServices? _movieCountryServices;
    private readonly IMovieSpokenLanguageServices? _movieSpokenLanguageServices;
    private readonly IMovieCompanyServices? _movieCompanyServices;
    private readonly IMovieLocationServices? _movieLocationServices;
    private readonly IMovieKeywordServices? _movieKeywordServices;
    private readonly string? _movieId;
    public Frm_EditFormMovie(IMovieServices movieServices,
        string? movieId,
        ICurrencyServices? currencyServices,
        IMovieGenreServices? movieGenreServices,
        IMovieCountryServices? movieCountryServices,
        IMovieSpokenLanguageServices? movieSpokenLanguageServices,
        IMovieCompanyServices? movieCompanyServices,
        IMovieLocationServices? movieLocationServices,
        IMovieKeywordServices? movieKeywordServices

        )
    {
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _currencyServices = currencyServices ?? throw new ArgumentNullException(nameof(currencyServices));
        _movieGenreServices = movieGenreServices ?? throw new ArgumentNullException(nameof(movieGenreServices));
        _movieCountryServices = movieCountryServices ?? throw new ArgumentNullException(nameof(movieCountryServices));
        _movieSpokenLanguageServices = movieSpokenLanguageServices ?? throw new ArgumentNullException(nameof(movieSpokenLanguageServices));
        _movieCompanyServices = movieCompanyServices ?? throw new ArgumentNullException(nameof(movieCompanyServices));
        _movieLocationServices = movieLocationServices ?? throw new ArgumentNullException(nameof(movieLocationServices));
        _movieKeywordServices = movieKeywordServices ?? throw new ArgumentNullException(nameof(movieKeywordServices));
        _movieId = movieId;
        InitializeComponent();
        _ = IntialData();


    }
    public async Task IntialData()
    {
        await SetMovieBasicFields();
        await SetMovieGenres();
        await SetMovieCountries();
        await SetMovieLanguage();
        await SetMovieCompany();
        await SetMovieLocation();
        await SetMovieKeyword();
    }
    private async Task SetMovieBasicFields()
    {
        Movie? movie = await GetMovie();
        Currency currency = await GetCurrency(movie.BudgetCurrencyId);
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
    private async Task<Movie?> GetMovie() => await _movieServices.GeMovieAsync(ImdbId: _movieId);
    private async Task<Currency?> GetCurrency(byte? currencyId) => await _currencyServices.GetCurrencyAsync(currencyId);

    private async Task SetMovieGenres()
    {
        IEnumerable<MovieGenre?> genre = await GetMovieGenresAsync();
        CreateDynamicLabels<MovieGenre>(genre.ToList(), Flw_Genre,g=>g.Genre.FaGenreName??g.Genre.EnGenreName,5);
    }
    private async Task<IEnumerable<MovieGenre?>> GetMovieGenresAsync() => await _movieGenreServices.GetMovieGenre(movieId: _movieId);
    private async Task SetMovieCountries()
    {
        IEnumerable<MovieCountry?> movieCountry = await GetMovieCountryAsync();
        CreateDynamicLabels<MovieCountry>(movieCountry.ToList(), Flw_Country, g => g.CountryPart.FaCountryPartName ?? g.CountryPart.EnCountryPartName, 5);
    }
    private async Task<IEnumerable<MovieCountry?>> GetMovieCountryAsync() => await _movieCountryServices.GetMovieCountry(movieId: _movieId);
    private async Task SetMovieLanguage()
    {
        IEnumerable<MovieSpokenLanguage?> movieSpokenLanguage = await GetMovieLanguageAsync();
        CreateDynamicLabels<MovieSpokenLanguage>(movieSpokenLanguage.ToList(), Flw_Language, g => g.Language.FaLanguageName ?? g.Language.EnLanguageName, 5);
    }
    private async Task<IEnumerable<MovieSpokenLanguage?>> GetMovieLanguageAsync() => await _movieSpokenLanguageServices.GetMovieLanguageAsync(movieId: _movieId);
    private async Task SetMovieCompany()
    {
        IEnumerable<MovieCompany?> movieCompany = await GetMovieCompanyAsync();
        CreateDynamicLabels<MovieCompany>(movieCompany.ToList(), Flw_Company, g => g.Company.FaCompanyName ?? g.Company.EnCompanyName, 5);
    }
    private async Task<IEnumerable<MovieCompany?>> GetMovieCompanyAsync() => await _movieCompanyServices.GetMovieCompany(movieId: _movieId);
    private async Task SetMovieLocation()
    {
        IEnumerable<MovieLocation?> movieCompany = await GetMovieLocationAsync();
        CreateDynamicLabels<MovieLocation>(movieCompany.ToList(), Flw_MovieLocation, g => g.LocationName, 5);
    }
    private async Task<IEnumerable<MovieLocation?>> GetMovieLocationAsync() => await _movieLocationServices.GetMovieLocationsAsync(movieId: _movieId);
    private async Task SetMovieKeyword()
    {
        IEnumerable<MovieKeyword?> movieKeyword = await GetMovieKeywordAsync();
        CreateDynamicLabels<MovieKeyword>(movieKeyword.ToList(), Flw_Keyword, g => g.Keyword.FaKeyowrdName??g.Keyword.EnKeyowrdName, 5);
    }
    private async Task<IEnumerable<MovieKeyword?>> GetMovieKeywordAsync() => await _movieKeywordServices.GetMovieKeywordAsync(movieId: _movieId);
    #region CreateLabel
    public void CreateDynamicLabels<T>(List<T> items, FlowLayoutPanel container, Func<T, string> getText, int marginBottom = 0)
    {
        container.SuspendLayout();
        container.Controls.Clear();
        foreach (var item in items)
        {
            Label label = new()
            {
                Text = getText(item),
                AutoSize = true,
                ForeColor = LabelExtension.GetContrastColor(Color.White),
                BackColor = LabelExtension.GetRandomPastelColor(),
                Font = new Font("IRANSans", 9, FontStyle.Italic),
                Margin = new Padding(5, 5, 5, marginBottom),
                Padding = new Padding(3),
                BorderStyle = BorderStyle.FixedSingle,

            };
            container.Controls.Add(label);
        }
        container.ResumeLayout(true);
    }
    #endregion

}