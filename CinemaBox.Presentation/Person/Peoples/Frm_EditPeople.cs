using Ces.WinForm.UI.CesComboBox;
using Ces.WinForm.UI.CesForm;
using Ces.WinForm.UI.CesListBox;
using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.Service.Shared.Qualities.QualityTypes;
using System.Globalization;

namespace CinemaBox.Presentation.Person.Peoples;

public partial class Frm_EditPeople : CesForm
{
    private readonly IPeopleServices? _peopleServices;
    private readonly IPeopleFileServices? _peopleFileServices;
    private readonly IDeathCauseServices? _deathCauseServices;
    private readonly string? _peopleId;
    public Frm_EditPeople(string? peopleId,
        IPeopleServices? peopleServices,
        IPeopleFileServices peopleFileServices,
        IDeathCauseServices? deathCauseServices
        )
    {
        _peopleId = peopleId;
        _peopleServices = peopleServices ?? throw new ArgumentNullException(nameof(peopleServices));
        _peopleFileServices = peopleFileServices ?? throw new ArgumentNullException(nameof(peopleFileServices));
        _deathCauseServices = deathCauseServices ?? throw new ArgumentNullException(nameof(deathCauseServices));
        InitializeComponent();
        _ = IntialData();
    }

    public async Task IntialData()
    {
        await SetMovieBasicFields();
        await SetLoadPicture();
    }
    private async Task SetMovieBasicFields()
    {
        People? people = await GetPeople();
        //Currency currency = await GetCurrency(movie.BudgetCurrencyId);
        Txt_EnFullName.CesText = people.EnFullName;
        Txt_FaFullName.CesText = people.FaFullName;
        Txt_Imdb.CesText = people.Id;
        Txt_BirthDate.CesText = people.BornDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        Txt_BirthDateShamsiYear.CesText = people.BornDate.ToString();
        Txt_DeathDate.CesText = people?.DeathDate?.ToString();
        Txt_BornPlace.CesText = people.BornPlace;
        Txt_DeadPlace.CesText = people.DeathPlace;
        Txt_BirthName.CesText = people.BirthName;
        Txt_NickName.CesText = people.NickName;
        Txt_Height.CesText = people.Height;
        Txt_EnMiniBioGraphy.CesText = people.EnMiniBiography;
        Txt_FaMiniBioGraphy.CesText = people.FaMiniBiography;
        //public int? DeathCauseId { get; set; }
        await LoadDeath(deathId: people.DeathCauseId);
    }
    private async Task<People?> GetPeople() => await _peopleServices.GetPeople(peopleId: _peopleId);
    private async Task LoadDeath(int? deathId) => await LoadComboBoxDataAsync<DeathCause>(
"Rateds",
Cmb_DeathCuase,
GetDeathCauseAsync,
d => new CesListBoxItemProperty { Value = d.Id, Text = (d.FaDeathCauseName??d.EnDeathCauseName) },
deathId);

    private async Task<IEnumerable<DeathCause>> GetDeathCauseAsync() => await _deathCauseServices.GetDeathCauseAllAsync();
    private async Task SetLoadPicture()
    {
        PeopleFile? peopleFiles = await GetPeopleFileAsync(peopleId: _peopleId);
        string? picUrl = peopleFiles != null && peopleFiles.File != null && peopleFiles.File.Server != null
            ? Path.Combine(Application.StartupPath, peopleFiles.File.Server.Path, peopleFiles.File.FileName)
            : null;
        Pic_Crew.Image = Image.FromFile(picUrl);
    }
    private async Task<PeopleFile?> GetPeopleFileAsync(string peopleId) => await _peopleFileServices.GetPeopleFileWitInclude(peopleId: peopleId);
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
            // اگر selectedId نداشت، هیچ چیزی انتخاب نکن
            comboBox.CesSelectedItem = null; // انتخاب آیتم خالی
        
    }
}
