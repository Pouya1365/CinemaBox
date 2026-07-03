using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Qualities.Qualities
{
    public class Quality:PersistentObject<byte>
    {
        public required string Name { get; set; }
        public required string PersianName { get; set; }
        public ICollection<UserMovieVideo> UserMovieVideos = [];
    }
}
