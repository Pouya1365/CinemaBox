using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Servers.Servers;

namespace CinemaBox.Domain.Servers.ServerTypes;

public class ServerType : PersistentObject<byte>
{
    public required string ServerTypeName { get; set; }
    public ICollection<Server> Servers { get; set; } = [];
}