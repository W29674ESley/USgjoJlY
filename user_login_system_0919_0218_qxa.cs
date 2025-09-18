// 代码生成时间: 2025-09-19 02:18:23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace UserLoginSystem
{
    // 定义用户类
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // 用户验证服务接口
    public interface IUserService
    {
        bool ValidateUser(User user);
    }

    // 用户服务实现类
    public class UserService : IUserService
    {
        private Dictionary<string, string> _users;

        public UserService()
        {
            // 预设一些用户数据
            _users = new Dictionary<string, string>()
            {
                { "user1", "password1" },
                { "user2", "password2" }
            };
        }

        public bool ValidateUser(User user)
        {
            // 检查用户是否存在
            if (_users.ContainsKey(user.Username) && _users[user.Username] == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // 登录窗口类
    public class LoginWindow : ContentPage
    {
        private Entry _usernameEntry;
        private Entry _passwordEntry;
        private Button _loginButton;
        private IUserService _userService;

        public LoginWindow(IUserService userService)
        {
            _userService = userService;

            _usernameEntry = new Entry
            {
                Placeholder = "Username"
            };

            _passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };

            _loginButton = new Button
            {
                Text = "Login"
            };

            // 设置登录按钮点击事件
            _loginButton.Clicked += async (sender, e) => await HandleLogin();

            // 页面布局
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    _usernameEntry,
                    _passwordEntry,
                    _loginButton
                }
            };
        }

        private async Task HandleLogin()
        {
            try
            {
                User user = new User
                {
                    Username = _usernameEntry.Text,
                    Password = _passwordEntry.Text
                };

                bool isValid = _userService.ValidateUser(user);

                if (isValid)
                {
                    await DisplayAlert("Success", "Login successful!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Invalid username or password!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    public class App : Application
    {
        public App()
        {
            var userService = new UserService();
            var loginWindow = new LoginWindow(userService);

            MainPage = loginWindow;
        }
    }
}