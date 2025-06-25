using CinemaBox.Domain.Managment.Link.UserMovieFiles;


namespace CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;

public interface IUserMovieFileServices
{
    Task CreateOrUpdateUserMovieImage(string path, byte[] image, string movieId, string movieName);
    Task<UserMovieFile> GetUserMovieFile(string movieId);

}
