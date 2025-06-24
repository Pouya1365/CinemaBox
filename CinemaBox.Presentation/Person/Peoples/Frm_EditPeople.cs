using Ces.WinForm.UI.CesForm;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using System.Globalization;

namespace CinemaBox.Presentation.Person.Peoples;

public partial class Frm_EditPeople : CesForm
{
    private readonly IPeopleServices? _peopleServices;
    private readonly IPeopleFileServices? _peopleFileServices;
    private readonly string? _peopleId;
    public Frm_EditPeople(string? peopleId,
        IPeopleServices? peopleServices,
        IPeopleFileServices peopleFileServices)
    {
        _peopleId = peopleId;
        _peopleServices = peopleServices;
        _peopleFileServices = peopleFileServices;
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
        //await LoadComboDataAsync("Rateds", Cmb_Certificate, c => new CesListBoxItemProperty { Text = c.CertificateName ?? "-", Value = (int)c.Id }, movie.CertificateId);

    }
    private async Task<People?> GetPeople() => await _peopleServices.GetPeople(peopleId: _peopleId);

    private async Task SetLoadPicture()
    {
        PeopleFile? peopleFiles = await GetPeopleFileAsync(peopleId: _peopleId);
        string? picUrl = peopleFiles != null && peopleFiles.File != null && peopleFiles.File.Server != null
            ? Path.Combine(Application.StartupPath, peopleFiles.File.Server.Path, peopleFiles.File.FileName)
            : null;
        Pic_Crew.Image = Image.FromFile(picUrl);
    }
    private async Task<PeopleFile?> GetPeopleFileAsync(string peopleId) => await _peopleFileServices.GetPeopleFileWitInclude(peopleId: peopleId);
}
