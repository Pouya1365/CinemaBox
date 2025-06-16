using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Domain.Users.Users;

namespace CinemaBox.Domain.Managment.Link.UserMovieAudios;

public class UserMovieAudio : PersistentObject<long>
{

    public byte? LanguageId { get; set; }
    public required string MovieId { get; set; }
    public byte? Channels { get; set; }
    public byte? FormatId { get; set; }
    public string? UserId { get; set; }
    public Language? Language { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
    public User? User { get; set; }

}