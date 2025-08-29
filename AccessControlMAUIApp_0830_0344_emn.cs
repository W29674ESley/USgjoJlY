// 代码生成时间: 2025-08-30 03:44:44
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Threading.Tasks;

namespace AccessControlMAUIApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        const string UserName = "admin";
        const string Password = "password123";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string username = UsernameEntry.Text;
                string password = PasswordEntry.Text;

                if (await AuthenticateUser(username, password))
                {
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Access Denied", "Invalid username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            // Simulate user authentication
            if (username == UserName && password == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class HomePage : ContentPage
    {
        public HomePage()
        {
            // HomePage content initialization
            Title = "Home Page";
            Content = new Label
            {
                Text = "Welcome to the Home Page"
            };
        }
    }
}
