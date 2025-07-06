using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;

namespace CinemaBox.Service.Entertainment.Genres;

public class GenreServices(IUnitOfWork unitOfWork, ITranslate translate) : IGenreServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<Genre?> CreateOrGetGenreAsync(string? genreName)
    {
        if (string.IsNullOrWhiteSpace(genreName))
            return null;
        Genre? Genre = await GetGenreAsync(genreName: genreName);
        if (Genre == null)
        {
            string faGenreName = await GetFa(genreName: genreName);
            Genre = new Genre {  EnGenreName = genreName.Trim() ,FaGenreName=faGenreName};
            await _unitOfWork.Repository<Genre>().AddAsync(Genre);
            await _unitOfWork.CompleteAsync();
        }
        return Genre;
    }
    private async Task<string> GetFa(string genreName) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: genreName));
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