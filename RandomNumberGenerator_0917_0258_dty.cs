// 代码生成时间: 2025-09-17 02:58:23
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls.Xaml;

namespace RandomNumberGeneratorApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomNumberGenerator : ContentPage
    {
        private readonly Random _random = new Random();

        public RandomNumberGenerator()
        {
            InitializeComponent();
        }

        // 生成随机数的方法
        private int GenerateRandomNumber(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("Minimum value must be less than maximum value.", nameof(min));
            }

            return _random.Next(min, max + 1);
        }

        // 当点击按钮时调用的方法
        private async Task GenerateAndDisplayRandomNumber()
        {
            try
            {
                int randomNumber = GenerateRandomNumber(1, 100); // 以1到100作为范围
                // 更新UI，显示随机数
                DisplayRandomNumber(randomNumber);
            }
            catch (Exception ex)
            {
                // 异常处理，显示错误消息
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // 显示随机数的方法
        private void DisplayRandomNumber(int randomNumber)
        {
            // 假设有一个名为randomNumberLabel的Label控件
            randomNumberLabel.Text = $"Random Number: {randomNumber}";
        }
    }
}
