using CinemaBox.Domain.Entertainment.Link.MovieFiles;
using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;
using CinemaBox.Service.Interface.Entertainment.Link.MovieFiles;
using CinemaBox.Service.Interface.Files.Files;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Files;

namespace CinemaBox.Service.Entertainment.Link.MovieFiles;

public class MovieFileServices(IUnitOfWork unitOfWork, IServerServices serverServices, IFileServices fileServices) : IMovieFileServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly IServerServices _serverServices = serverServices ?? throw new ArgumentNullException(nameof(serverServices));
    private readonly IFileServices _fileServices = fileServices ?? throw new ArgumentNullException(nameof(fileServices));
    public async Task CreateOrUpdateMovieImage(string path, string imageUrl, string movieId, string movieName)
    {
        Server? server = await GetServer();
        string serverFolderPath = Path.Combine(path, server.Path);
        FileExtension.CreateOrGetFolder(path: serverFolderPath);
        await DeleteOldMovieImage(movieId: movieId, serverFolderPath: serverFolderPath);
      string fileName=await  FileExtension.SaveFile(imageUrl: imageUrl, id: movieId, name: movieName, serverFolderPath: serverFolderPath);
        Domain.Files.Files.File? file = await GetOrCreateFile(serverTypeEnumeration: ServerTypeEnumeration.MoviePrimaryImage, fileName: fileName);

        MovieFile movieFile = new()
        {
            MovieId = movieId,
            FileId = file.Id
        };
        await _unitOfWork.Repository<MovieFile>().AddAsync(movieFile);
        await _unitOfWork.CompleteAsync();
    }
    private async Task<Server?> GetServer() => await _serverServices.GetServerAsync(ServerTypeEnumeration.MoviePrimaryImage);
    private async Task DeleteOldMovieImage(string movieId, string serverFolderPath)
    {
        MovieFile existingMovieFile = await GetMovieFile( movieId: movieId);
        if (existingMovieFile == null)
            return;
        if (existingMovieFile != null)
        {
            RemoveFile(fileId: existingMovieFile.FileId, serverFolderPath: serverFolderPath);
            _unitOfWork.Repository<MovieFile>().Remove(existingMovieFile);
            await _unitOfWork.CompleteAsync();
        }
    }
    private void RemoveFile(long fileId, string serverFolderPath) => _fileServices.RemoveFile(fileId: fileId, serverFolderPath: serverFolderPath);
    private async Task<Domain.Files.Files.File?> GetOrCreateFile(ServerTypeEnumeration serverTypeEnumeration, string fileName) => await _fileServices.CreateOrGetFileAsync(serverTypeEnumeration: serverTypeEnumeration, fileName);
    private async Task<MovieFile> GetMovieFile(string movieId) => await unitOfWork.Repository<MovieFile>().FindAsync(x => x.MovieId == movieId);
}
