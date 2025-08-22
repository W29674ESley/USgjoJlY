// 代码生成时间: 2025-08-22 19:52:46
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace BatchFileRenamerApp
{
    // 界面类
    public class BatchFileRenamerPage : ContentPage
    {
        public BatchFileRenamerPage()
        {
            // 设置页面标题
            Title = "Batch File Renamer";

            // 添加用户界面元素
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Source Directory: " },
                    new Entry { x:Name = "SourceDirectoryEntry" },
                    new Label { Text = "Destination Directory: " },
                    new Entry { x:Name = "DestinationDirectoryEntry" },
                    new Button { Text = "Rename Files", Command = new Command(RenameFiles) }
                }
            };
        }

        // 重命名文件的方法
        private async void RenameFiles()
        {
            string sourceDirectory = (<Entry>((StackLayout)Content).Children[1]).Text;
            string destinationDirectory = (<Entry>((StackLayout)Content).Children[3]).Text;

            // 检查目录路径是否有效
            if (!Directory.Exists(sourceDirectory) || !Directory.Exists(destinationDirectory))
            {
                await DisplayAlert("Error", "Source or destination directory does not exist.", "OK");
                return;
            }

            try
            {
                // 获取源目录中的所有文件
                var files = Directory.GetFiles(sourceDirectory).Select(Path.GetFileName).ToList();

                // 重命名文件并移动到目标目录
                for (int i = 0; i < files.Count; i++)
                {
                    string oldPath = Path.Combine(sourceDirectory, files[i]);
                    string newPath = Path.Combine(destinationDirectory, $"RenamedFile{i + 1}{Path.GetExtension(oldPath)}");

                    // 重命名并移动文件
                    File.Move(oldPath, newPath);
                }

                // 显示操作完成的消息
                await DisplayAlert("Success", "Files have been renamed and moved successfully.", "OK");
            }
            catch (Exception ex)
            {
                // 错误处理
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
