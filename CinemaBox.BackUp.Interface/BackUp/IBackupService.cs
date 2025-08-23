namespace CinemaBox.BackUp.Interface.BackUp;

public interface IBackupService
{
    Task BackupAsync(string backupFolder, string programFolder);
}
