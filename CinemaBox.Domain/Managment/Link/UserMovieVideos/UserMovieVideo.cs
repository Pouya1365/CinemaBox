using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Codecs;
using CinemaBox.Domain.Shared.Formats;
using CinemaBox.Domain.Shared.Qualities.Qualities;
using CinemaBox.Domain.Shared.VideoSources;
using CinemaBox.Domain.UserManager.Users;

namespace CinemaBox.Domain.Managment.Link.UserMovieVideos;

public class UserMovieVideo:PersistentObject<int>
{
    // ===== Foreign Keys =====
    public required int UserId { get; set; }
    public required Guid MovieId { get; set; }
    // ===== Video Technical Properties =====
    public byte? FormatId { get; set; }
    public long? Bitrate { get; set; } // bits per second
    public decimal? FrameRate { get; set; } // 23.976, 24, 25, 29.97, 30, 60
    public string? AspectRatio { get; set; } // "16:9", "21:9", "4:3"
    public string? Resolution { get; set; } // "1920x1080", "3840x2160"
    public int? Width { get; set; }
    public int? Height { get; set; }
    // ===== Quality Properties =====
    public byte? QualityId { get; set; }
    public byte? VideoSourceId { get; set; }
    // ===== Codec & Encoding =====
    public byte? VideoCodec { get; set; }
    public string? CodecProfile { get; set; } // "High@L4.1", "Main10@L5.1"
    public bool IsHEVC { get; set; }
    public int? BitDepth { get; set; } // 8, 10, 12
    // ===== File Information =====
    public string? FileName { get; set; }
    public long FileSize { get; set; } // bytes
    public int? DurationSeconds { get; set; }
    public string? Container { get; set; } // "mkv", "mp4", "avi"
    // ===== Source & Release =====
    public string? ReleaseGroup { get; set; }
    public string? Edition { get; set; } // "Director's Cut", "Extended", "Theatrical"
    // ===== Storage =====
    public string? StoragePath { get; set; }
    // ===== Metadata =====
    public bool HasSubtitles { get; set; }
    public bool HasChapters { get; set; }
    public int? AudioTrackCount { get; set; }
    public int? SubtitleTrackCount { get; set; }
    public string? Description { get; set; }
    // ===== Navigation Properties =====
    public Format? Format { get; set; }
    public Movie? Movie { get; set; }
    public Quality? Quality { get; set; }
    public VideoSource? VideoSource { get; set; }
     public User? User { get; set; }
     public Codec? Codec { get; set; }
}
