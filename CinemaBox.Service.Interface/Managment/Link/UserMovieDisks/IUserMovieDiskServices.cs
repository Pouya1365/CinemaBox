using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using CinemaBox.Model.Statestics;

namespace CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;

public interface IUserMovieDiskServices
{
    Task<UserMovieDisk> GetMovieDiskAsync(string movieId);
    Task CreateOrUpdateUserMovieDiskAsync(UserMovieDisk userMovieDisk);
    Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel);
}
