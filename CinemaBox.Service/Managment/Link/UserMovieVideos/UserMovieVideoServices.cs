using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Service.Interface.Managment.Link.UserMovieVideos;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Managment.Link.UserMovieVideos;

public class UserMovieVideoServices(IUnitOfWork unitOfWork) : IUserMovieVideoServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<UserMovieVideo> GetMovieVideoAsync(string movieId) => await _unitOfWork.Repository<UserMovieVideo>().FindAsync(x => x.Id == movieId,x=>x.Format);
    public async Task CreateOrUpdateUserMovieVideoAsync(UserMovieVideo userMovieVideo)
    {
        UserMovieVideo? existingVideo = await GetMovieVideoAsync(movieId: userMovieVideo.Id);
        if (existingVideo == null)
            await _unitOfWork.Repository<UserMovieVideo>().AddAsync(userMovieVideo);
        else
        {
            MapTo(userMovieVideo, existingVideo);
            _unitOfWork.Repository<UserMovieVideo>().Update(existingVideo);
        }
        await _unitOfWork.CompleteAsync();
    }
    private void MapTo(UserMovieVideo source, UserMovieVideo target)
    {
        target.FormatId = source.FormatId;
        target.BitRate = source.BitRate;
        target.FPS = source.FPS;
        target.AspectRatio = source.AspectRatio;
        target.Resolution = source.Resolution;
    }
}
