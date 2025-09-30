// 代码生成时间: 2025-10-01 03:26:29
// WealthManagementApp.cs
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Linq;

// WealthManagementApp 是一个财富管理工具应用的主类
public class WealthManagementApp : Application
{
    private readonly INavigation navigation;
    private readonly List<Asset> assets = new List<Asset>();

    // 构造函数初始化MAUI导航和资产列表
    public WealthManagementApp()
    {
        // 设置窗口主题
        MainPage = new NavigationPage(new MainPage(this))
        {
            BarBackgroundColor = Colors.Blue,
            BarTextColor = Colors.White
        };

        navigation = (MainPage as NavigationPage).Navigation;
    }

    // 添加资产到资产列表
    public void AddAsset(Asset asset)
    {
        if (asset == null)
        {
            throw new ArgumentNullException(nameof(asset), "Asset cannot be null");
        }

        assets.Add(asset);
    }

    // 计算总资产价值
    public decimal CalculateTotalAssetsValue()
    {
        return assets.Sum(asset => asset.Value);
    }

    // 定义资产类
    public class Asset
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }

        public Asset(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}

// MainPage.xaml.cs 是MAUI页面的代码后置文件
// MainPage.xaml 是MAUI页面的XAML文件，负责布局和UI组件定义
public class MainPage : ContentPage
{
    private readonly WealthManagementApp app;
    private Entry assetNameEntry;
    private Entry assetValueEntry;
    private Label totalAssetsValueLabel;

    // 构造函数接收应用程序实例
    public MainPage(WealthManagementApp app)
    {
        this.app = app;
        
        // 初始化页面布局
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // 创建页面布局和UI组件
        var layout = new StackLayout
        {
            Padding = new Thickness(20),
            Spacing = 10
        };

        assetNameEntry = new Entry { Placeholder = "Enter asset name" };
        assetValueEntry = new Entry { Placeholder = "Enter asset value", Keyboard = Keyboard.Numeric };
        var addButton = new Button { Text = "Add Asset" };
        totalAssetsValueLabel = new Label { Text = "Total Assets Value: $0" };

        // 添加组件到布局
        layout.Children.Add(new Label { Text = "Wealth Management Tool", FontSize = FontSize.Large });
        layout.Children.Add(assetNameEntry);
        layout.Children.Add(assetValueEntry);
        layout.Children.Add(addButton);
        layout.Children.Add(totalAssetsValueLabel);

        // 设置页面内容
        Content = layout;

        // 添加按钮事件处理
        addButton.Clicked += AddAsset;
    }

    // 添加资产事件处理
    private async void AddAsset(object sender, EventArgs e)
    {
        string assetName = assetNameEntry.Text;
        decimal assetValue;

        if (string.IsNullOrWhiteSpace(assetName))
        {
            await DisplayAlert("Error", "Asset name cannot be empty", "OK");
            return;
        }

        if (!decimal.TryParse(assetValueEntry.Text, out assetValue))
        {
            await DisplayAlert("Error", "Invalid asset value", "OK");
            return;
        }

        var newAsset = new WealthManagementApp.Asset(assetName, assetValue);
        app.AddAsset(newAsset);

        // 更新总资产价值显示
        totalAssetsValueLabel.Text = $"Total Assets Value: ${app.CalculateTotalAssetsValue()}";
    }
}