// 代码生成时间: 2025-08-07 10:54:37
// <copyright file="http_request_handler.cs" company="YourCompany">
//   Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.LifecycleEvents;

namespace YourNamespace
{
    public class HttpRequestHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequestHandler(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        /// <summary>
        /// Sends a GET request to the specified URI.
        /// </summary>
        /// <param name="requestUri">The URI to send the request to.</param>
        /// <returns>A task that contains the response content as a string.</returns>
        public async Task<string> GetAsync(string requestUri)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync(requestUri);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                // Log the error and rethrow to handle it in the calling code.
                throw new HttpRequestException($"An error occurred while sending GET request: {e.Message}", e);
            }
        }

        /// <summary>
        /// Sends a POST request to the specified URI with the provided content.
        /// </summary>
        /// <param name="requestUri">The URI to send the request to.</param>
        /// <param name="content">The content to send in the request.</param>
        /// <returns>A task that contains the response content as a string.</returns>
        public async Task<string> PostAsync(string requestUri, StringContent content)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var response = await httpClient.PostAsync(requestUri, content);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException e)
            {
                // Log the error and rethrow to handle it in the calling code.
                throw new HttpRequestException($"An error occurred while sending POST request: {e.Message}", e);
            }
        }
    }
}
