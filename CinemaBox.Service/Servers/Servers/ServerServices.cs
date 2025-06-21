using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Servers.Servers;

public class ServerServices(IUnitOfWork unitOfWork): IServerServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<Server?> GetServerAsync(ServerTypeEnumeration serverType)=> await _unitOfWork.Repository<Server>()
            .FindAsync(c => c.ServerTypeId == (int)serverType);
 
}
