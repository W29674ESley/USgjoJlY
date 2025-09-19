// 代码生成时间: 2025-09-20 06:43:55
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace ThemeSwitcherMauiApp
{
    public class MauiApp : Application
    {
        private const string LightTheme = "Light";
        private const string DarkTheme = "Dark";
        private const string DefaultTheme = LightTheme;

        public MauiApp(IServiceProvider services)
        {
            InitializeComponent();

            // Theme initialization
            var theme = Preferences.Get("Theme", DefaultTheme);
            Application.Current.RequestedTheme = theme == DarkTheme ? OSAppTheme.Dark : OSAppTheme.Light;

            // Set MainPage
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class MainPage : ContentPage
    {
        public MainPage()
        {
            // Add a toggle switch for theme
            var themeSwitch = new Switch()
            {
                TrackColor = Color.Gray,
                ThumbColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            themeSwitch.Toggled += (s, e) =>
            {
                var theme = e.Value ? DarkTheme : LightTheme;
                ChangeTheme(theme);
            };

            // Add the switch to the page
            Content = themeSwitch;
        }

        private void ChangeTheme(string theme)
        {
            try
            {
                // Save theme preference
                Preferences.Set("Theme", theme);
                Application.Current.RequestedTheme = theme == DarkTheme ? OSAppTheme.Dark : OSAppTheme.Light;
            }
            catch (Exception ex)
            {
                // Error handling
                Console.WriteLine($"Error changing theme: {ex.Message}");
            }
        }
    }
}
