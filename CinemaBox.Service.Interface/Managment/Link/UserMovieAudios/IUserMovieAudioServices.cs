using CinemaBox.Domain.Managment.Link.UserMovieAudios;

namespace CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;

public interface IUserMovieAudioServices
{
    Task<IEnumerable<UserMovieAudio>> GetUserMovieAudioAsync(string movieId);
    Task RemoveUserMovieAudio(IEnumerable<UserMovieAudio> userMovieAudios);
    Task CreateUserMovieAudioAsync(List<UserMovieAudio> userMovieAudios);
}


