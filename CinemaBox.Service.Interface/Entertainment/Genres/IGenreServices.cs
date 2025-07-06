using CinemaBox.Domain.Entertainment.Genres;

namespace CinemaBox.Service.Interface.Entertainment.Genres
{
    public interface IGenreServices
    {
        Task<Genre?> CreateOrGetGenreAsync(string? genreName);
        Task<Genre?> GetGenreAsync(string genreName);
        Task UpdateFaGenre(List<Genre> genres);
        Task<List<Genre>?> GetAllGenreFaNull();
    }
}
