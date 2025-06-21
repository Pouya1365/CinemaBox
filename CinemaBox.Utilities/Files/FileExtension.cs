using CinemaBox.Utilities.Download;

namespace CinemaBox.Utilities.Files;

public static class FileExtension
{
    public static void CreateOrGetFolder(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
    public static void DeleteFile(string existingFilePath)
    {
        if (File.Exists(existingFilePath))
            File.Delete(existingFilePath);
    }
    public static async void SaveFile(string imageUrl, string id, string name, string serverFolderPath)
    {
        byte[] imageBytes = await ImageExtension.DownloadFile(url: imageUrl);
        string fileName = $"{id}_{name}.jpg";
        string fullPath = Path.Combine(serverFolderPath, fileName);
        await File.WriteAllBytesAsync(fullPath, imageBytes);
    }
}
