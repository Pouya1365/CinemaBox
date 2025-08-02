using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Model.Statestics;

namespace CinemaBox.Service.Interface.Entertainment.Genres
{
    public interface IGenreServices
    {
        Task<Genre?> CreateOrGetGenreAsync(string? genreName);
        Task<Genre?> GetGenreAsync(string genreName);
        Task UpdateFaGenre(List<Genre> genres);
        Task<List<Genre>?> GetAllGenreFaNull();
        Task<StatesticsModel?> GetStatestics(StatesticsModel statesticsModel);
        Task<Dictionary<string, int>> GetMovieCountPerGenre();
    }
}
