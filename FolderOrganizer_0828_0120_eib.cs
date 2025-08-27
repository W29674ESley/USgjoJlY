// 代码生成时间: 2025-08-28 01:20:44
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace FolderOrganizerApp
{
    public class FolderOrganizer
    {
        // 定义根目录路径
        private readonly string rootDirectory;

        // 构造函数
        public FolderOrganizer(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new ArgumentException("The specified directory does not exist.");
            }

            this.rootDirectory = directoryPath;
        }

        // 整理文件夹结构
        public async Task OrganizeFoldersAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    // 遍历根目录
                    var directories = Directory.GetDirectories(rootDirectory);
                    foreach (var directory in directories)
                    {
                        OrganizeSubfolders(directory);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // 递归整理子文件夹
        private void OrganizeSubfolders(string directoryPath)
        {
            try
            {
                // 遍历子文件夹
                var subdirectories = Directory.GetDirectories(directoryPath);
                foreach (var subdirectory in subdirectories)
                {
                    OrganizeSubfolders(subdirectory);
                }

                // 整理文件
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    // 这里可以添加文件排序或分类逻辑
                    // 例如：根据文件扩展名分类文件
                    var fileInfo = new FileInfo(file);
                    var extension = fileInfo.Extension;
                    var targetDirectory = Path.Combine(directoryPath, extension.TrimStart('.'));
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }
                    File.Move(file, Path.Combine(targetDirectory, fileInfo.Name));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error organizing subfolder {directoryPath}: {ex.Message}");
            }
        }
    }

    // 应用程序的主类
    public class App : Application
    {
        public App()
        {
            var window = new ContentPage
            {
                Title = "Folder Organizer",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Please enter the root directory path:",
                            FontSize = FontSize.Medium,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new Entry
                        {
                            Placeholder = "Root Directory Path",
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        },
                        new Button
                        {
                            Text = "Start Organizing",
                            Command = new Command(async () => await OrganizeFolders())
                        }
                    }
                }
            };

            MainPage = window;
        }

        // 开始整理文件夹
        private async Task OrganizeFolders()
        {
            var rootDirectoryEntry = (Entry)(MainPage.Content as StackLayout).Children[1];
            var rootDirectory = rootDirectoryEntry.Text;
            if (string.IsNullOrWhiteSpace(rootDirectory))
            {
                await DisplayAlert("Error", "Please enter the root directory path.", "OK");
                return;
            }

            var organizer = new FolderOrganizer(rootDirectory);
            await organizer.OrganizeFoldersAsync();
            await DisplayAlert("Success", "Folder organization completed.", "OK");
        }
    }
}
