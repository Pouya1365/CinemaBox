using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Model.Statestics;

namespace CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;

public interface IUserMovieAudioServices
{
    Task<IEnumerable<UserMovieAudio>> GetUserMovieAudioAsync(string movieId);
    Task RemoveUserMovieAudio(IEnumerable<UserMovieAudio> userMovieAudios);
    Task CreateUserMovieAudioAsync(List<UserMovieAudio> userMovieAudios);
    Task<IEnumerable<UserMovieAudio>> GetMovieAudiosAsync(string movieId);
    Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel);
}


