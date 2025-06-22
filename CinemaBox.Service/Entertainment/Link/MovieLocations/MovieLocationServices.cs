using CinemaBox.Domain.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Link.MovieLocations;

public class MovieLocationServices(IUnitOfWork unitOfWork) : IMovieLocationServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<List<MovieLocation>> CreateMovieLocation(List<string> locationModels, string movieId)
    {
        List<MovieLocation> movieLocations = [];
        foreach (var locationModel in locationModels)
            movieLocations.Add(new MovieLocation
            {
                LocationName = locationModel,
                MovieId = movieId,
            });
        await _unitOfWork.Repository<MovieLocation>().AddRangeAsync(movieLocations);
        await _unitOfWork.CompleteAsync();
        return movieLocations;
    }
    public async Task<IEnumerable<MovieLocation?>> GetMovieLocationsAsync(string movieId) =>await _unitOfWork.Repository<MovieLocation>().GetAllAsync(x => x.MovieId == movieId);

}
