using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Imdb.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBox.Service.Interface.Entertainment.Movies
{
    public interface IMovieServices
    {
        Task<Movie> CreateOrUpdate(MovieModelScrapping model);
        Task<Movie?> GeMovieAsync(string? ImdbId);
    }
}
