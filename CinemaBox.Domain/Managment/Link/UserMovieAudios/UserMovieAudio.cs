using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Languages;

namespace CinemaBox.Domain.Managment.Link.UserMovieAudios;

public class UserMovieAudio
{

    public byte? LanguageId { get; set; }
    public string? MovieId { get; set; }
    public byte? Channels { get; set; }
    public byte? FormatId { get; set; }
    public Language? Language { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }


}