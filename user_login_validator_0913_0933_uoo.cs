// 代码生成时间: 2025-09-13 09:33:50
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

// 用户登录验证系统
namespace UserLoginSystem
{
    public class UserLoginValidator
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>();

        // 构造函数，初始化用户数据
        public UserLoginValidator()
        {
            // 这里使用硬编码的用户名和密码作为示例
            // 在实际应用中，应从数据库或其他安全的存储中获取
            users.Add("user1", "password1");
            users.Add("user2", "password2");
        }

        // 用户登录验证方法
        public bool ValidateUser(string username, string password)
        {
            // 检查用户名是否存在
            if (!users.ContainsKey(username))
            {
                Console.WriteLine("Username not found.");
                return false;
            }

            // 检查用户名和密码是否匹配
            if (users[username] == HashPassword(password))
            {
                Console.WriteLine("User login successful.");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password.");
                return false;
            }
        }

        // 密码哈希化方法
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }

    // 程序入口点
    public class App : Application
    {
        public App()
        {
            var mainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "User Login System" },
                        new Entry { Placeholder = "Username" },
                        new Entry { Placeholder = "Password", IsPassword = true },
                        new Button
                        {
                            Text = "Login",
                            Command = new Command(async () =>
                            {
                                string username = ((Entry)MainPage.FindByName("usernameEntry")).Text;
                                string password = ((Entry)MainPage.FindByName("passwordEntry")).Text;

                                var validator = new UserLoginValidator();
                                bool isValid = validator.ValidateUser(username, password);

                                if (isValid)
                                {
                                    await MainPage.DisplayAlert("Success", "Login successful!", "OK");
                                }
                                else
                                {
                                    await MainPage.DisplayAlert("Error", "Login failed.", "OK");
                                }
                            })
                        }
                    }
                }
            };

            MainPage = mainPage;
        }
    }
}