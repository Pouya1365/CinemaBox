using CinemaBox.Domain.Managment.Link.UserMovieFiles;
using CinemaBox.Domain.Servers.Servers;
using CinemaBox.Enumeration.Servers.ServersType;
using CinemaBox.Service.Interface.Files.Files;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.UnitOfWork.Interface.UOW;
using CinemaBox.Utilities.Files;


namespace CinemaBox.Service.Managment.Link.UserMovieFiles
{
    public class UserMovieFileServices(IUnitOfWork unitOfWork, IServerServices serverServices, IFileServices fileServices) : IUserMovieFileServices
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        private readonly IServerServices _serverServices = serverServices ?? throw new ArgumentNullException(nameof(serverServices));
        private readonly IFileServices _fileServices = fileServices ?? throw new ArgumentNullException(nameof(fileServices));
        public async Task CreateOrUpdateUserMovieImage(string path, byte[] imageUrl, string movieId, string movieName)
        {
            Server? server = await GetServer();
            string serverFolderPath = Path.Combine(path, server.Path);
            FileExtension.CreateOrGetFolder(path: serverFolderPath);
            await DeleteOldUserMovieImage(movieId: movieId, serverFolderPath: serverFolderPath);
            string fileName = await FileExtension.SaveFile(imageUrl: imageUrl, id: movieId, name: movieName, serverFolderPath: serverFolderPath);
            Domain.Files.Files.File? file = await GetOrCreateUserFile(serverTypeEnumeration: ServerTypeEnumeration.UserMoviePrimaryImage, fileName: fileName);

            UserMovieFile movieFile = new()
            {
                MovieId = movieId,
                FileId = file.Id
            };
            await _unitOfWork.Repository<UserMovieFile>().AddAsync(movieFile);
            await _unitOfWork.CompleteAsync();
        }
        private async Task<Server?> GetServer() => await _serverServices.GetServerAsync(ServerTypeEnumeration.UserMoviePrimaryImage);
        private async Task DeleteOldUserMovieImage(string movieId, string serverFolderPath)
        {
            UserMovieFile existingMovieFile = await GetUserMovieFile(movieId: movieId);
            if (existingMovieFile == null)
                return;
            if (existingMovieFile != null)
            {
                RemoveFile(fileId: existingMovieFile.FileId, serverFolderPath: serverFolderPath);
                _unitOfWork.Repository<UserMovieFile>().Remove(existingMovieFile);
                await _unitOfWork.CompleteAsync();
            }
        }
        private void RemoveFile(long fileId, string serverFolderPath) => _fileServices.RemoveFile(fileId: fileId, serverFolderPath: serverFolderPath);
        private async Task<Domain.Files.Files.File?> GetOrCreateUserFile(ServerTypeEnumeration serverTypeEnumeration, string fileName) => await _fileServices.CreateOrGetFileAsync(serverTypeEnumeration: serverTypeEnumeration, fileName);
        public async Task<UserMovieFile> GetUserMovieFile(string movieId) => await unitOfWork.Repository<UserMovieFile>().FindAsync(x => x.MovieId == movieId);
   
    }

}

