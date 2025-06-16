using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Formats;

public class Format : PersistentObject<byte>
{
    public required string FormatName { get; set; }
    public ICollection<UserMovieAudio> UserMovieAudios { get; set; } = [];
    public ICollection<UserMovieVideo> UserMovieVideos { get; set; } = [];
}
