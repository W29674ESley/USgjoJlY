// 代码生成时间: 2025-08-04 15:35:29
using System;
using System.IO;
using System.Linq;
using SkiaSharp;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.SkiaSharp;
using Microsoft.Maui.Essentials;

namespace ImageResizerMauiApp
{
    public class ImageResizerService
    {
        private readonly SKBitmap _originalBitmap;
        private readonly SKImage _originalImage;
        private readonly SKCodec _codec;

        // Constructor to initialize the image decoder with the image path
        public ImageResizerService(string imagePath)
        {
            _codec = SKCodec.Create(new SKFile(imagePath));
            _originalBitmap = _codec.GetFrameInfo(0).GetPixels();
            _originalImage = SKImage.FromBitmap(_originalBitmap);
        }

        // Method to resize the image to the specified width and height
        public SKBitmap ResizeImage(int newWidth, int newHeight)
        {
            SKBitmap resizedBitmap = new SKBitmap(newWidth, newHeight);

            using (SKCanvas canvas = new SKCanvas(resizedBitmap))
            {
                canvas.Clear(SKColors.Transparent);
                canvas.Scale((float)newWidth / _originalBitmap.Width, (float)newHeight / _originalBitmap.Height);
                canvas.DrawBitmap(_originalBitmap, 0, 0);
            }

            return resizedBitmap;
        }

        // Method to save the resized image to a file
        public bool SaveResizedImage(SKBitmap resizedBitmap, string savePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(savePath, FileMode.Create))
                {
                    SKPixmap pixmap = resizedBitmap.ExtractPixmap((SKColorType)0, SKAlphaType.Premul);
                    pixmap.Encode(SKEncodedImageFormat.Png, 100).SaveTo(fileStream);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
                return false;
            }
        }
    }

    // The Entry Point of the MAUI application
    public class App : Application
    {
        public App()
        {
            MainPage = new ContentPage
            {
                // Add UI elements and layout configurations here
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Welcome to the Image Resizer MAUI App"
                        }
                    }
                }
            };
        }
    }
}
