// 代码生成时间: 2025-08-21 04:39:46
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBackupRestoreService
{
    // Exception class for data backup and restore operations.
    public class DataOperationException : Exception
    {
        public DataOperationException(string message) : base(message)
        {
        }
    }

    // Service class for data backup and restore.
    public class DataBackupRestoreService
    {
        private readonly string _backupFolderPath;

        public DataBackupRestoreService(string backupFolderPath)
        {
            _backupFolderPath = backupFolderPath ?? throw new ArgumentNullException(nameof(backupFolderPath));
        }

        // Asynchronously backs up data to the specified backup folder.
        public async Task BackupDataAsync<T>(T data)
        {
            try
            {
                // Convert the data to JSON and save it to the backup folder.
                var jsonData = JsonSerializer.Serialize(data);
                var backupFilePath = Path.Combine(_backupFolderPath, $"backup_{DateTime.Now:yyyyMMddHHmmss}.json");
                await File.WriteAllTextAsync(backupFilePath, jsonData);
            }
            catch (Exception ex)
            {
                throw new DataOperationException("An error occurred during data backup.") { InnerException = ex };
            }
        }

        // Asynchronously restores data from the latest backup file.
        public async Task<T> RestoreDataAsync<T>()
        {
            try
            {
                // Find the latest backup file.
                var backupFiles = Directory.GetFiles(_backupFolderPath, "*.json").OrderByDescending(f => f).ToList();
                if (!backupFiles.Any())
                {
                    throw new DataOperationException("No backup files found.");
                }

                // Read the JSON from the latest backup file and deserialize it.
                var latestBackupFilePath = backupFiles.First();
                var jsonData = await File.ReadAllTextAsync(latestBackupFilePath);
                return JsonSerializer.Deserialize<T>(jsonData) ?? throw new DataOperationException("Failed to deserialize backup data.");
            }
            catch (Exception ex)
            {
                throw new DataOperationException("An error occurred during data restore.") { InnerException = ex };
            }
        }
    }
}
