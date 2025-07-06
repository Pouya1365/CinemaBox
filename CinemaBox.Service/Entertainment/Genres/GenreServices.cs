using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Genres;

public class GenreServices(IUnitOfWork unitOfWork) : IGenreServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Genre?> CreateOrGetGenreAsync(string? genreName)
    {
        if (string.IsNullOrWhiteSpace(genreName))
            return null;
        Genre? Genre = await GetGenreAsync(genreName: genreName);
        if (Genre == null)
        {
            Genre = new Genre {  EnGenreName = genreName.Trim() };
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
    public async Task<List<Genre>?> GetAllGenreFaNull() => await _unitOfWork.Repository<Genre>()
          .GetAllListAsync(g => g.FaGenreName == null);
    public async Task UpdateFaGenre(List<Genre> genres)
    {
        foreach (Genre genre in genres)
            _unitOfWork.Repository<Genre>().Update(genre);
        if (genres.Any())
            await _unitOfWork.CompleteAsync();
    }
}