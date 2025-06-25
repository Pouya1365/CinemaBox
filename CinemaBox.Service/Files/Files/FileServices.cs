using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;
using CinemaBox.Service.Interface.Files.Files;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Files;

namespace CinemaBox.Service.Files.Files;

public class FileServices(IUnitOfWork unitOfWork, IServerServices serverServices) : IFileServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IServerServices _serverServices = serverServices ?? throw new ArgumentNullException(nameof(serverServices));
    public async Task<Domain.Files.Files.File?> CreateOrGetFileAsync(ServerTypeEnumeration serverTypeEnumeration, string fileName)
    {
        Server? server = await GetServer(serverTypeEnumeration: serverTypeEnumeration);
        Domain.Files.Files.File? file = await _unitOfWork.Repository<Domain.Files.Files.File>().FindAsync(x => x.FileName == fileName && x.ServerId==server.Id);
        if (file == null)
        {
            file = new() { ServerId = server.Id, FileName = fileName, };
            await _unitOfWork.Repository<Domain.Files.Files.File>().AddAsync(file);
            await _unitOfWork.CompleteAsync();
        }
        return file;
    }
    private async Task<Server?> GetServer(ServerTypeEnumeration serverTypeEnumeration) => await _serverServices.GetServerAsync(serverTypeEnumeration);
    public async Task RemoveFile(long fileId, string serverFolderPath)
    {
        Domain.Files.Files.File? existingFile = await GetFile(fileId: fileId);
        if (existingFile != null)
        {
            string existingFilePath = Path.Combine(serverFolderPath, existingFile.FileName);
            if (existingFile != null)
            {
                FileExtension.DeleteFile(existingFilePath);
                _unitOfWork.Repository<Domain.Files.Files.File>().Remove(existingFile);
               // await _unitOfWork.CompleteAsync();
            }
        }
    }
    private async Task<Domain.Files.Files.File> GetFile(long fileId) => await _unitOfWork.Repository<Domain.Files.Files.File>().GetByIdAsync(fileId);


}
