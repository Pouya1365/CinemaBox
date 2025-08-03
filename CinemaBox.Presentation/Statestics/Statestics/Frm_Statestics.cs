using Ces.WinForm.UI.CesChart;
using Ces.WinForm.UI.CesComboBox;
using Ces.WinForm.UI.CesForm;
using CinemaBox.Model.Statestics;
using CinemaBox.Service.Division.CountryParts;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
    public Frm_Statestics(IMovieServices movieServices,
        IGenreServices genreServices,
        IMovieCreditServices movieCreditServices,
        ICollectionServices collectionServices,
        IUserMovieFileServices userMovieFileServices,
        IUserMovieAudioServices userMovieAudioServices,
        IUserMovieDiskServices userMovieDiskServices,
        ICountryPartServices countryPartServices
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
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد کل",
         statesticsModel.Total.ToString()
        }, grp_MovieAndSerial));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد فیلم ها",
        statesticsModel.MovieTotalCount.ToString()
        }, grp_MovieAndSerial));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد سریال ها",
       statesticsModel.TvSeriesTotalCount.ToString()
        }, grp_MovieAndSerial));


        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد کل",
        statesticsModel.FilesTotalCount.ToString()
        }, grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فایل های دارای زیرنویس",
       statesticsModel.SubtitlesTotalCount.ToString()
        }, grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فایل های بدون زیرنویس",
        statesticsModel.WithoutSubtitlesTotalCount.ToString()
        }, grp_File));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فیلم های دوبله شده",
        statesticsModel.DubbedMoviesTotalCount.ToString()
        }, grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فیلم های دوبله نشده",
        statesticsModel.NotDubbedMoviesTotalCount.ToString()
        }, grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "سریال های دوبله شده",
       statesticsModel.DubbedSeriesTotalCount.ToString()
        }, grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "سریال های دوبله نشده",
        statesticsModel.NotDubbedSeriesTotalCount.ToString()
        }, grp_Dubbed));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فیلم های دو زبانه",
        statesticsModel.DualAudioMoviesCount.ToString()
        }, grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "فیلم های غیر دو زبانه",
        statesticsModel.NotDualAudioMoviesCount.ToString()
        }, grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "سریال های دو زبانه",
        statesticsModel.DualAudioSeriesCount.ToString()
        }, grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "سریال های غیر دو زبانه",
        statesticsModel.NotDubbedSeriesTotalCount.ToString()
        }, grp_TwoLanguages));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد ژانر ها",
       statesticsModel.GenresTotalCount.ToString()
        }, grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد بازیگران",
        statesticsModel.ActorsTotalCount.ToString()
        }, grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد کارگردانان",
        statesticsModel.DirectorsTotalCount.ToString()
        }, grp_Other));
        Lst_Statestics.Items.Add(new ListViewItem(new string[2]
        {
        "تعداد مجموعه ها",
        statesticsModel.CollectionsTotalCount.ToString()
        }, grp_Other));
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
            new () { Id = 7, Title = "سال" }
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
            SeriColor = Color.Red
        };
        List<CesChartData> listOfData = [];
        foreach (var genre in genres)
            listOfData.Add(new CesChartData { Category = genre.Key, Serie = serieA, Value = genre.Value });
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
            SeriColor = Color.Blue
        };
        List<CesChartData> listOfData = [];
        foreach (var movie in movies)
            listOfData.Add(new CesChartData { Category = movie.Key, Serie = serieA, Value = movie.Value });
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
            SeriColor = Color.LemonChiffon
        };
        List<CesChartData> listOfData = [];
        foreach (var movie in movies)
            listOfData.Add(new CesChartData { Category = movie.Key, Serie = serieA, Value = movie.Value });
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
            SeriColor = Color.Green
        };
        List<CesChartData> listOfData = [];
        foreach (var country in countries)
            listOfData.Add(new CesChartData { Category = country.Key, Serie = serieA, Value = country.Value });
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
    }
}

