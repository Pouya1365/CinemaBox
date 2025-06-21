using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;
using CinemaBox.Service.Interface.Files.Files;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Files;

namespace CinemaBox.Service.Person.PeopleFiles;

public class PeopleFileServices(IUnitOfWork unitOfWork, IServerServices serverServices, IFileServices fileServices) : IPeopleFileServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IServerServices _serverServices = serverServices ?? throw new ArgumentNullException(nameof(serverServices));
    private readonly IFileServices _fileServices = fileServices ?? throw new ArgumentNullException(nameof(fileServices));
    public async Task CreateOrUpdatePeopleImage(string path, string imageUrl, string peopleId, string peopleName)
    {
        Server? server = await GetServer();
        string serverFolderPath = Path.Combine(path, server.Path);
        FileExtension.CreateOrGetFolder(path: serverFolderPath);
        await DeleteOldPeopleImage(peopleId: peopleId, serverFolderPath: serverFolderPath);
        FileExtension.SaveFile(imageUrl: imageUrl, id: peopleId, name: peopleName, serverFolderPath: serverFolderPath);
        Domain.Files.Files.File? file = await GetOrCreateFile(serverTypeEnumeration: ServerTypeEnumeration.PeoplePrimaryImage, fileName: $"{peopleId}_{peopleName}.jpg");

        PeopleFile peopleFile = new()
        {
            PeopleId = peopleId,
            FileId = file.Id
        };
        await _unitOfWork.Repository<PeopleFile>().AddAsync(peopleFile);
        await _unitOfWork.CompleteAsync();
    }
    private async Task<Server?> GetServer() => await _serverServices.GetServerAsync(ServerTypeEnumeration.PeoplePrimaryImage);
    private async Task DeleteOldPeopleImage(string peopleId, string serverFolderPath)
    {
        PeopleFile existingPeopleFile = await GetPeopleFile(peopleId: peopleId);
        if (existingPeopleFile == null)
            return;
        if (existingPeopleFile != null)
        {
            RemoveFile(fileId: existingPeopleFile.FileId, serverFolderPath: serverFolderPath);
            _unitOfWork.Repository<PeopleFile>().Remove(existingPeopleFile);
            await _unitOfWork.CompleteAsync();
        }
    }
    private void RemoveFile(long fileId, string serverFolderPath) => _fileServices.RemoveFile(fileId: fileId, serverFolderPath: serverFolderPath);
    private async Task<Domain.Files.Files.File?> GetOrCreateFile(ServerTypeEnumeration serverTypeEnumeration, string fileName) => await _fileServices.CreateOrGetFileAsync(serverTypeEnumeration: serverTypeEnumeration, fileName);
    private async Task<PeopleFile> GetPeopleFile(string peopleId) => await unitOfWork.Repository<PeopleFile>().FindAsync(x => x.PeopleId == peopleId);
}
