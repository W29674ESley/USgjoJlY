// 代码生成时间: 2025-09-01 13:27:50
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp
{
    /// <summary>
    /// CachingStrategy provides a simple cache mechanism for storing and retrieving data.
    /// </summary>
    public class CachingStrategy
    {
        private const string CacheFileName = "cache.json";
        private readonly string cacheFilePath;

        /// <summary>
        /// Initializes a new instance of CachingStrategy.
        /// </summary>
        /// <param name="cacheFolderPath">The folder path where the cache file will be stored.</param>
        public CachingStrategy(string cacheFolderPath)
        {
            // Ensure the cacheFolderPath ends with a directory separator
            if (!cacheFolderPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                cacheFolderPath += Path.DirectorySeparatorChar;

            cacheFilePath = Path.Combine(cacheFolderPath, CacheFileName);
        }

        /// <summary>
        /// Saves data to the cache file.
        /// </summary>
        /// <typeparam name="T">The data type to save.</typeparam>
        /// <param name="key">The unique identifier for the data.</param>
        /// <param name="data">The data to be cached.</param>
        public async Task SaveDataAsync<T>(string key, T data)
        {
            try
            {
                var dataJson = JsonSerializer.Serialize(data);
                var cacheData = await LoadCacheDataAsync();

                if (cacheData == null)
                    cacheData = new Dictionary<string, string>();

                cacheData[key] = dataJson;

                await File.WriteAllTextAsync(cacheFilePath, JsonSerializer.Serialize(cacheData));
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log the error
                Console.WriteLine($"Error saving data to cache: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves data from the cache file.
        /// </summary>
        /// <typeparam name="T">The data type to retrieve.</typeparam>
        /// <param name="key">The unique identifier for the data.</param>
        /// <returns>The cached data or null if not found.</returns>
        public async Task<T?> RetrieveDataAsync<T>(string key)
        {
            try
            {
                var cacheData = await LoadCacheDataAsync();

                if (cacheData != null && cacheData.TryGetValue(key, out var dataJson))
                {
                    return JsonSerializer.Deserialize<T>(dataJson);
                }
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log the error
                Console.WriteLine($"Error retrieving data from cache: {ex.Message}");
            }

            return default;
        }

        /// <summary>
        /// Loads the cache data from the cache file.
        /// </summary>
        /// <returns>The dictionary of cached data or null if the file does not exist.</returns>
        private async Task<Dictionary<string, string>?> LoadCacheDataAsync()
        {
            if (!File.Exists(cacheFilePath))
                return null;

            var cacheDataJson = await File.ReadAllTextAsync(cacheFilePath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(cacheDataJson);
        }

        /// <summary>
        /// Clears the cache file by deleting it.
        /// </summary>
        public async Task ClearCacheAsync()
        {
            try
            {
                if (File.Exists(cacheFilePath))
                    await File.DeleteAsync(cacheFilePath);
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log the error
                Console.WriteLine($"Error clearing cache: {ex.Message}");
            }
        }
    }
}
