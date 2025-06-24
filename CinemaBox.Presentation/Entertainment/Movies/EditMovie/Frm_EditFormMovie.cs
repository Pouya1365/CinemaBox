using Ces.WinForm.UI.CesComboBox;
using Ces.WinForm.UI.CesForm;
using Ces.WinForm.UI.CesListBox;
using CinemaBox.Domain.Entertainment.Certificates;
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
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Enumeration.MediaInfo.MediaInfo;
using CinemaBox.Model.Entertainment.Cast.CreditShow;
using CinemaBox.Model.MediaInfo.MediaInfo;
using CinemaBox.Presentation.MediaInfo;
using CinemaBox.Presentation.Person.Peoples;
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
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UserController.Entertainment.CreditShow;
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
    private readonly IMovieTaglineServices? _movieTaglineServices;
    private readonly ICertificateServices? _certificateServices;
    private readonly IMovieFileServices? _movieFileServices;
    private readonly IMovieCreditServices? _movieCreditServices;
    private readonly IPeopleFileServices? _peopleFileServices;
    private readonly IPeopleServices? _peopleServices;
    private readonly string? _movieId;
    public Frm_EditFormMovie(IMovieServices movieServices,
        string? movieId,
        ICurrencyServices? currencyServices,
        IMovieGenreServices? movieGenreServices,
        IMovieCountryServices? movieCountryServices,
        IMovieSpokenLanguageServices? movieSpokenLanguageServices,
        IMovieCompanyServices? movieCompanyServices,
        IMovieLocationServices? movieLocationServices,
        IMovieKeywordServices? movieKeywordServices,
        IMovieTaglineServices? movieTaglineServices,
        ICertificateServices? certificateServices,
        IMovieFileServices? movieFileServices,
        IMovieCreditServices? movieCreditServices,
        IPeopleFileServices? peopleFileServices,
        IPeopleServices? peopleServices

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
        _movieTaglineServices = movieTaglineServices ?? throw new ArgumentNullException(nameof(movieTaglineServices));
        _certificateServices = certificateServices ?? throw new ArgumentNullException(nameof(certificateServices));
        _movieFileServices = movieFileServices ?? throw new ArgumentNullException(nameof(movieFileServices));
        _movieCreditServices = movieCreditServices ?? throw new ArgumentNullException(nameof(movieCreditServices));
        _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _movieId = movieId;
        InitializeComponent();
        _ = IntialData();


    }
    #region LoadGeneralData
    public async Task IntialData()
    {
        await SetMovieBasicFields();
        await SetMovieGenres();
        await SetMovieCountries();
        await SetMovieLanguage();
        await SetMovieCompany();
        await SetMovieLocation();
        await SetMovieKeyword();
        await SeMovieTaglineAsync();
        await SetMovieFileAsync();
        await SetMovieCreditAsync();
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
        await LoadComboDataAsync("Rateds", Cmb_Certificate, c => new CesListBoxItemProperty { Text = c.CertificateName ?? "-", Value = (int)c.Id }, movie.CertificateId);

    }
    private async Task<Movie?> GetMovie() => await _movieServices.GeMovieAsync(ImdbId: _movieId);
    private async Task<Currency?> GetCurrency(byte? currencyId) => await _currencyServices.GetCurrencyAsync(currencyId);
    private async Task SetMovieGenres()
    {
        IEnumerable<MovieGenre?> genre = await GetMovieGenresAsync();
        CreateDynamicLabels<MovieGenre>(genre.ToList(), Flw_Genre, g => g.Genre.FaGenreName ?? g.Genre.EnGenreName, 5);
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
        CreateDynamicLabels<MovieKeyword>(movieKeyword.ToList(), Flw_Keyword, g => g.Keyword.FaKeyowrdName ?? g.Keyword.EnKeyowrdName, 5);
    }
    private async Task<IEnumerable<MovieKeyword?>> GetMovieKeywordAsync() => await _movieKeywordServices.GetMovieKeywordAsync(movieId: _movieId);
    private async Task SeMovieTaglineAsync()
    {
        IEnumerable<MovieTagline?> movieTaglines = await GetMovieTaglineAsync();
        CreateDynamicLabels<MovieTagline>(movieTaglines.ToList(), Flw_Tagline, g => g.FaTagline ?? g.EnTagline, 5);
    }
    private async Task<IEnumerable<MovieTagline?>> GetMovieTaglineAsync() => await _movieTaglineServices.GetMovieTagline(movieId: _movieId);
    private async Task LoadComboDataAsync(string cacheKey, CesComboBox comboBox, Func<Certificate, CesListBoxItemProperty> selector, int? id)
    {
        IEnumerable<Certificate> listCertificate = await GetCertificatesAsync();
        List<CesListBoxItemProperty> items = [.. listCertificate.Select(selector)];
        comboBox.CesDataSource = null;
        comboBox.CesValueMember = "Value";
        comboBox.CesDisplayMember = "Text";
        comboBox.CesDataSource = items;
        comboBox.Refresh();
        if (id.HasValue)
        {
            CesListBoxItemProperty? selectedItem = items.FirstOrDefault(x => (int)x.Value == id.Value);
            if (selectedItem != null)
                comboBox.CesSelectedItem = selectedItem;
        }
    }
    private async Task<IEnumerable<Certificate>> GetCertificatesAsync() => await _certificateServices.GetAllCertificatesAsync();
    private async Task SetMovieFileAsync()
    {
        MovieFile movieFiles = await GetMovieFileAsync();
        string filePath = Path.Combine(movieFiles.File.Server.Path, movieFiles.File.FileName);
        Pic_Poster.Image = Image.FromFile(filePath);
    }
    private async Task<MovieFile> GetMovieFileAsync() => await _movieFileServices.GetMovieFile(movieId: _movieId);
    #endregion
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
    #region LoadCrews
    private async Task SetMovieCreditAsync()
    {
        IEnumerable<MovieCredit?> credits = await GetMovieCreditsAsync();
        List<string> peopleIds = credits.Select(x => x.PeopleId).Distinct().ToList();
        IEnumerable<PeopleFile?> peopleFiles = await GetPeopleFileAsync(peopleIds);
        Dictionary<string, PeopleFile?> peoplePicture = peopleFiles
            .Where(x => x != null)
            .ToDictionary(x => x!.PeopleId, x => x);
        List<CreditShowModel> creditModels = [.. credits.Select(x =>
        {
            peoplePicture.TryGetValue(x.PeopleId, out PeopleFile? personPic);
            string? picUrl = personPic != null && personPic.File != null && personPic.File.Server != null
                ? Path.Combine(Application.StartupPath, personPic.File.Server.Path, personPic.File.FileName)
                : null;
            return new CreditShowModel
            {
                EnCreditTypeName = x.CreditType.EnCreditTypeName,
                FaCreditTypeName = x.CreditType.FaCreditTypeName,
                EnFullName = x.People.EnFullName,
                FaFullName = x.People.FaFullName,
                IsLeadRole = x.IsLead,
                RoleName = x.RoleName,
                Id = x.PeopleId,
                PicUrl = picUrl,

            };
        })];
        ShowCrews[] crewControls = [.. creditModels
    .Where(x => x.EnCreditTypeName != CreditEnumeration.Cast.ToString())
    .OrderBy(x => x.EnCreditTypeName)
    .Select(x => AttachHandler(ToShowCrews(x)))];
        ShowCrews[] castControls = [.. creditModels
    .Where(x => x.EnCreditTypeName == CreditEnumeration.Cast.ToString())
    .OrderByDescending(x => x.IsLeadRole)
    .Select(x => AttachHandler(ToShowCrews(x)))];
        ShowCrews AttachHandler(ShowCrews ctrl)
        {
            ctrl.PicClicked += PeopleBox_PosterClicked;
            return ctrl;
        }
        Flw_Crews.Controls.AddRange(crewControls);
        Flw_Cast.Controls.AddRange(castControls);
    }
    private ShowCrews ToShowCrews(CreditShowModel model) => new(
            pictureUrl: model.PicUrl,
            enfullName: model.EnFullName,
            faFullName: model.FaFullName,
            encreditType: model.EnCreditTypeName,
            facreditType: model.FaCreditTypeName,
            roleName: model.RoleName,
            isLeadRole: model.IsLeadRole,
            id: model.Id
        );
    private async Task<IEnumerable<MovieCredit?>> GetMovieCreditsAsync() => await _movieCreditServices.GetMovieCreditsAsync(movieId: _movieId);
    private async Task<IEnumerable<PeopleFile?>> GetPeopleFileAsync(List<string> peopleIds) => await _peopleFileServices.GetPeopleFile(peopleIds: peopleIds);
    #endregion
    private void PeopleBox_PosterClicked(object sender, string peopleId)
    {
        Frm_EditPeople frm_EditPeople = new(
           peopleId: peopleId,
           peopleServices: _peopleServices,
           peopleFileServices: _peopleFileServices

            );
        frm_EditPeople.ShowDialog();
    }

    private void Btn_ReadFile_Click(object sender, EventArgs e)
    {
        using OpenFileDialog open = new();
        if (open.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(open.FileName))
            return;
        try
        {
            LoadAndDisplayMediaInfo(open.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطا در خواندن فایل:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void LoadAndDisplayMediaInfo(string filePath)
    {
        MediaInfoResult? fileInfo = MediaServices.GetInfoMedia(filePath);
        if (fileInfo?.Media?.Tracks == null)
            throw new InvalidOperationException("اطلاعات مدیا یافت نشد.");
        List<Model.MediaInfo.MediaInfo.Track> tracks = fileInfo.Media.Tracks;
        Model.MediaInfo.MediaInfo.Track videoTrack = GetVideoTrack(tracks);
        double durationSeconds = GetDurationInSeconds(videoTrack);
        SetGeneralVideoInfo(videoTrack, filePath);
        SetDurationInfo(durationSeconds);
        SetFileSizeInfo(filePath);
        SetAudioAndSubtitleInfo(tracks);
        SetAudioGrid(tracks);
    }
    private Model.MediaInfo.MediaInfo.Track GetVideoTrack(List<Model.MediaInfo.MediaInfo.Track> tracks)=> tracks.FirstOrDefault(x => x.Type == MediaInfoEnumeration.Video.ToString())
               ?? throw new InvalidOperationException("Track ویدیویی یافت نشد.");
 

    private double GetDurationInSeconds(Model.MediaInfo.MediaInfo.Track videoTrack)
    {
        if (!double.TryParse(videoTrack.Duration, out double duration))
            throw new FormatException("خطا در خواندن مدت زمان ویدیو (Duration).");
        return duration;
    }
    private void SetGeneralVideoInfo(Model.MediaInfo.MediaInfo.Track videoTrack, string filePath)
    {
        Txt_FileName.CesText = Path.GetFileNameWithoutExtension(filePath);
        Txt_Format.CesText = videoTrack.Format;
        Txt_Bitrate.CesText = videoTrack.BitRate;
        Txt_FPS.CesText = videoTrack.FrameRate;
        Txt_AspectRatio.CesText = videoTrack.DisplayAspectRatio;
        Txt_Resolution.CesText = $"{videoTrack.Width}*{videoTrack.Height}";
    }
    private void SetDurationInfo(double durationSeconds)
    {
        Txt_MyRunTime.CesText = HourTimeExtension.ConvertTextToRunTime(durationSeconds).ToString();
        Txt_MyHourTime.Enabled = true;
        Txt_MyHourTime.CesText = HourTimeExtension.FormatHourMinutesToTimeString((int)durationSeconds);
        Txt_MyHourTime.Enabled = false;
    }
    private void SetFileSizeInfo(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        double fileSizeInGB = fileInfo.Length / (1024.0 * 1024.0 * 1024.0);
        Txt_FileSize.CesText = $"{fileSizeInGB:F2}";
    }
    private void SetAudioAndSubtitleInfo(List<Model.MediaInfo.MediaInfo.Track> tracks)
    {
        Chk_IsDubbed.CesCheck = tracks.Any(x =>
            x.Type == MediaInfoEnumeration.Audio.ToString() &&
            x.Language?.Trim().ToLower() == "fa");
        Chk_Subtitle.CesCheck = tracks.Any(x =>
            x.Type == MediaInfoEnumeration.Text.ToString() &&
            x.Language?.Trim().ToLower() == "fa");
    }
    private void SetAudioGrid(List<Model.MediaInfo.MediaInfo.Track> tracks)
    {
        var audioTracks = tracks
            .Where(x => x.Type == MediaInfoEnumeration.Audio.ToString())
            .Select( x=>new AudioTracksModel { Channels=x.Channels,Format=x.Format,Language=x.Language})
            .ToList();
        Dgv_Audio.CesDataSource = audioTracks;
        Dgv_Audio.ReadOnly = false; // فعال‌سازی ویرایش
        Dgv_Audio.AllowUserToAddRows = true;   // اجازه اضافه‌کردن ردیف جدید
        Dgv_Audio.AllowUserToDeleteRows = true; // اجازه حذف ردیف
        Dgv_Audio.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
    }
}