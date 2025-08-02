using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using CinemaBox.Model.Statestics;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Managment.Link.UserMovieDisks;

public class UserMovieDiskServices(IUnitOfWork unitOfWork) : IUserMovieDiskServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<UserMovieDisk> GetMovieDiskAsync(string movieId) => await _unitOfWork.Repository<UserMovieDisk>().FindAsync(x => x.Id == movieId,x=>x.Status);
    public async Task CreateOrUpdateUserMovieDiskAsync(UserMovieDisk userMovieDisk)
    {
        UserMovieDisk? existingDisk = await GetMovieDiskAsync(movieId: userMovieDisk.Id);
        if (existingDisk == null)
            await _unitOfWork.Repository<UserMovieDisk>().AddAsync(userMovieDisk);
        else
        {
            MapTo(userMovieDisk, existingDisk);
            _unitOfWork.Repository<UserMovieDisk>().Update(existingDisk); 
        }
        await _unitOfWork.CompleteAsync();
    }
    private void MapTo(UserMovieDisk source, UserMovieDisk target)
    {
        target.MovieNumber = source.MovieNumber;
        target.FileName = source.FileName;
        target.MyTime = source.MyTime;
        target.PositionMovie = source.PositionMovie;
        target.FileSize = source.FileSize;
        target.IsDubbed = source.IsDubbed;
        target.IsSubtitle = source.IsSubtitle;
    }

    public async Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel)
    {
        IEnumerable<UserMovieDisk> disk =await _unitOfWork.Repository<UserMovieDisk>().GetAllAsync();
        statesticsModel.SubtitlesTotalCount = disk.Where(x => x.IsSubtitle == true).Count();
        statesticsModel.WithoutSubtitlesTotalCount=disk.Where(x => x.IsSubtitle == false).Count();
        statesticsModel.DubbedMoviesTotalCount=disk.Where(x => x.IsDubbed == true).Count();
        statesticsModel.NotDubbedMoviesTotalCount=disk.Where(x => x.IsDubbed == false).Count();
        return statesticsModel;
    }
}
