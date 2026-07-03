using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Languages;
using CinemaBox.Domain.UserManager.Users;
namespace CinemaBox.Domain.Managment.Link.UserMovieAudios;
public class UserMovieAudio:PersistentObject<int>
{
    public byte? UserId { get; set; }
    public byte? LanguageId { get; set; }
    public int? MovieId { get; set; }
    public byte? Channels { get; set; }
    public byte? FormatId { get; set; }
    public int? Bitrate { get; set; }
    public int? SampleRate { get; set; }
    public Language? Language { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
    public User? User { get; set; }
}