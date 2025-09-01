// 代码生成时间: 2025-09-02 02:28:36
 * for interacting with HTTP services.
 */
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace HttpRequestProcessor
{
    // Define the HttpRequestProcessor class
    public class HttpRequestProcessor
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize the HttpClient instance
        public HttpRequestProcessor()
        {
            _httpClient = new HttpClient();
        }

        // Method to send a GET request to the specified URL
        public async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occur during the request
                Console.WriteLine($"Error sending GET request: {e.Message}");
                return null;
            }
        }

        // Method to send a POST request to the specified URL with JSON content
        public async Task<string> PostAsync(string url, object content)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(content);
                HttpContent httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // Handle any exceptions that occur during the request
                Console.WriteLine($"Error sending POST request: {e.Message}");
                return null;
            }
        }
    }
}
