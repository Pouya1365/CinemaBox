using CinemaBox.Domain.Entertainment.Genres;

namespace CinemaBox.Service.Interface.Entertainment.Genres
{
    public interface IGenreServices
    {
        Task<Genre?> CreateOrGetGenreAsync(string? GenreName);
        Task<Genre?> GetGenreAsync(string genreName);
    }
}
