
namespace CinemaBox.UserController.People.People
{
    public partial class ShowPeoples : UserControl
    {

        private string? _picUrl;
        private string? _enfullName;
        private string? _faFullName;
        private string? _id;
        public event EventHandler<string?>? PicClicked;
        public ShowPeoples( string? pictureUrl, string? enfullName, string? faFullName, string? id)
    {
                _picUrl = pictureUrl;
                _enfullName = enfullName;
                _faFullName = faFullName;
                _id = id;
                InitializeComponent();
                LoadInfo();
        }
        private void LoadInfo()
        {
            Pic_People.CesImage = _picUrl != null ? Image.FromFile(filename: _picUrl) : null;
            Txt_FullName.Text = !string.IsNullOrEmpty(_faFullName) ? $"{_enfullName} ( {_faFullName} )" : _enfullName;
        }

        private void Pic_People_Click(object sender, EventArgs e) => PicClicked?.Invoke(this, _id);

    }
}
