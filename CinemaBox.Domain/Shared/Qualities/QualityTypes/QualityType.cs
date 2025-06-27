using CinemaBox.Domain.Managment.Link.UserMovieVideos;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Shared.Qualities.QualityTypes;

public class QualityType : PersistentObject<byte>
{
    public required string QualityTypeName { get; set; }
    public ICollection<UserMovieVideo> UserMovieVideos = [];
}
