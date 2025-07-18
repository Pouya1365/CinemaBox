using Ces.WinForm.UI.CesComboBox;
using Ces.WinForm.UI.CesForm;
using Ces.WinForm.UI.CesListBox;
using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Collections;
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
using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using CinemaBox.Domain.Managment.Link.UserMovieFiles;
using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Domain.Shared.Qualities.Qualities;
using CinemaBox.Domain.Shared.Qualities.QualityTypes;
using CinemaBox.Domain.Shared.Statuses;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Enumeration.MediaInfo.MediaInfo;
using CinemaBox.Model.Entertainment.Cast.CreditShow;
using CinemaBox.Model.MediaInfo.MediaInfo;
using CinemaBox.Presentation.Entertainment.Collections;
using CinemaBox.Presentation.MediaInfo;
using CinemaBox.Presentation.Person.Peoples;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Collections;
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
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.Service.Interface.Shared.Qualities.Qualities;
using CinemaBox.Service.Interface.Shared.Qualities.QualityTypes;
using CinemaBox.Service.Interface.Shared.Statuses;
using CinemaBox.Service.Shared.Qualities.Qualities;
using CinemaBox.Service.Shared.Qualities.QualityTypes;
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
    private readonly IUserMovieDiskServices? _userMovieDiskServices;
    private readonly IUserMovieVideoServices? _userMovieVideoServices;
    private readonly IStatusServices? _statusesServices;
    private readonly IFormatServices? _formatServices;
    private readonly IUserMovieAudioServices? _userMovieAudioServices;
    private readonly ILanguageServices? _languageServices;
    private readonly IUserMovieFileServices? _userMovieFileServices;
    private readonly ICollectionServices? _collectionServices;
    private readonly IQualityServices? _qualityServices;
    private readonly IQualityTypeServices? _qualityTypeServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private readonly string? _movieId;
    private bool changeImageUser = false;
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
        IPeopleServices? peopleServices,
        IUserMovieDiskServices? userMovieDiskServices,
        IUserMovieVideoServices? userMovieVideoServices,
        IStatusServices? statusesServices,
        IFormatServices? formatServices,
        IUserMovieAudioServices? userMovieAudioServices,
        ILanguageServices? languageServices,
        IUserMovieFileServices? userMovieFileServices,
        ICollectionServices? collectionServices,
        IQualityServices? qualityServices,
        IQualityTypeServices? qualityTypeServices,
        IDeathCauseServices? deathCauseServices
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
        _userMovieDiskServices = userMovieDiskServices ?? throw new ArgumentNullException(nameof(userMovieDiskServices));
        _userMovieVideoServices = userMovieVideoServices ?? throw new ArgumentNullException(nameof(userMovieVideoServices));
        _statusesServices = statusesServices ?? throw new ArgumentNullException(nameof(statusesServices));
        _formatServices = formatServices ?? throw new ArgumentNullException(nameof(formatServices));
        _userMovieAudioServices = userMovieAudioServices ?? throw new ArgumentNullException(nameof(userMovieAudioServices));
        _languageServices = languageServices ?? throw new ArgumentNullException(nameof(languageServices));
        _userMovieFileServices = userMovieFileServices ?? throw new ArgumentNullException(nameof(userMovieFileServices));
        _collectionServices = collectionServices ?? throw new ArgumentNullException(nameof(collectionServices));
        _qualityServices = qualityServices ?? throw new ArgumentNullException(nameof(qualityServices));
        _qualityTypeServices = qualityTypeServices ?? throw new ArgumentNullException(nameof(qualityTypeServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
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
        await SetUserMovieDisks();
        await SeteUserMovieVideoAsync();
        await SetUserMovieAudiosAsync();
        await SetUserMovieFileAsync();
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
        Txt_Currency.CesText = currency?.CurrencyName;
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
        Txt_FaStoryline.CesText = movie.FaStoryline;
        await LoadCertificate(certificateId: movie.CertificateId);
        await LoadCollection(collectionId: movie.CollectionId);
    }
    private async Task LoadCertificate(int? certificateId) => await LoadComboBoxDataAsync<Certificate>(
    "Rateds",
    Cmb_Certificate,
    GetCertificatesAsync,
    cert => new CesListBoxItemProperty { Value = cert.Id, Text = cert.CertificateName },
   certificateId);
    private async Task LoadCollection(int? collectionId) => await LoadComboBoxDataAsync<Collection>(
  "Collections",
  Cmb_Collection,
  GetCollectionsAsync,
  c => new CesListBoxItemProperty { Value = c.Id, Text = (c.FaCollectionName ?? c.EnCollectionName) },
  collectionId);

    private async Task<Movie?> GetMovie() => await _movieServices.GeMovieAsync(ImdbId: _movieId);
    private async Task<Currency?> GetCurrency(byte? currencyId) => await _currencyServices.GetCurrencyAsync(currencyId);
    private async Task SetMovieGenres()
    {
        IEnumerable<MovieGenre?> genre = await GetMovieGenresAsync();
        CreateDynamicLabels<MovieGenre>([.. genre], Flw_Genre, g => g.Genre.FaGenreName ?? g.Genre.EnGenreName, 5);
    }
    private async Task<IEnumerable<MovieGenre?>> GetMovieGenresAsync() => await _movieGenreServices.GetMovieGenre(movieId: _movieId);
    private async Task SetMovieCountries()
    {
        IEnumerable<MovieCountry?> movieCountry = await GetMovieCountryAsync();
        CreateDynamicLabels<MovieCountry>([.. movieCountry], Flw_Country, g => g.CountryPart.FaCountryPartName ?? g.CountryPart.EnCountryPartName, 5);
    }
    private async Task<IEnumerable<MovieCountry?>> GetMovieCountryAsync() => await _movieCountryServices.GetMovieCountry(movieId: _movieId);
    private async Task SetMovieLanguage()
    {
        IEnumerable<MovieSpokenLanguage?> movieSpokenLanguage = await GetMovieLanguageAsync();
        CreateDynamicLabels<MovieSpokenLanguage>([.. movieSpokenLanguage], Flw_Language, g => g.Language.FaLanguageName ?? g.Language.EnLanguageName, 5);
    }
    private async Task<IEnumerable<MovieSpokenLanguage?>> GetMovieLanguageAsync() => await _movieSpokenLanguageServices.GetMovieLanguageAsync(movieId: _movieId);
    private async Task SetMovieCompany()
    {
        IEnumerable<MovieCompany?> movieCompany = await GetMovieCompanyAsync();
        CreateDynamicLabels<MovieCompany>([.. movieCompany], Flw_Company, g => g.Company.FaCompanyName ?? g.Company.EnCompanyName, 5);
    }
    private async Task<IEnumerable<MovieCompany?>> GetMovieCompanyAsync() => await _movieCompanyServices.GetMovieCompany(movieId: _movieId);
    private async Task SetMovieLocation()
    {
        IEnumerable<MovieLocation?> movieCompany = await GetMovieLocationAsync();
        CreateDynamicLabels<MovieLocation>([.. movieCompany], Flw_MovieLocation, g => g.LocationName, 5);
    }
    private async Task<IEnumerable<MovieLocation?>> GetMovieLocationAsync() => await _movieLocationServices.GetMovieLocationsAsync(movieId: _movieId);
    private async Task SetMovieKeyword()
    {
        IEnumerable<MovieKeyword?> movieKeyword = await GetMovieKeywordAsync();
        CreateDynamicLabels<MovieKeyword>([.. movieKeyword], Flw_Keyword, g => g.Keyword.FaKeyowrdName ?? g.Keyword.EnKeyowrdName, 5);
    }
    private async Task<IEnumerable<MovieKeyword?>> GetMovieKeywordAsync() => await _movieKeywordServices.GetMovieKeywordAsync(movieId: _movieId);
    private async Task SeMovieTaglineAsync()
    {
        IEnumerable<MovieTagline?> movieTaglines = await GetMovieTaglineAsync();
        CreateDynamicLabels<MovieTagline>([.. movieTaglines], Flw_Tagline, g => g.FaTagline ?? g.EnTagline, 5);
    }
    private async Task<IEnumerable<MovieTagline?>> GetMovieTaglineAsync() => await _movieTaglineServices.GetMovieTagline(movieId: _movieId);
    private async Task LoadComboBoxDataAsync<TModel>(
       string cacheKey,
       CesComboBox comboBox,
       Func<Task<IEnumerable<TModel>>> dataFetcher,
       Func<TModel, CesListBoxItemProperty> selector,
       int? selectedId)
    {
        IEnumerable<TModel> itemsSource = await dataFetcher();
        List<CesListBoxItemProperty> items = [.. itemsSource.Select(selector)];

        // اضافه کردن آیتم خالی به ابتدای لیست


        comboBox.CesDataSource = null;
        comboBox.CesValueMember = "Value";
        comboBox.CesDisplayMember = "Text";
        comboBox.CesDataSource = items;
        comboBox.Refresh();

        if (selectedId.HasValue)
        {
            CesListBoxItemProperty? selectedItem = items
                .FirstOrDefault(x => int.TryParse(x.Value.ToString(), out int val) && val == selectedId.Value);

            if (selectedItem != null)
                comboBox.CesSelectedItem = selectedItem;
        }
        else
        {
            // اگر selectedId نداشت، هیچ چیزی انتخاب نکن
            comboBox.CesSelectedItem = null; // انتخاب آیتم خالی
        }
    }
    private async Task<IEnumerable<Certificate>> GetCertificatesAsync() => await _certificateServices.GetAllCertificatesAsync();
    private async Task<IEnumerable<Collection>> GetCollectionsAsync() => await _collectionServices.GetAllCollection();
    private async Task SetMovieFileAsync()
    {
        MovieFile movieFiles = await GetMovieFileAsync();
        string filePath = movieFiles==null? null: Path.Combine(movieFiles.File.Server.Path, movieFiles.File.FileName);
        Pic_Poster.Image = filePath==null?null: Image.FromFile(filePath);
    }
    private async Task<MovieFile> GetMovieFileAsync() => await _movieFileServices.GetMovieFile(movieId: _movieId);
    private async Task SetUserMovieDisks()
    {
        UserMovieDisk? userMovieDisk = await GetUserMovieDiskAsync();
        if (userMovieDisk is null)
            return;
        Chk_Subtitle.CesCheck = userMovieDisk.IsSubtitle;
        Txt_MovieNumber.CesText = userMovieDisk.MovieNumber.ToString();
        Txt_MyRunTime.CesText = userMovieDisk.MyTime.ToString();
        Txt_PositionMovie.CesText = userMovieDisk.PositionMovie;
        Txt_FileName.CesText = userMovieDisk.FileName;
        Txt_FileSize.CesText = userMovieDisk.FileSize.ToString();
        Chk_IsDubbed.CesCheck = userMovieDisk.IsDubbed;
        Txt_MyHourTime.CesText = HourTimeExtension.FormatHourMinutesToTimeString((int?)userMovieDisk.MyTime ?? 0);
        Txt_Description.CesText = userMovieDisk.Description;
        await LoadComboBoxDataAsync<Status>(
    "StatusCache",
    Cmb_MyStatus,
    GetAllStatusAsync,
    status => new CesListBoxItemProperty { Value = status.Id, Text = status.SatusName },
    userMovieDisk.StatusId);
    }

    private async Task SetUserMovieAudiosAsync()
    {
        IEnumerable<UserMovieAudio> audioTracks = await GetUserMovieAudio();
        List<AudioTracksModel> audioTracksModels = [.. audioTracks.Select(x => new AudioTracksModel { Channels = x.Channels.ToString(), Format = x.Format.FormatName, Language = (x.Language.FaLanguageName ?? x.Language.EnLanguageName) })];
        Dgv_Audio.CesDataSource = audioTracksModels;
        Dgv_Audio.ReadOnly = false; // فعال‌سازی ویرایش
        Dgv_Audio.AllowUserToAddRows = true;   // اجازه اضافه‌کردن ردیف جدید
        Dgv_Audio.AllowUserToDeleteRows = true; // اجازه حذف ردیف
        Dgv_Audio.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
    }
    private async Task SeteUserMovieVideoAsync()
    {
        UserMovieVideo? userMovieVideo = await GetUserMovieVideoAsync();
        if (userMovieVideo is null)
            return;
        Txt_Format.CesText = userMovieVideo?.Format?.FormatName;
        Txt_Bitrate.CesText = userMovieVideo.BitRate;
        Txt_FPS.CesText = userMovieVideo.FPS;
        Txt_AspectRatio.CesText = userMovieVideo.AspectRatio;
        Txt_Resolution.CesText = userMovieVideo.Resolution;
        Chk_X265.CesCheck = userMovieVideo.X265;
        await LoadQuality(qualityId: userMovieVideo.QualityId);
        await LoadQualityType(qualityTypaId: userMovieVideo.QualityTypeId);
    }

    private async Task LoadQuality(int? qualityId) => await LoadComboBoxDataAsync<Quality>(
"Quality",
Cmb_Quality,
GetQualityAsync,
q => new CesListBoxItemProperty { Value = q.Id, Text = q.QualityName },
qualityId);
    private async Task LoadQualityType(int? qualityTypaId) => await LoadComboBoxDataAsync<QualityType>(
"QualityType",
Cmb_QualityType,
GetQualityTypeAsync,
qt => new CesListBoxItemProperty { Value = qt.Id, Text = qt.QualityTypeName },
qualityTypaId);

    private async Task<IEnumerable<Quality>> GetQualityAsync() => await _qualityServices.GetAllQualities();
    private async Task<IEnumerable<QualityType>> GetQualityTypeAsync() => await _qualityTypeServices.GetAllQualityTypes();


    private async Task SetUserMovieFileAsync()
    {
        UserMovieFile usermovieFiles = await GetUserMovieFileAsync();
        if (usermovieFiles is null)
            return;
        string filePath = Path.Combine(usermovieFiles.File.Server.Path, usermovieFiles.File.FileName);
        Pic_UserMovie.Image = Image.FromFile(filePath);
    }
    private async Task<UserMovieFile> GetUserMovieFileAsync() => await _userMovieFileServices.GetUserMovieFile(movieId: _movieId);
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
            ctrl.CheckedClicked += CheckedBox_Clicked;
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
    #region LoadPeople
    private void PeopleBox_PosterClicked(object sender, string peopleId)
    {
        Frm_EditPeople frm_EditPeople = new(
           peopleId: peopleId,
           peopleServices: _peopleServices,
           peopleFileServices: _peopleFileServices,
           deathCauseServices: _deathCauseServices,
           movieCreditServices:_movieCreditServices,
           movieServices:_movieServices
           
           );
        frm_EditPeople.ShowDialog();
    }
    private async void CheckedBox_Clicked(object sender, string peopleId)=>  await ChangeIsLead(peopleId: peopleId);


    #endregion
    #region ReadFile
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
        List<Track> tracks = fileInfo.Media.Tracks;
        Track videoTrack = GetVideoTrack(tracks);
        double durationSeconds = GetDurationInSeconds(videoTrack);
        SetGeneralVideoInfo(videoTrack, filePath);
        SetDurationInfo(durationSeconds);
        SetFileSizeInfo(filePath);
        SetAudioAndSubtitleInfo(tracks);
        SetAudioGrid(tracks);
    }
    private Track GetVideoTrack(List<Track> tracks) => tracks.FirstOrDefault(x => x.Type == MediaInfoEnumeration.Video.ToString())
               ?? throw new InvalidOperationException("Track ویدیویی یافت نشد.");
    private double GetDurationInSeconds(Track videoTrack)
    {
        if (!double.TryParse(videoTrack.Duration, out double duration))
            throw new FormatException("خطا در خواندن مدت زمان ویدیو (Duration).");
        return duration;
    }
    private void SetGeneralVideoInfo(Track videoTrack, string filePath)
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
        Txt_MyHourTime.CesText = HourTimeExtension.FormatHourMinutesToTimeStringFromSeconds((int)durationSeconds);
        Txt_MyHourTime.Enabled = false;
    }
    private void SetFileSizeInfo(string filePath)
    {
        FileInfo fileInfo = new(filePath);
        double fileSizeInGB = fileInfo.Length / (1024.0 * 1024.0 * 1024.0);
        Txt_FileSize.CesText = $"{fileSizeInGB:F2}";
    }
    private void SetAudioAndSubtitleInfo(List<Track> tracks)
    {
        ArgumentNullException.ThrowIfNull(tracks);
        Chk_IsDubbed.CesCheck = tracks.Any(x =>
            x.Type == MediaInfoEnumeration.Audio.ToString() &&
            x.Language?.Trim().ToLower() == "fa");
        Chk_Subtitle.CesCheck = tracks.Any(x =>
            x.Type == MediaInfoEnumeration.Text.ToString() &&
            x.Language?.Trim().ToLower() == "fa");
    }
    private void SetAudioGrid(List<Track> tracks)
    {
        List<AudioTracksModel> audioTracks = [.. tracks
            .Where(x => x.Type == MediaInfoEnumeration.Audio.ToString())
            .Select(x => new AudioTracksModel { Channels = x.Channels, Format = x.Format, Language = x.Language })];
        Dgv_Audio.CesDataSource = audioTracks;
        Dgv_Audio.ReadOnly = false; // فعال‌سازی ویرایش
        Dgv_Audio.AllowUserToAddRows = true;   // اجازه اضافه‌کردن ردیف جدید
        Dgv_Audio.AllowUserToDeleteRows = true; // اجازه حذف ردیف
        Dgv_Audio.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
    }
    #endregion
    private async void Btn_Save_Click(object sender, EventArgs e) =>
        await SaveMovieDataAsync();

    public async Task SaveMovieDataAsync()
    {
        await SaveMovieInfoAsync();
        await SaveUserMovieDiskAsync();
        await SaveUserMovieVideoAsync();
        await SaveUserMovieAudiosAsync();
        if (changeImageUser == true)
            await SaveUserMovieFilesAsync();
        this.Close();
    }

    private async Task SaveUserMovieFilesAsync()
    {
        if (Pic_UserMovie.Image is null)
            return;
        string endYear = Txt_EndYear.CesText != null ? @$"-{Txt_EndYear.CesText}" : "";
        string movieName = $@"{Txt_EnTitle.CesText}_{Txt_Year.CesText}{endYear}";
        string path = Application.StartupPath;
        byte[] image = ImageToByteArray(Pic_UserMovie);
        await CopyUserMovie(path: path, image, movieName: movieName);
    }
    public static byte[] ImageToByteArray(PictureBox pictureBox)
    {
        if (pictureBox.Image == null)
            return null;

        using MemoryStream ms = new();
        using Bitmap bmp = new(pictureBox.Image); // 👈 گرفتن کپی از تصویر برای رفع مشکل قفل
        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }
    private async Task SaveMovieInfoAsync()
    {
        Movie? movie = await GetMovie();
        if (movie is not null)
        {
            if (!string.IsNullOrWhiteSpace(Txt_FaTitle.CesText))
                movie.FaTitle = Txt_FaTitle.CesText;
            if (!string.IsNullOrWhiteSpace(Txt_FaStoryline.CesText))
                movie.FaStoryline = Txt_FaStoryline.CesText;
            movie.IsTvShow = Chk_IsTv.CesToggle;
            if (Cmb_Collection.CesSelectedValue is not null)
                movie.CollectionId = (int)Cmb_Collection.CesSelectedValue;

            await UpdateMovie(movie);
        }
    }
    private async Task SaveUserMovieDiskAsync()
    {
        UserMovieDisk? userMovieDisk = await GetUserMovieDiskAsync();
        if (userMovieDisk is null)
            return;
        userMovieDisk.IsSubtitle = Chk_Subtitle.CesCheck;
        if (int.TryParse(Txt_MovieNumber.CesText, out int movieNumber))
            userMovieDisk.MovieNumber = movieNumber;
        if (int.TryParse(Txt_MyRunTime.CesText, out int myTime))
            userMovieDisk.MyTime = myTime;
        userMovieDisk.PositionMovie = Txt_PositionMovie.CesText;
        userMovieDisk.FileName = Txt_FileName.CesText;
        if (decimal.TryParse(Txt_FileSize.CesText, out decimal fileSize))
            userMovieDisk.FileSize = fileSize;
        userMovieDisk.IsDubbed = Chk_IsDubbed.CesCheck;
        userMovieDisk.Id = Txt_Imdb.CesText;
        userMovieDisk.StatusId = (byte?)Cmb_MyStatus.CesSelectedValue;
        userMovieDisk.Description = Txt_Description.CesText;
        await CreateOrUpdateUserMovieDisk(userMovieDisk);
    }
    private async Task SaveUserMovieVideoAsync()
    {
        UserMovieVideo? userMovieVideo = await GetUserMovieVideoAsync();
        if (userMovieVideo is null)
            return;

        var format = await GetFormatAsync(Txt_Format.CesText);
        if (format is not null)
            userMovieVideo.FormatId = format.Id;

        userMovieVideo.BitRate = Txt_Bitrate.CesText;
        userMovieVideo.FPS = Txt_FPS.CesText;
        userMovieVideo.AspectRatio = Txt_AspectRatio.CesText;
        userMovieVideo.Resolution = Txt_Resolution.CesText;
        userMovieVideo.Id = Txt_Imdb.CesText;
        userMovieVideo.X265 = Chk_X265.CesCheck;
        userMovieVideo.QualityId = (byte?)Cmb_Quality.CesSelectedValue;
        userMovieVideo.QualityTypeId = (byte?)Cmb_QualityType.CesSelectedValue;

        await CreateOrUpdateUserMovieVideo(userMovieVideo);
    }
    private async Task SaveUserMovieAudiosAsync()
    {
        IEnumerable<UserMovieAudio>? existingAudios = await GetMovieAudiosAsync();
        if (existingAudios is not null)
            await RemoveMovieAudiosAsync(existingAudios);

        List<UserMovieAudio> newAudios = [];

        foreach (DataGridViewRow row in Dgv_Audio.Rows)
        {
            if (row.IsNewRow) continue;

            var langName = row.Cells[0]?.Value?.ToString();
            var channelsText = row.Cells[1]?.Value?.ToString();
            var formatName = row.Cells[2]?.Value?.ToString();

            if (string.IsNullOrWhiteSpace(langName) ||
                string.IsNullOrWhiteSpace(channelsText) ||
                string.IsNullOrWhiteSpace(formatName))
                continue;

            if (!byte.TryParse(channelsText, out byte channels)) continue;

            Language? lang = await GetLanguageAsync(langName);
            Format? format = await GetFormatAsync(formatName);

            if (lang is null || format is null)
                continue;

            newAudios.Add(new UserMovieAudio
            {
                Channels = channels,
                FormatId = format.Id,
                LanguageId = lang.Id,
                MovieId = _movieId
            });
        }

        if (newAudios.Count > 0)
            await CreateUserMovieAudio(newAudios);
    }
    private async Task UpdateMovie(Movie movie) => await _movieServices.UpdateMovie(movie: movie);
    private async Task<UserMovieDisk?> GetUserMovieDiskAsync() => await _userMovieDiskServices.GetMovieDiskAsync(movieId: _movieId) ?? new();
    private async Task CreateOrUpdateUserMovieDisk(UserMovieDisk userMovieDisk) => await _userMovieDiskServices.CreateOrUpdateUserMovieDiskAsync(userMovieDisk: userMovieDisk);
    private async Task<UserMovieVideo?> GetUserMovieVideoAsync() => await _userMovieVideoServices.GetMovieVideoAsync(movieId: _movieId) ?? new();
    private async Task CreateOrUpdateUserMovieVideo(UserMovieVideo userMovieVideo) => await _userMovieVideoServices.CreateOrUpdateUserMovieVideoAsync(userMovieVideo: userMovieVideo);

    private async Task<IEnumerable<Status>> GetAllStatusAsync() => await _statusesServices.GetAllStatuses();
    private async Task<Format?> GetFormatAsync(string formatName) => await _formatServices.CreateOrGetFormatAsync(formatName: formatName);
    private async Task<IEnumerable<UserMovieAudio>> GetMovieAudiosAsync() => await _userMovieAudioServices.GetUserMovieAudioAsync(movieId: _movieId);
    private async Task RemoveMovieAudiosAsync(IEnumerable<UserMovieAudio> userMovieAudios) => await _userMovieAudioServices.RemoveUserMovieAudio(userMovieAudios: userMovieAudios);
    private async Task<Language?> GetLanguageAsync(string languageName) => await _languageServices.CreateOrGetLanguageAsync(languageName: languageName, isoCode: languageName);
    private async Task CreateUserMovieAudio(List<UserMovieAudio> userMovieAudios) => await _userMovieAudioServices.CreateUserMovieAudioAsync(userMovieAudios: userMovieAudios);
    private async Task<IEnumerable<UserMovieAudio>> GetUserMovieAudio() => await _userMovieAudioServices.GetMovieAudiosAsync(movieId: _movieId);
    private void Pic_UserMovie_Click(object sender, EventArgs e)
    {
        changeImageUser = true;
        using OpenFileDialog open = new();
        if (open.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(open.FileName))
            return;
        try
        {
            Pic_UserMovie.Image = null;
            Pic_UserMovie.Image = Image.FromFile(open.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطا در خواندن فایل:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task CopyUserMovie(string path, byte[] image, string movieName) => await _userMovieFileServices.CreateOrUpdateUserMovieImage(path: path, image: image, movieId: _movieId, movieName: movieName);

    private async void Cmb_Collection_CesAddItemClicked(object sender, Ces.WinForm.UI.CesComboBox.Events.CesAddItemEvent e)
    {
        Frm_AddCollections frm_AddCollections = new(collectionServices: _collectionServices);
        frm_AddCollections.ShowDialog();
        await LoadCollection(collectionId: null);
    }
    private void Btn_Exit_Click(object sender, EventArgs e) => this.Close();
    public async Task<bool> ChangeIsLead(string peopleId) => await _movieCreditServices.ChangeIsLeadRole(peopleId: peopleId, movieId: _movieId);
}