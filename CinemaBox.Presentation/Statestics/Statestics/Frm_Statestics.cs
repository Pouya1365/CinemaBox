using Ces.WinForm.UI.CesChart;
using Ces.WinForm.UI.CesForm;
using CinemaBox.Model.Statestics;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;

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
    public Frm_Statestics(IMovieServices movieServices,
        IGenreServices genreServices,
        IMovieCreditServices movieCreditServices,
        ICollectionServices collectionServices,
        IUserMovieFileServices userMovieFileServices,
        IUserMovieAudioServices userMovieAudioServices,
        IUserMovieDiskServices userMovieDiskServices
        )
    {
        _movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _genreServices = genreServices ?? throw new ArgumentNullException(nameof(genreServices));
        _movieCreditServices = movieCreditServices ?? throw new ArgumentNullException(nameof(movieCreditServices));
        _collectionServices = collectionServices ?? throw new ArgumentNullException(nameof(collectionServices));
        _userMovieFileServices = userMovieFileServices ?? throw new ArgumentNullException(nameof(userMovieFileServices));
        _userMovieAudioServices = userMovieAudioServices ?? throw new ArgumentNullException(nameof(userMovieAudioServices));
        _userMovieDiskServices = userMovieDiskServices ?? throw new ArgumentNullException(nameof(userMovieDiskServices));
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
        _=CreateChartAsync();
    }
    private async Task CreateChartAsync()
    {
        Dictionary<string, int> genres =await _genreServices.GetMovieCountPerGenre();
        CesChartSerie serieA = new()
        {
            Type = CesChartTypeEnum.Column,
            Name = "Serie A",
            SeriColor = Color.Red
        };
        List<CesChartData> listOfData = [];
        foreach (var genre in genres)        
            listOfData.Add(new CesChartData { Category= genre.Key,Serie=serieA,Value= genre.Value});   
        Chart.CesData = listOfData;
        Chart.GenerateChart();
    }

}

