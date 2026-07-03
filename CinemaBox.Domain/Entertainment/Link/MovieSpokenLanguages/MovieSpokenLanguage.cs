using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Shared.Languages;

namespace CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;

public class MovieSpokenLanguage
{
    public required int MovieId { get; set; }
    public required byte LanguageId { get; set; }
    public Language? Language { get; set; }
    public Movie? Movie { get; set; }
}