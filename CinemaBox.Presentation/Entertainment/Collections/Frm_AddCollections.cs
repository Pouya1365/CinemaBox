using Ces.WinForm.UI.CesForm;
using CinemaBox.Service.Interface.Entertainment.Collections;
using System.Threading.Tasks;

namespace CinemaBox.Presentation.Entertainment.Collections;

public partial class Frm_AddCollections : CesForm
{
    private readonly ICollectionServices? _collectionServices;
    public Frm_AddCollections(ICollectionServices? collectionServices)
    {
        _collectionServices = collectionServices ?? throw new ArgumentNullException(nameof(collectionServices));
        InitializeComponent();
    }

    private void Btn_Cancel_Click(object sender, EventArgs e) => this.Close();

    private async void Btn_Ok_Click(object sender, EventArgs e)
    {
        await CreatCollection();
        this.Close();
    }
    private async Task CreatCollection() => await _collectionServices.CreateOrGetCollectoion(encollectionName: Txt_EnCollectionName.CesText.Trim(), faCollectionName: Txt_FaCollectionName.CesText.Trim());
}
