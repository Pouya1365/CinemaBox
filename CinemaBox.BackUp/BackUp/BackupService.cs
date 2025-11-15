

using CinemaBox.BackUp.Interface.BackUp;
using CinemaBox.Context.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.IO.Compression;

namespace CinemaBox.BackUp.BackUp;

public class BackupService : IBackupService
{
    private readonly CinemaBoxDbContext _db;

    public BackupService(CinemaBoxDbContext db) => _db = db;

    public async Task BackupAsync(string backupFolder, string programFolder)
    {
        if (!Directory.Exists(backupFolder))
            Directory.CreateDirectory(backupFolder);

        await BackupDatabaseAsync(backupFolder);
        BackupProgramFolder(programFolder, backupFolder);
    }

    private async Task BackupDatabaseAsync(string backupFolder)
    {
        DbConnection connection = _db.Database.GetDbConnection();
        string databaseName = connection.Database;
        string backupFile = Path.Combine(backupFolder, $"{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak"); 
        string query = $@"BACKUP DATABASE [{databaseName}] 
                              TO DISK = '{backupFile}' 
                              WITH NOFORMAT, NOINIT,SKIP, NOREWIND, NOUNLOAD, COMPRESSION, STATS = 10";

        await _db.Database.ExecuteSqlRawAsync(query);
    }

    private void BackupProgramFolder(string programFolder, string backupFolder)
    {
        string zipFile = Path.Combine(backupFolder, $"ProgramFiles_{DateTime.Now:yyyyMMdd_HHmmss}.zip");
        ZipFile.CreateFromDirectory(programFolder, zipFile, CompressionLevel.Optimal, true);
    }
}
