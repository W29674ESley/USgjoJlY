// 代码生成时间: 2025-08-11 11:39:16
using System;
using System.Security.Cryptography;
using System.Text;
# NOTE: 重要实现细节
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace HashCalculatorApp
{
    // Represents the main page of the MAUI application
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
# 改进用户体验

        // Computes the hash of the input string using the selected hash algorithm
        private async void ComputeHashButton_Clicked(object sender, EventArgs e)
        {
# 扩展功能模块
            try
            {
                // Clear previous results
                HashResultLabel.Text = string.Empty;

                // Get the input string and selected hash algorithm from the UI
# 改进用户体验
                string input = InputTextBox.Text;
                string selectedAlgorithm = HashAlgorithmComboBox.SelectedItem as string;

                if (string.IsNullOrEmpty(input))
                {
                    await DisplayAlert("Error", "Please enter some text to hash.", "OK");
                    return;
# 优化算法效率
                }

                if (string.IsNullOrEmpty(selectedAlgorithm))
# 增强安全性
                {
                    await DisplayAlert("Error", "Please select a hash algorithm.", "OK");
                    return;
                }
# 优化算法效率

                // Compute the hash
                string hash = ComputeHash(input, selectedAlgorithm);

                // Display the result
                HashResultLabel.Text = hash;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the hash computation
# NOTE: 重要实现细节
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
# FIXME: 处理边界情况

        // Computes the hash of a string using the specified algorithm
        private string ComputeHash(string input, string algorithm)
        {
# 增强安全性
            using (HashAlgorithm hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                if (hashAlgorithm == null)
# 增强安全性
                {
                    throw new ArgumentException($"The algorithm '{algorithm}' is not supported.");
                }
# 改进用户体验

                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = hashAlgorithm.ComputeHash(bytes);
# 扩展功能模块
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}