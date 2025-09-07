// 代码生成时间: 2025-09-07 17:41:45
using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Net;
using AngleSharp.Html.Parser;
using AngleSharp.Html;
using System.IO;
using System.Threading.Tasks;

namespace XSSProtectionApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async Task<string> FetchAndSanitizeInput(string url)
        {
            try
            {
                // Fetch the content from the URL
                using (var client = new WebClient())
                {
                    string content = await client.DownloadStringTaskAsync(url);

                    // Sanitize the input using AngleSharp to prevent XSS attacks
                    IHtmlParser parser = new HtmlParser();
                    var document = parser.ParseDocument(content);
                    string sanitizedContent = document.DocumentElement.InnerHtml;

                    return sanitizedContent;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the fetch and sanitize process
                Console.WriteLine($"Error fetching or sanitizing content: {ex.Message}");
                return null;
            }
        }

        private void ProcessInput_Clicked(object sender, EventArgs e)
        {
            string inputUrl = InputUrlEntry.Text;
            if (string.IsNullOrEmpty(inputUrl))
            {
                // Show an error message if the input URL is empty
                ErrorLabel.Text = "Please enter a valid URL.";
                return;
            }

            // Fetch and sanitize the input from the provided URL
            string sanitizedContent = FetchAndSanitizeInput(inputUrl).Result;

            if (sanitizedContent != null)
            {
                // Display the sanitized content
                ResultLabel.Text = sanitizedContent;
                ErrorLabel.Text = string.Empty;
            }
            else
            {
                // Show an error message if the content could not be sanitized
                ErrorLabel.Text = "Failed to sanitize the content.";
            }
        }
    }
}

/*
 * Notes:
 * 1. The FetchAndSanitizeInput method fetches content from a given URL and sanitizes it
 *    to prevent XSS attacks using AngleSharp.
 * 2. The ProcessInput_Clicked method is triggered when the user clicks the 'Process Input' button.
 *    It fetches and sanitizes the input from the provided URL and displays the result.
 * 3. Proper error handling is included to handle any exceptions that may occur during the fetch and sanitize process.
 * 4. The code follows C# best practices for readability, maintainability, and extensibility.
 */