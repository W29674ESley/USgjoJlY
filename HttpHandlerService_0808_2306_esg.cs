// 代码生成时间: 2025-08-08 23:06:01
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MyApp.HttpHandlers
{
    /// <summary>
    /// Http请求处理器
    /// </summary>
    public class HttpHandlerService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        public HttpHandlerService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="url">请求的URL</param>
        /// <returns>返回的数据</returns>
        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException e)
            {
                // 处理请求异常
                Console.WriteLine($"请求异常: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                // 处理JSON解析异常
                Console.WriteLine($"JSON解析异常: {e.Message}");
                throw;
            }
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <typeparam name="T">返回的数据类型</typeparam>
        /// <param name="url">请求的URL</param>
        /// <param name="content">请求的内容</param>
        /// <returns>返回的数据</returns>
        public async Task<T> PostAsync<T>(string url, HttpContent content)
        {
            try
            {
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var contentString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException e)
            {
                // 处理请求异常
                Console.WriteLine($"请求异常: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                // 处理JSON解析异常
                Console.WriteLine($"JSON解析异常: {e.Message}");
                throw;
            }
        }
    }
}