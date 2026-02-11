namespace CinemaBox.UserController.Entertainment.Movies;

public partial class ShowMovieIcon : UserControl
{
    public readonly string _posterPath;
    public readonly string _enTitle;
    public readonly string _faTitle;
    public readonly long _year;
    public readonly long? _endYear;
    public readonly string _movieId;
    public event EventHandler<string?>? PosterClicked;
    public ShowMovieIcon(string posterPath, string enTitle, string faTitle, long year, long? endYear, string movieId)
    {
        InitializeComponent();
        _posterPath = posterPath;
        _enTitle = enTitle;
        _faTitle = faTitle;
        _year = year;
        _endYear = endYear;
        _movieId = movieId;
        LoadData();
    }
    public void LoadData()
    {
        if (!_posterPath.Contains("https"))
            Pic_Poster.Image = string.IsNullOrEmpty(_posterPath) ? null : Image.FromFile(filename: _posterPath);
        else if (_posterPath.Contains("https"))
            Pic_Poster.Load(_posterPath);
        Lbl_Title.Text = !string.IsNullOrEmpty(_faTitle) ? $"{_enTitle} ( {_faTitle} )" : _enTitle;
        Lbl_Year.Text = _endYear != null ? $"{_year}-{_endYear}" : _year.ToString();
    }
    private void Pic_Poster_Click(object sender, EventArgs e) =>
        PosterClicked?.Invoke(this, _movieId);
}