using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Enumeration.Shared.Languages;
using CinemaBox.Model.Statestics;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.UnitOfWork.Interface.UOW;
using System.Linq;

namespace CinemaBox.Service.Managment.Link.UserMovieAudios;

public class UserMovieAudioServices(IUnitOfWork unitOfWork) : IUserMovieAudioServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<IEnumerable<UserMovieAudio>> GetUserMovieAudioAsync(string movieId) => await _unitOfWork.Repository<UserMovieAudio>().GetAllAsync(x => x.MovieId == movieId);
    public async Task RemoveUserMovieAudio(IEnumerable<UserMovieAudio> userMovieAudios)
    {
        foreach (UserMovieAudio userMovieAudio in userMovieAudios)
            _unitOfWork.Repository<UserMovieAudio>().Remove(userMovieAudio);
        await _unitOfWork.CompleteAsync();
    }
    public async Task CreateUserMovieAudioAsync(List<UserMovieAudio> userMovieAudios)
    {
        await _unitOfWork.Repository<UserMovieAudio>().AddRangeAsync(userMovieAudios);
        await _unitOfWork.CompleteAsync();
    }
    public async Task<IEnumerable<UserMovieAudio>> GetMovieAudiosAsync(string movieId) => await _unitOfWork.Repository<UserMovieAudio>().GetAllWithPredicateAsync(x => x.MovieId == movieId, x => x.Language, x => x.Format);

    public async Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel)
    {
        IEnumerable<UserMovieAudio> audio = await _unitOfWork.Repository<UserMovieAudio>().GetAllWithIncludesAsync(x=>x.Language);
        IEnumerable<UserMovieAudio> faAudio = audio.Where(x => x.Language.IsoCode == LanguagesEnumeration.fa.ToString());
        IEnumerable<UserMovieAudio> otherAudio = audio.Where(x => x.Language.IsoCode != LanguagesEnumeration.fa.ToString());
        statesticsModel.DualAudioMoviesCount = faAudio.Count();
        statesticsModel.NotDualAudioMoviesCount = otherAudio.Count();
        return statesticsModel; 
    }
}