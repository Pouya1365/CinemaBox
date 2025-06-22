using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieGenres;

public class MovieGenreServices(IUnitOfWork unitOfWork, IGenreServices genreServices) : IMovieGenreServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IGenreServices _genreServices = genreServices ?? throw new ArgumentNullException(nameof(genreServices));
    public async Task<List<MovieGenre>> CreateOrGetMovieGenre(List<string> genreModels, string movieId)
    {
        List<MovieGenre> movieGenres = [];
        foreach (var genreModel in genreModels)
        {
            Genre? genre =await GetMovieGenreAsync( genreName: genreModel);
            if (genre != null)
                movieGenres.Add(new MovieGenre
                {
                    GenreId= genre.Id,
                    MovieId = movieId
                });
        }
        await _unitOfWork.Repository<MovieGenre>().AddRangeAsync(movieGenres);
        await _unitOfWork.CompleteAsync();
        return movieGenres;
    }
    public async Task<Genre?> GetMovieGenreAsync(string genreName) =>await _genreServices.CreateOrGetGenreAsync(genreName: genreName);
    public async Task<IEnumerable<MovieGenre>> GetMovieGenre(string movieId) => await _unitOfWork.Repository<MovieGenre>().GetAllWithPredicateAsync( x=>x.MovieId==movieId,x => x.Genre);
}