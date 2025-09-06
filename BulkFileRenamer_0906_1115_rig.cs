// 代码生成时间: 2025-09-06 11:15:52
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Handlers;

namespace FileRenamerApp
{
    // 文件重命名工具界面
    public class RenamePage : ContentPage
    {
        public RenamePage()
        {
            // 界面元素初始化
            Title = "Bulk File Renamer";
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "Select a directory: " },
                    new Entry { Placeholder = "Enter directory path", Keyboard = Keyboard.Plain },
                    new Button { Text = "Browse", Command = new Command(async () => await BrowseDirectory()) },
                    new Label { Text = "Enter new file name pattern: " },
                    new Entry { Placeholder = "Enter new file name pattern", Keyboard = Keyboard.Plain },
                    new Button { Text = "Rename Files", Command = new Command(async () => await RenameFiles()) }
                }
            };
        }

        // 浏览文件夹选择目录
        private async Task BrowseDirectory()
        {
            // 代码省略，使用文件选择器选择目录
        }

        // 重命名文件
        private async Task RenameFiles()
        {
            try
            {
                // 获取输入的目录路径和新文件名模式
                string directoryPath = ((Entry)(Content.Children[1])).Text;
                string newFileNamePattern = ((Entry)(Content.Children[3])).Text;

                // 检查路径有效性
                if (!Directory.Exists(directoryPath))
                {
                    await DisplayAlert("Error", "Directory does not exist.", "OK");
                    return;
                }

                // 获取目录下所有文件
                var files = Directory.GetFiles(directoryPath);
                for (int i = 0; i < files.Length; i++)
                {
                    // 生成新文件名并重命名
                    string newFileName = $