using CinemaBox.Domain.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieTaglines;

public class MovieTaglineServices(IUnitOfWork unitOfWork) : IMovieTaglineServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<List<MovieTagline>> CreateMovieTagline(List<string> taglineModels, string movieId)
    {
        List<MovieTagline> MovieTaglines = [];
        foreach (var taglineModel in taglineModels)
            MovieTaglines.Add(new MovieTagline
            {
                EnTagline = taglineModel,
                MovieId = movieId,
            });
        await _unitOfWork.Repository<MovieTagline>().AddRangeAsync(MovieTaglines);
        await _unitOfWork.CompleteAsync();
        return MovieTaglines;
    }
    public async Task<IEnumerable<MovieTagline?>> GetMovieTagline(string movieId) =>await _unitOfWork.Repository<MovieTagline>().GetAllAsync(x => x.MovieId == movieId);
}
