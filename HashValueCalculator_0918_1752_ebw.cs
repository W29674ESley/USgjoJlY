// 代码生成时间: 2025-09-18 17:52:55
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiApp
{
    // 主界面类
    public class MainPage : ContentPage
    {
        private Entry inputText;
        private Label resultLabel;
        private Button calculateButton;

        public MainPage()
        {
            // 设置主界面布局
            VerticalStackLayout layout = new VerticalStackLayout();

            // 初始化输入框
            inputText = new Entry
            {
                Placeholder = "Enter text to calculate hash",
                Margin = new Thickness(10)
            };

            // 初始化结果标签
            resultLabel = new Label
            {
                Text = "Result will appear here",
                Margin = new Thickness(10)
            };

            // 初始化计算按钮
            calculateButton = new Button
            {
                Text = "Calculate Hash",
                Margin = new Thickness(10),
                Command = new Command(CalculateHash)
            };

            // 添加控件到布局
            layout.Add(inputText);
            layout.Add(resultLabel);
            layout.Add(calculateButton);

            // 设置主界面内容
            Content = layout;
        }

        // 计算哈希值的方法
        private async void CalculateHash()
        {
            try
            {
                // 获取输入框中的文本
                string input = inputText.Text;

                // 检查输入是否为空
                if (string.IsNullOrEmpty(input))
                {
                    resultLabel.Text = "Please enter text to calculate hash";
                    return;
                }

                // 使用SHA256算法计算哈希值
                string hash = GetSha256Hash(input);

                // 显示结果
                resultLabel.Text = $"Hash: {hash}";
            }
            catch (Exception ex)
            {
                // 错误处理
                resultLabel.Text = $"Error: {ex.Message}";
            }
        }

        // 使用SHA256算法生成哈希值的辅助方法
        private string GetSha256Hash(string input)
        {
            // 使用SHA256算法创建哈希
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // 将输入转换为字节数组
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // 计算哈希值
                byte[] hashBytes = sha256Hash.ComputeHash(bytes);

                // 将哈希值转换为十六进制字符串
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}