using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Libretranslate.Interface;
using CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Html;

namespace CinemaBox.Service.Entertainment.Link.MovieTaglines;

public class MovieTaglineServices(IUnitOfWork unitOfWork, ITranslate translate) : IMovieTaglineServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ITranslate _translate = translate ?? throw new ArgumentNullException(nameof(translate));
    public async Task<List<MovieTagline>> CreateMovieTagline(List<string> taglineModels, string movieId)
    {
        List<MovieTagline> MovieTaglines = [];
        foreach (var taglineModel in taglineModels)
        {
            string faTagline = await GetFa(tagline: taglineModel);
            MovieTaglines.Add(new MovieTagline
            {
                FaTagline = faTagline,
                EnTagline = taglineModel,
                MovieId = movieId,
            });
        }
        await _unitOfWork.Repository<MovieTagline>().AddRangeAsync(MovieTaglines);
        await _unitOfWork.CompleteAsync();
        return MovieTaglines;
    }
    public async Task<IEnumerable<MovieTagline?>> GetMovieTagline(string movieId) =>await _unitOfWork.Repository<MovieTagline>().GetAllAsync(x => x.MovieId == movieId);
    private async Task<string> GetFa(string tagline) => HtmlDecode.HtmlDecoding(await _translate.TranslateText(text: tagline));
    public async Task<List<MovieTagline>?> GetAllMovieTaglineFaNull() => await _unitOfWork.Repository<MovieTagline>()
         .GetAllListAsync(mt => mt.FaTagline == null);
    public async Task UpdateFaMovieTagline(List<MovieTagline> movieTaglines)
    {
        foreach (MovieTagline movieTagline in movieTaglines)
            _unitOfWork.Repository<MovieTagline>().Update(movieTagline);
        if (movieTaglines.Any())
            await _unitOfWork.CompleteAsync();
    }
}
