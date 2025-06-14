using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Servers.ServerTypes;

namespace CinemaBox.Domain.Servers.Servers;

public class Server : PersistentObject<byte>
{
    public byte? ServerTypeId { get; set; }
    public required string? ServerName { get; set; }
    public required string? Path { get; set; }
    public ServerType? ServerType { get; set; }
    public ICollection<Files.Files.File> Files { get; set; } = [];
}