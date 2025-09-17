// 代码生成时间: 2025-09-17 14:57:56
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CompressionTool
{
    public class DecompressionTool
    {
        // Method to decompress a file
        public async Task DecompressFileAsync(string sourceFilePath, string destinationFolderPath)
        {
            // Check if the source file exists
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("Source file not found.");
            }

            // Check if the destination folder exists, if not, create it
            Directory.CreateDirectory(destinationFolderPath);

            try
            {
                // Decompress the file
                if (sourceFilePath.EndsWith(".zip"))
                {
                    await UnzipFileAsync(sourceFilePath, destinationFolderPath);
                }
                // Add more decompression methods for other file types as needed
                else
                {
                    throw new NotSupportedException("Decompression method not supported for this file type.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during decompression
                Console.WriteLine("An error occurred during decompression: " + ex.Message);
                throw;
            }
        }

        // Method to unzip a file
        private async Task UnzipFileAsync(string zipFilePath, string destinationFolderPath)
        {
            using (var archive = ZipFile.OpenRead(zipFilePath))
            {
                foreach (var file in archive.Entries)
                {
                    string completeFilePath = Path.Combine(destinationFolderPath, file.FullName);

                    // Create directory
                    if (file.FullName.Contains("/"))
                    {
                        string directoryPath = Path.GetDirectoryName(completeFilePath);
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Write the contents of the file to disk
                    using (var streamReader = file.Open())
                    {
                        using (var streamWriter = File.Create(completeFilePath))
                        {
                            await streamReader.CopyToAsync(streamWriter);
                        }
                    }
                }
            }
        }
    }
}
