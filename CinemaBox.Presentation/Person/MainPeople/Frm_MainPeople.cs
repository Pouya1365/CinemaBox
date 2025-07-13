using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast.CreditShow;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Model.Entertainment.People.ShowPeople;
using CinemaBox.Presentation.Person.Peoples;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.Service.Person.Peoples;
using CinemaBox.Service.Shared.DeathCauses;
using CinemaBox.UserController.Entertainment.CreditShow;
using CinemaBox.UserController.Entertainment.Movies;
using CinemaBox.UserController.People.People;

namespace CinemaBox.Presentation.Person.MainPeople;

public partial class Frm_MainPeople : CesForm
{
    private readonly IPeopleFileServices? _peopleFileServices;
    private readonly IPeopleServices? _peopleServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private List<ShowPeopleModel> _allPeople = new();
    private int _loadedCount = 0;
    private const int PageSize = 50;
    public Frm_MainPeople(IPeopleFileServices? peopleFileServices,
   IPeopleServices? peopleServices,
   IDeathCauseServices? deathCauseServices)
    {
        _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
        InitializeComponent();
        LoadPeopleAsync();
    }
    private async Task LoadPeopleAsync()
    {
        var peopleModels = await GetPeopleModels();

        _allPeople = peopleModels
            .Where(x => x != null)
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
            })
            .ToList();

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
           deathCauseServices: _deathCauseServices

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
}
