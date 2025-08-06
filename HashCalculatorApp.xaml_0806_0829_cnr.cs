// 代码生成时间: 2025-08-06 08:29:32
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Text;
using System.Security.Cryptography;

// 哈希值计算工具MAUI页面
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HashCalculatorApp : ContentPage
{
    // 构造函数
    public HashCalculatorApp()
    {
        InitializeComponent();
    }

    // 计算哈希值按钮事件处理函数
    private async void CalculateHashButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            string inputText = InputEntry.Text;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                await DisplayAlert("错误", "请输入要计算哈希值的文本", "确定");
                return;
            }

            string hashAlgorithm = HashAlgorithmComboBox.SelectedItem as string;
            if (hashAlgorithm == null)
            {
                await DisplayAlert("错误", "请选择一个哈希算法", "确定");
                return;
            }

            string hashValue = await CalculateHashAsync(inputText, hashAlgorithm);
            ResultEntry.Text = hashValue;
        }
        catch (Exception ex)
        {
            await DisplayAlert("错误", $"计算哈希值时发生错误: {ex.Message}", "确定");
        }
    }

    // 异步计算哈希值
    private async Task<string> CalculateHashAsync(string input, string algorithm)
    {
        switch (algorithm)
        {
            case "MD5":
                return await CalculateMD5Async(input);
            case "SHA1":
                return await CalculateSHA1Async(input);
            case "SHA256":
                return await CalculateSHA256Async(input);
            case "SHA512":
                return await CalculateSHA512Async(input);
            default:
                throw new NotSupportedException($"不支持的哈希算法: {algorithm}");
        }
    }

    // 计算MD5哈希值
    private async Task<string> CalculateMD5Async(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = await Task.Run(() => md5.ComputeHash(inputBytes));
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }

    // 计算SHA1哈希值
    private async Task<string> CalculateSHA1Async(string input)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = await Task.Run(() => sha1.ComputeHash(inputBytes));
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }

    // 计算SHA256哈希值
    private async Task<string> CalculateSHA256Async(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = await Task.Run(() => sha256.ComputeHash(inputBytes));
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }

    // 计算SHA512哈希值
    private async Task<string> CalculateSHA512Async(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = await Task.Run(() => sha512.ComputeHash(inputBytes));
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}