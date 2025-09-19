// 代码生成时间: 2025-09-19 13:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;

namespace UserLoginSystem
{
    // Represents a user in the system.
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // The user login service class.
    public class UserLoginService
    {
        private readonly List<User> _users;
        private const string PasswordPattern = "^(?=.*[A-Za-z])(?=.*[0-9]).{8,}$";

        public UserLoginService()
        {
            // Initialize with a list of users (for simplicity, stored in memory).
            _users = new List<User>
            {
                new User { Username = "admin", Password = "password123" }
            };
        }

        // Validate user credentials.
        public bool ValidateCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username or password cannot be empty.");
            }

            var user = _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return false;
            }

            if (!Regex.IsMatch(password, PasswordPattern))
            {
                return false;
            }

            return user.Password == password;
        }
    }

    // The main page for the MAUI application.
    public class LoginPage : ContentPage
    {
        private readonly UserLoginService _loginService;
        private Entry _usernameEntry;
        private Entry _passwordEntry;
        private Button _loginButton;

        public LoginPage()
        {
            _loginService = new UserLoginService();

            // Initialize UI components.
            _usernameEntry = new Entry { Placeholder = "Enter Username" };
            _passwordEntry = new Entry { Placeholder = "Enter Password", IsPassword = true };
            _loginButton = new Button { Text = "Login" };

            // Layout the UI components.
            var stackLayout = new StackLayout
            {
                Children =
                {
                    _usernameEntry,
                    _passwordEntry,
                    _loginButton
                }
            };

            Content = stackLayout;

            // Handle login button click event.
            _loginButton.Clicked += async (sender, e) =>
            {
                try
                {
                    var username = _usernameEntry.Text;
                    var password = _passwordEntry.Text;

                    if (_loginService.ValidateCredentials(username, password))
                    {
                        await DisplayAlert("Success", "You have successfully logged in.", "OK");
                        // Navigate to the main application page.
                        // await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid username or password.", "OK");
                    }
                }
                catch (ArgumentException ex)
                {
                    await DisplayAlert("Error", ex.Message, "OK");
                }
            };
        }
    }
}
