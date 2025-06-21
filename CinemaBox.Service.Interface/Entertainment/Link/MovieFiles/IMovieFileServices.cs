namespace CinemaBox.Service.Interface.Entertainment.Link.MovieFiles;

public interface IMovieFileServices
{
    Task CreateOrUpdateMovieImage(string path, string imageUrl, string movieId, string movieName);
}
