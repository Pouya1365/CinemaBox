using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Languages;

public class Language : PersistentObject<byte>
{
    public required string EnLanguageName { get; set; }
    public string? FaLanguageName { get; set; }
    public string? IsoCode { get; set; }
    public ICollection<MovieSpokenLanguage> MovieSpokenLanguages { get; set; } = [];
    //public ICollection<UserMovieAudio> UserMovieAudios { get; set; } = [];
}