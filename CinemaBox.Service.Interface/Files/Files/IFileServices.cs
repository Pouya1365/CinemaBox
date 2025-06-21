using CinemaBox.Enumeration.Servers.ServersType;

namespace CinemaBox.Service.Interface.Files.Files;

public interface IFileServices
{
    Task<Domain.Files.Files.File?> CreateOrGetFileAsync(ServerTypeEnumeration serverTypeEnumeration, string fileName);
    Task RemoveFile(long fileId, string serverFolderPath);

}
