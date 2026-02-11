using Ces.WinForm.UI.CesForm;
using CinemaBox.Model.Entertainment.People.ShowPeople;
using CinemaBox.Presentation.Person.Peoples;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.UserController.People.People;
using System.Threading.Tasks;

namespace CinemaBox.Presentation.Person.MainPeople;

public partial class Frm_MainPeople : CesForm
{
    private readonly IPeopleFileServices? _peopleFileServices;
    private readonly IPeopleServices? _peopleServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private readonly IMovieCreditServices? _movieCreditServices;
    private readonly IMovieServices? _movieServices;
    private readonly string? _path;
    private List<ShowPeopleModel> _allPeople = [];
    private int _loadedCount = 0;
    private const int PageSize = 50;
    public Frm_MainPeople(IPeopleFileServices? peopleFileServices,
   IPeopleServices? peopleServices,
   IDeathCauseServices? deathCauseServices,
   IMovieCreditServices? movieCreditServices,
   IMovieServices? movieServices,
   string? path
   )
    {
        //_peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
        _movieCreditServices = movieCreditServices ?? throw new ArgumentNullException(nameof(movieCreditServices));
        movieServices = movieServices ?? throw new ArgumentNullException(nameof(movieServices));
        _path = path;
        InitializeComponent();
       _= LoadPeopleAsync(Txt_Search.CesText);
    }
    private async Task LoadPeopleAsync(string?search)
    {
        var peopleModels = await GetPeopleModels();

        _allPeople = [.. peopleModels
            .Where(x => search != null ?x.PeopleId.Contains(search)||x.EnFullName.Contains(search)||x.FaFullName.Contains(search):x!=null)
            .Select(x => new ShowPeopleModel
            {
                EnFullName = x.EnFullName,
                FaFullName = x.FaFullName,
                PeopleId = x.PeopleId,
                PosterPath = !string.IsNullOrWhiteSpace(x.PosterPath)
                    ? Path.IsPathRooted(x.PosterPath)
                        ? x.PosterPath
                        : Path.Combine(Application.StartupPath, x.PosterPath)
                    : null
            })];

        Flw_ShowPeople.Controls.Clear();
        _loadedCount = 0;
        LoadNextPeoplePage();
    }
    private void LoadNextPeoplePage()
    {
        int takeCount = Math.Min(PageSize, _allPeople.Count - _loadedCount);

        var nextPeople = _allPeople
            .Skip(_loadedCount)
            .Take(takeCount)
            .Select(x => AttachHandler(ToShowCrews(x)))
            .ToArray();

        Flw_ShowPeople.Controls.AddRange(nextPeople);
        _loadedCount += takeCount;
    }
    private ShowPeoples AttachHandler(ShowPeoples ctrl)
    {
        ctrl.PicClicked += PeopleBox_PosterClicked;
        return ctrl;
    }



    private void CheckLoadMore()
    {
        if (Flw_ShowPeople.VerticalScroll.Value + Flw_ShowPeople.ClientSize.Height >= Flw_ShowPeople.VerticalScroll.Maximum - 100)
        {
            LoadNextPeoplePage();
        }
    }
    private async Task<IEnumerable<ShowPeopleModel>> GetPeopleModels() => await _peopleServices.GetAllPeopleModel(search: Txt_Search.CesText);
    private void PeopleBox_PosterClicked(object sender, string peopleId)
    {
        Frm_EditPeople frm_EditPeople = new(
           peopleId: peopleId,
           peopleServices: _peopleServices,
           peopleFileServices: _peopleFileServices,
           deathCauseServices: _deathCauseServices,
           movieCreditServices: _movieCreditServices,
           movieServices: _movieServices,
           path: _path

            );
        frm_EditPeople.ShowDialog();
    }
    private ShowPeoples ToShowCrews(ShowPeopleModel model) => new(
                pictureUrl: model.PosterPath,
                enfullName: model.EnFullName,
                faFullName: model.FaFullName,
                id: model.PeopleId
            );

    private void Flw_ShowPeople_Scroll(object sender, ScrollEventArgs e)
    {
        CheckLoadMore();
    }

    private void Flw_ShowPeople_Layout(object sender, LayoutEventArgs e)
    {
        Flw_ShowPeople.Layout += (s, e) => CheckLoadMore();


    }

    private async void Btn_Search_Click(object sender, EventArgs e)
    {
        await LoadPeopleAsync(Txt_Search.CesText);
    }
}
