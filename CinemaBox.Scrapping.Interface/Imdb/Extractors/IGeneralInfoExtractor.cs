using CinemaBox.Model.Imdb.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CinemaBox.Scrapping.Interface.Imdb.Extractors
{
    public interface IGeneralInfoExtractor
    {
        MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json);
    }
}
