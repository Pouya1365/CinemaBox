using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Genres;

public class GenreServices(IUnitOfWork unitOfWork) : IGenreServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Genre?> CreateOrGetGenreAsync(string? GenreName)
    {
        if (string.IsNullOrWhiteSpace(GenreName))
            return null;
        Genre? Genre = await GetGenreAsync(genreName: GenreName);
        if (Genre == null)
        {
            Genre = new Genre {  EnGenreName = GenreName.Trim() };
            await _unitOfWork.Repository<Genre>().AddAsync(Genre);
            await _unitOfWork.CompleteAsync();
        }
        return Genre;
    }
    public async Task<Genre?> GetGenreAsync(string genreName)
    {
        if (string.IsNullOrWhiteSpace(genreName))
            return null;
        return await _unitOfWork.Repository<Genre>()
            .FindAsync(g => g.EnGenreName == genreName||g.FaGenreName== genreName);

    }
}