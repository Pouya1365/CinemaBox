using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;

namespace CinemaBox.Service.Interface.Servers.Servers;

public interface IServerServices
{
    Task<Server?> GetServerAsync(ServerTypeEnumeration serverType);
}
