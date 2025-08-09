// 代码生成时间: 2025-08-09 10:54:29
// <copyright file="UnzipperApp.cs" company="Your Company">
//   Copyright (c) Your Company. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UnzipperApp
{
    public partial class UnzipperApp : ContentPage
    {
        private const string ZipFileLocation = "path_to_your_zip_file.zip"; // Specify the path to the zip file
        private const string ExtractionPath = "path_to_extraction_directory"; // Specify the path to extract files

        public UnzipperApp()
        {
            InitializeComponent();
        }

        private async Task UnzipFileAsync()
        {
            try
            {
                if (!File.Exists(ZipFileLocation))
                {
                    // Handle the error if the zip file does not exist
                    throw new FileNotFoundException("The specified zip file was not found.");
                }

                // Ensure the extraction directory exists
                Directory.CreateDirectory(ExtractionPath);

                // Unzip the file asynchronously
                await Task.Run(() => ZipFile.ExtractToDirectory(ZipFileLocation, ExtractionPath));

                // Notify the user that the operation was successful
                await DisplayAlert("Unzipping Complete", "The file has been successfully unzipped.", "OK");
            }
            catch (FileNotFoundException ex)
            {
                // Handle file not found exception
                await DisplayAlert("Error", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void OnUnzipButtonTapped(object sender, EventArgs e)
        {
            // Start the unzipping process when the button is tapped
            UnzipFileAsync();
        }
    }
}
