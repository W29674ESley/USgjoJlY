// 代码生成时间: 2025-10-02 03:34:24
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DiskSpaceManagementTool
{
    // 主页类
    public class MainPage : ContentPage
    {
        private ListView listView;
        private Button refreshButton;
        private Button cleanButton;

        public MainPage()
        {
            // 初始化页面布局
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // 创建ListView用于显示磁盘空间信息
            listView = new ListView
            {
                RowHeight = 60,
                BackgroundColor = Colors.White
            };

            // 创建刷新按钮
            refreshButton = new Button
            {
                Text = "Refresh",
                HorizontalOptions = LayoutOptions.Center
            };
            refreshButton.Clicked += RefreshDiskInfo;

            // 创建清理按钮
            cleanButton = new Button
            {
                Text = "Clean",
                HorizontalOptions = LayoutOptions.Center
            };
            cleanButton.Clicked += CleanDisk;

            // 设置页面内容
            Content = new StackLayout
            {
                Children =
                {
                    listView,
                    refreshButton,
                    cleanButton
                }
            };
        }

        private async void RefreshDiskInfo(object sender, EventArgs e)
        {
            try
            {
                // 获取磁盘空间信息
                var drives = DriveInfo.GetDrives();
                var driveList = drives.Select(d => new {
                    Name = d.Name,
                    AvailableFreeSpace = d.AvailableFreeSpace,
                    TotalSize = d.TotalSize
                });
                // 更新ListView数据
                listView.ItemsSource = driveList;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void CleanDisk(object sender, EventArgs e)
        {
            try
            {
                // 模拟清理磁盘操作
                await Task.Delay(1000); // 模拟异步操作
                await DisplayAlert("Clean", "Disk cleaned successfully!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
