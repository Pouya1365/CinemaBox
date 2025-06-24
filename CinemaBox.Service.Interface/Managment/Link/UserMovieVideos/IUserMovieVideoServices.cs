using CinemaBox.Domain.Managment.Link.UserMovieVideos;

namespace CinemaBox.Service.Interface.Managment.Link.UserMovieVideos;

public interface IUserMovieVideoServices
{
    Task<UserMovieVideo> GetMovieVideoAsync(string movieId);
    Task CreateOrUpdateUserMovieVideoAsync(UserMovieVideo userMovieVideo);
}
