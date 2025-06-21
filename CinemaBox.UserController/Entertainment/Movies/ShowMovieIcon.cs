namespace CinemaBox.UserController.Entertainment.Movies;

public partial class ShowMovieIcon : UserControl
{
    public readonly string PosterPath;
    public readonly string EnTitle;
    public readonly string FaTitle;
    public readonly long Year;
    public readonly long? EndYear;
    public readonly string MovieId;
    public event EventHandler<string?>? PosterClicked;
    public ShowMovieIcon(string posterPath, string enTitle, string faTitle, long year, long? endYear, string movieId)
    {
        InitializeComponent();
        PosterPath = posterPath;
        EnTitle = enTitle;
        FaTitle = faTitle;
        Year = year;
        EndYear = endYear;
        MovieId = movieId;
        LoadData();
    }
    public void LoadData()
    {
        Pic_Poster.Image = Image.FromFile(filename: PosterPath);
        Lbl_Title.Text = !string.IsNullOrEmpty(FaTitle) ? $"{EnTitle} ( {FaTitle} )" : EnTitle;
        Lbl_Year.Text = EndYear != null ? $"{Year}-{EndYear}" : Year.ToString();
    }
    private void Pic_Poster_Click(object sender, EventArgs e)
    {
        PosterClicked?.Invoke(this, MovieId);
    }
}