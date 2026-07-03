using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.VideoSources;

public class VideoSource : PersistentObject<byte>
{
    public required string VideoSourceName { get; set; }
    public  string PersianName { get; set; }

    public ICollection<UserMovieVideo> UserMovieVideos = [];
}
