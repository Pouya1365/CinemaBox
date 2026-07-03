using CinemaBox.Domain.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Languages;

public class Language : PersistentObject<byte>
{
    public required string LanguageName { get; set; }
    public string? PersianLanguageName { get; set; }
    public string? Iso639_1 { get; set; }
    public string? Iso639_2 { get; set; }
    public ICollection<MovieSpokenLanguage> MovieSpokenLanguages { get; set; } = [];
    public ICollection<UserMovieAudio> UserMovieAudios { get; set; } = [];
}