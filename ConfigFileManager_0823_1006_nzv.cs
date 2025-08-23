// 代码生成时间: 2025-08-23 10:06:34
 * It follows C# best practices for maintainability and extensibility.
 */
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConfigManager
{
    // Define a simple configuration class to deserialize the config file.
    public class AppConfig
    {
        [JsonPropertyName("setting1")]
        public string Setting1 { get; set; }

        [JsonPropertyName("setting2")]
        public int Setting2 { get; set; }
    }

    public class ConfigFileManager
    {
        private readonly string _configFilePath;

        public ConfigFileManager(string configFilePath)
        {
            _configFilePath = configFilePath;
        }

        // Reads the configuration file and returns the deserialized AppConfig object.
        public AppConfig LoadConfig()
        {
            try
            {
                if (!File.Exists(_configFilePath))
                {
                    throw new FileNotFoundException("Configuration file not found.");
                }

                string configJson = File.ReadAllText(_configFilePath);
                return JsonSerializer.Deserialize<AppConfig>(configJson);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow.
                Console.WriteLine($"Error loading configuration: {ex.Message}");
                throw;
            }
        }

        // Writes the AppConfig object to the configuration file.
        public void SaveConfig(AppConfig config)
        {
            try
            {
                string configJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_configFilePath, configJson);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow.
                Console.WriteLine($"Error saving configuration: {ex.Message}");
                throw;
            }
        }
    }
}
