// 代码生成时间: 2025-09-04 19:02:15
using System;
using System.IO;
using SkiaSharp;
#if WINDOWS || MACCATALYST || MACOS
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
#endif

namespace ImageResizerApp
{
    public class ImageResizer
    {
        private readonly string sourceFolderPath;
        private readonly string destinationFolderPath;
        private readonly int targetWidth;
        private readonly int targetHeight;

        /// <summary>
        /// 初始化图片尺寸批量调整器
        /// </summary>
        /// <param name="sourceFolderPath">源文件夹路径</param>
        /// <param name="destinationFolderPath">目标文件夹路径</param>
        /// <param name="targetWidth">目标宽度</param>
        /// <param name="targetHeight">目标高度</param>
        public ImageResizer(string sourceFolderPath, string destinationFolderPath, int targetWidth, int targetHeight)
        {
            this.sourceFolderPath = sourceFolderPath;
            this.destinationFolderPath = destinationFolderPath;
            this.targetWidth = targetWidth;
            this.targetHeight = targetHeight;
        }

        /// <summary>
        /// 调整文件夹内所有图片的尺寸
        /// </summary>
        public void ResizeImages()
        {
            var files = Directory.GetFiles(sourceFolderPath);
            foreach (var file in files)
            {
                try
                {
                    ResizeImage(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error resizing image {file}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// 调整单个图片的尺寸
        /// </summary>
        /// <param name="filePath">图片文件路径</param>
        private void ResizeImage(string filePath)
        {
            using (var inputStream = File.OpenRead(filePath))
            {
                using (var bitmap = SKBitmap.Decode(inputStream))
                {
                    var resizedBitmap = ResizeBitmap(bitmap);
                    var outputPath = Path.Combine(destinationFolderPath, Path.GetFileName(filePath));
                    using (var outputStream = File.OpenWrite(outputPath))
                    {
                        resizedBitmap.Encode(SKEncodedImageFormat.Jpeg, 90).SaveTo(outputStream);
                    }
                }
            }
        }

        /// <summary>
        /// 调整Bitmap到指定尺寸
        /// </summary>
        /// <param name="originalBitmap">原始Bitmap</param>
        /// <returns>调整尺寸后的Bitmap</returns>
        private SKBitmap ResizeBitmap(SKBitmap originalBitmap)
        {
            var resizedBitmap = new SKBitmap(targetWidth, targetHeight);
            using (var canvas = new SKCanvas(resizedBitmap))
            {
                canvas.Clear(SKColors.Transparent);
                canvas.DrawBitmap(originalBitmap,
                    new SKRect(0, 0, targetWidth, targetHeight),
                    SKPaintFilterQuality.High);
            }
            return resizedBitmap;
        }
    }
}
