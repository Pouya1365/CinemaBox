using CinemaBox.Domain.Managment.Link.UserMovieDisks;

namespace CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;

public interface IUserMovieDiskServices
{
    Task<UserMovieDisk> GetMovieDiskAsync(string movieId);
    Task CreateOrUpdateUserMovieDiskAsync(UserMovieDisk userMovieDisk);
}
