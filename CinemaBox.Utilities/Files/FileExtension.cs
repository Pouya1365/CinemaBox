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
    public static string ReadConnectionString(string filePath)
    {
        try
        {
            // مسیر کامل فایل حاوی رشته اتصال را مشخص کنید
            string connectionString = File.ReadAllText(filePath);
            return connectionString.Trim(); // حذف فضاهای خالی احتمالی در ابتدا و انتهای رشته
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: The file '{filePath}' was not found.");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
    public static List<string> GetAllFolders(string path)
    {
        List<string> folders = [];

        try
        {
            // اضافه کردن فولدرهای سطح جاری
            folders.AddRange(Directory.GetDirectories(path).Where(x => !x.Contains(".BIN")));
            // بررسی بازگشتی زیرفولدرها
         

        }
        catch (UnauthorizedAccessException)
        {
            // دسترسی به برخی فولدرها ممکن نیست
            Console.WriteLine($"دسترسی به {path} امکان‌پذیر نیست");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"خطا در {path}: {ex.Message}");
        }

        return folders;
    }
}
