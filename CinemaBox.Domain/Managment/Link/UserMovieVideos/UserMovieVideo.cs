using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Qualities.Qualities;
using CinemaBox.Domain.Shared.Qualities.QualityTypes;

namespace CinemaBox.Domain.Managment.Link.UserMovieVideos;

public class UserMovieVideo:PersistentObject<string>
{
    public byte? FormatId { get; set; }
    public string? BitRate { get; set; }
    public string? FPS { get; set; }
    public string? AspectRatio { get; set; }
    public string? Resolution { get; set; }
    public byte? QualityId { get; set; }
    public byte? QualityTypeId { get; set; }
    public bool? X265 { get; set; }
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
    public Quality? Quality { get; set; }
    public QualityType? QualityType { get; set; }
}
