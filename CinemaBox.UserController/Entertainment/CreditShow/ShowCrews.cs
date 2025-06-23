using CinemaBox.Enumeration.Entertainment.Crew;

namespace CinemaBox.UserController.Entertainment.CreditShow;

public partial class ShowCrews : UserControl
{
    private string? _picUrl;
    private string? _enfullName;
    private string? _faFullName;
    private string? _enCreditType;
    private string? _faCreditType;
    private string? _roleName;
    private bool? _isLeadRole;
    private string? _id;
    public event EventHandler<string?>? PicClicked;
    public ShowCrews(string? pictureUrl, string? enfullName, string? faFullName, string? encreditType, string? facreditType, string? roleName, bool? isLeadRole, string? id)
    {
        _picUrl = pictureUrl;
        _enfullName = enfullName;
        _faFullName = faFullName;
        _enCreditType = encreditType;
        _faCreditType = facreditType;
        _roleName = roleName;
        _isLeadRole = isLeadRole;
        _id = id;
        InitializeComponent();
        LoadInfo();
    }
    private void LoadInfo()
    {
        Pic_People.CesImage = _picUrl != null ? Image.FromFile(filename: _picUrl) : null;
        Txt_FullName.Text = !string.IsNullOrEmpty(_faFullName) ? $"{_enfullName} ( {_faFullName} )" : _enfullName;
        Txt_CreditType.Text = _faCreditType;
        if (_enCreditType == CreditEnumeration.Cast.ToString())
        {
            Chk_IsLeadRole.CesCheck = _isLeadRole;
            Txt_RoleName.Text = _roleName;
        }
        else
        {
            Chk_IsLeadRole.Visible = false;
            Txt_RoleName.Visible = false;
        }
    }

    private void Pic_People_Load(object sender, EventArgs e)=>
        PicClicked?.Invoke(this, _id);
   
}

