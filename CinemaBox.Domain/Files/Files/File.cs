using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Servers.Servers;
namespace CinemaBox.Domain.Files.Files;

public class File : PersistentObject<long>
{
    public required byte ServerId { get; set; }
    public string? FileName { get; set; }
    public long FileSize { get; set; }
    public required string MimeType { get; set; }
    public string? FileExtension { get; set; }
    public string? OriginalFileName { get; set; }
    // ===== Media Specific (optional) =====
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? DurationSeconds { get; set; }
    public Server? Server { get; set; }
}