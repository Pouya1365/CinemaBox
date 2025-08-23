using Ces.WinForm.UI.CesForm;
using CinemaBox.Model.MediaInfo.MediaInfo;
using CinemaBox.Service.Entertainment.Movies;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.TvMaz.Interfaces.TvMaz;
using TvMaze.Api.Client.Models;

namespace CinemaBox.Presentation.TvMaz;

public partial class Frm_TvMaz : CesForm
{
    private readonly ITvMazServices? _tvMazServices;
    public Frm_TvMaz(ITvMazServices? tvMazServices)
    {
        _tvMazServices = tvMazServices ?? throw new ArgumentNullException(nameof(tvMazServices));
        InitializeComponent();

        _=LoadGride();
    }
    private async Task LoadGride()
    {
        IEnumerable<Episode> lstTvMaz = await _tvMazServices.IsTvSchedule();
        Dgv_TvMaz.CesDataSource = lstTvMaz;
        Dgv_TvMaz.ReadOnly = true; // فعال‌سازی ویرایش
    }
}
