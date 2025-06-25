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
    public static async Task<string> SaveFile(string imageUrl, string id, string name, string serverFolderPath)
    {
        byte[] imageBytes = await ImageExtension.DownloadFile(url: imageUrl);
        string fileName = $"{id}_{name}.jpg";
        fileName = SanitizeFileName(fileName);
        string fullPath = Path.Combine(serverFolderPath, fileName);
        await File.WriteAllBytesAsync(fullPath, imageBytes);
        return fileName;
    }
    public static async Task<string> SaveFile(byte[] imageUrl, string id, string name, string serverFolderPath)
    {
        string fileName = $"{id}_{name}.jpg";
        fileName = SanitizeFileName(fileName);
        string fullPath = Path.Combine(serverFolderPath, fileName);
        await File.WriteAllBytesAsync(fullPath, imageUrl);

        return fileName;
    }
    public static string SanitizeFileName(string fileName)
    {
        // تعریف کاراکترهای غیرمجاز
        char[] invalidChars = Path.GetInvalidFileNameChars();
        // جایگزینی کاراکتر ":" به طور خاص
        fileName = fileName.Replace(':', '-');
        // حذف یا جایگزینی سایر کاراکترهای غیرمجاز
        foreach (char c in invalidChars)
            fileName = fileName.Replace(c, '_'); // یا می‌توانید حذف کنید: ""     
        return fileName;
    }
}
