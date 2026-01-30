using Ces.WinForm.UI.CesChart;
using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Model.Entertainment.Cast.CreditShow;
using CinemaBox.Model.Statestics;
using CinemaBox.Presentation.Person.Peoples;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.UserController.Entertainment.CreditShow;
using System.Linq;

namespace CinemaBox.Presentation.Statestics.Statestics;

public partial class Frm_Statestics : CesForm
{
    private readonly IMovieServices _movieServices;
    private readonly IGenreServices _genreServices;
    private readonly IMovieCreditServices _movieCreditServices;
    private readonly ICollectionServices _collectionServices;
    private readonly IUserMovieFileServices _userMovieFileServices;
    private readonly IUserMovieAudioServices _userMovieAudioServices;
    private readonly IUserMovieDiskServices _userMovieDiskServices;
    private readonly ICountryPartServices _countryPartServices;
    private readonly ILanguageServices _languageServices;
    private readonly IPeopleFileServices _peopleFileServices;
    private readonly IPeopleServices _peopleServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private readonly string? _path;
    public Frm_Statestics(IMovieServices movieServices,
        IGenreServices genreServices,
        IMovieCreditServices movieCreditServices,
        ICollectionServices collectionServices,
        IUserMovieFileServices userMovieFileServices,
        IUserMovieAudioServices userMovieAudioServices,
        IUserMovieDiskServices userMovieDiskServices,
        ICountryPartServices countryPartServices,
        ILanguageServices languageServices,
        IPeopleFileServices peopleFileServices,
        IPeopleServices peopleServices,
        IDeathCauseServices? deathCauseServices,
        string? path
        )
    {
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _genreServices = genreServices ?? throw new ArgumentNullException(nameof(genreServices));
        _movieCreditServices = movieCreditServices ?? throw new ArgumentNullException(nameof(movieCreditServices));
        _collectionServices = collectionServices ?? throw new ArgumentNullException(nameof(collectionServices));
        _userMovieFileServices = userMovieFileServices ?? throw new ArgumentNullException(nameof(userMovieFileServices));
        _userMovieAudioServices = userMovieAudioServices ?? throw new ArgumentNullException(nameof(userMovieAudioServices));
        _userMovieDiskServices = userMovieDiskServices ?? throw new ArgumentNullException(nameof(userMovieDiskServices));
        _countryPartServices = countryPartServices ?? throw new ArgumentNullException(nameof(countryPartServices));
        _languageServices = languageServices ?? throw new ArgumentNullException(nameof(languageServices));
        _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
        _path = path;
        InitializeComponent();
        _ = LoadData();

    }
    private async Task LoadData()
    {

        StatesticsModel statesticsModel = new();
        statesticsModel = await _movieServices.GetStatestics(models: statesticsModel);
        statesticsModel = await _genreServices.GetStatestics(statesticsModel: statesticsModel);
        statesticsModel = await _movieCreditServices.GetStatestics(statesticsModel: statesticsModel);
        statesticsModel = await _collectionServices.GetStatestics(statesticsModel: statesticsModel);
        statesticsModel = await _userMovieFileServices.GetStatestics(statesticsModel: statesticsModel);
        statesticsModel = await _userMovieAudioServices.GetStatestics(statesticsModel: statesticsModel);
        statesticsModel = await _userMovieDiskServices.GetStatestics(statesticsModel: statesticsModel);

        ListViewGroup grp_MovieAndSerial = new("فیلم ها و سریال ها");
        ListViewGroup grp_Movie = new("فیلم ها");
        ListViewGroup grp_Series = new("سریال ها");
        ListViewGroup grp_File = new("فایل ها");
        ListViewGroup grp_Dubbed = new("دوبله");
        ListViewGroup grp_TwoLanguages = new("دو زبانه");
        ListViewGroup grp_Other = new("سایر");
        Lst_Statestics.Groups.Add(grp_MovieAndSerial);
        Lst_Statestics.Groups.Add(grp_Movie);
        Lst_Statestics.Groups.Add(grp_Series);
        Lst_Statestics.Groups.Add(grp_File);
        Lst_Statestics.Groups.Add(grp_Dubbed);
        Lst_Statestics.Groups.Add(grp_TwoLanguages);
        Lst_Statestics.Groups.Add(grp_Other);
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد کل",
         statesticsModel.Total.ToString()
        ], grp_MovieAndSerial));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد فیلم ها",
        statesticsModel.MovieTotalCount.ToString()
        ], grp_MovieAndSerial));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد سریال ها",
       statesticsModel.TvSeriesTotalCount.ToString()
        ], grp_MovieAndSerial));


        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد کل",
        statesticsModel.FilesTotalCount.ToString()
        ], grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فایل های دارای زیرنویس",
       statesticsModel.SubtitlesTotalCount.ToString()
        ], grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فایل های بدون زیرنویس",
        statesticsModel.WithoutSubtitlesTotalCount.ToString()
        ], grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فیلم های دوبله شده",
        statesticsModel.DubbedMoviesTotalCount.ToString()
        ], grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فیلم های دوبله نشده",
        statesticsModel.NotDubbedMoviesTotalCount.ToString()
        ], grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "سریال های دوبله شده",
       statesticsModel.DubbedSeriesTotalCount.ToString()
        ], grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "سریال های دوبله نشده",
        statesticsModel.NotDubbedSeriesTotalCount.ToString()
        ], grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فیلم های دو زبانه",
        statesticsModel.DualAudioMoviesCount.ToString()
        ], grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "فیلم های غیر دو زبانه",
        statesticsModel.NotDualAudioMoviesCount.ToString()
        ], grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "سریال های دو زبانه",
        statesticsModel.DualAudioSeriesCount.ToString()
        ], grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "سریال های غیر دو زبانه",
        statesticsModel.NotDubbedSeriesTotalCount.ToString()
        ], grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد ژانر ها",
       statesticsModel.GenresTotalCount.ToString()
        ], grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد بازیگران",
        statesticsModel.ActorsTotalCount.ToString()
        ], grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد کارگردانان",
        statesticsModel.DirectorsTotalCount.ToString()
        ], grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(
        [
        "تعداد مجموعه ها",
        statesticsModel.CollectionsTotalCount.ToString()
        ], grp_Other));
        await SetMovieCreditAsync();
    }

    private void Frm_Statestics_Load(object sender, EventArgs e)
    {

        //_ = CreateChartAsync();
        List<ComboStatesticsModel> data =
        [
            new () { Id = 1, Title = "ژانر" },
            new () { Id = 2, Title = "سال" },
            new () { Id = 3, Title = "کشور" },
            new () { Id = 4, Title = "رده بندی سنی" },
            new () { Id = 5, Title = "کالکشن" },
            new () { Id = 6, Title = "زبان" } ,
        ];
        Cmb_LoadChart.CesValueMember = "Id";
        Cmb_LoadChart.CesDisplayMember = "Title";
        Cmb_LoadChart.CesDataSource = data;
    }


    private async Task CreateGenreChartAsync()
    {
        Dictionary<string, int> genres = await _genreServices.GetMovieCountPerGenre();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed
        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from KeyValuePair<string, int> genre in genres
                            select new CesChartData { Category = genre.Key, Serie = serieA, Value = genre.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }

    private async Task CreateYearChartAsync()
    {
        Dictionary<string, int> movies = await _movieServices.GetMovieCountPerYear();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed
        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from movie in movies
                            select new CesChartData { Category = movie.Key, Serie = serieA, Value = movie.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }
    private async Task CreateRatedChartAsync()
    {
        Dictionary<string, int> movies = await _movieServices.GetMovieCountPerRated();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed
        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from KeyValuePair<string, int> movie in movies
                            select new CesChartData { Category = movie.Key, Serie = serieA, Value = movie.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }
    private async Task CreateCollectionChartAsync()
    {
        Dictionary<string, int> collections = await _collectionServices.GetMovieCountPerCollection();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed
        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from KeyValuePair<string, int> collection in collections
                            select new CesChartData { Category = collection.Key, Serie = serieA, Value = collection.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }
    private async Task CreateCountryPartChartAsync()
    {
        Dictionary<string, int> countries = await _countryPartServices.GetMovieCountPerCountry();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed

        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from KeyValuePair<string, int> country in countries
                            select new CesChartData { Category = country.Key, Serie = serieA, Value = country.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }
    private async Task CreateLanguageChartAsync()
    {
        Dictionary<string, int> languages = await _languageServices.GetMovieCountPerLanguage();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.DarkRed
        };
        List<CesChartData> listOfData = [];
        listOfData.AddRange(from KeyValuePair<string, int> language in languages
                            select new CesChartData { Category = language.Key, Serie = serieA, Value = language.Value });
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }
    private async void Cmb_LoadChart_CesSelectedItemChanged(object sender, Ces.WinForm.UI.CesComboBox.Events.CesSelectionChangeEvent e)
    {
        if ((int?)Cmb_LoadChart.CesSelectedValue == 1)
            await CreateGenreChartAsync();
        else if ((int?)Cmb_LoadChart.CesSelectedValue == 2)
            await CreateYearChartAsync();
        else if ((int?)Cmb_LoadChart.CesSelectedValue == 3)
            await CreateCountryPartChartAsync();
        else if ((int?)Cmb_LoadChart.CesSelectedValue == 4)
            await CreateRatedChartAsync();
        else if ((int?)Cmb_LoadChart.CesSelectedValue == 5)
            await CreateCollectionChartAsync();
        else if ((int?)Cmb_LoadChart.CesSelectedValue == 6)
            await CreateLanguageChartAsync();
    }
    private async Task<IEnumerable<MovieCredit?>> GetMovieCreditsAsync() => await _movieCreditServices.GetMaxCrews();
    private async Task<IEnumerable<PeopleFile?>> GetPeopleFileAsync(List<string> peopleIds) => await _peopleFileServices.GetPeopleFile(peopleIds: peopleIds);
    private async Task SetMovieCreditAsync()
    {
        IEnumerable<MovieCredit?> credits = await GetMovieCreditsAsync();
        List<string> peopleIds = [.. credits.Select(x => x.PeopleId).Distinct()];
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
    .OrderBy(x => x.EnCreditTypeName)
    .Select(x => AttachHandler(ToShowCrews(x)))];
        ShowCrews AttachHandler(ShowCrews ctrl)
        {
            ctrl.PicClicked += PeopleBox_PosterClicked;
            return ctrl;
        }
        Flw_Crews.Controls.AddRange(crewControls);
    }
    private void PeopleBox_PosterClicked(object sender, string peopleId)
    {
        Frm_EditPeople frm_EditPeople = new(
           peopleId: peopleId,
           peopleServices: _peopleServices,
           peopleFileServices: _peopleFileServices,
           deathCauseServices: _deathCauseServices,
           movieCreditServices: _movieCreditServices,
           movieServices: _movieServices,
           path:_path

           );
        frm_EditPeople.ShowDialog();
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



    
}

