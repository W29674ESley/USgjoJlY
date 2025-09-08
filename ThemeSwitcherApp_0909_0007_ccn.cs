// 代码生成时间: 2025-09-09 00:07:02
 * Date: [Current Date]
 *
 * This application demonstrates how to switch between different themes in a MAUI application.
 */
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using System;

namespace ThemeSwitcherApp
{
    // Define a custom application class that handles theme switching.
    public class ThemeSwitcherApp : Application
    {
        private const string DefaultTheme = "DefaultTheme.xaml";
        private const string DarkTheme = "DarkTheme.xaml";

        public ThemeSwitcherApp()
        {
            // Set the initial theme.
            SetTheme(DefaultTheme);

            // Initialize the main page of the application.
            MainPage = new MainPage();
        }

        // Method to switch themes.
        public void SwitchTheme(string themeResource)
        {
            try
            {
                // Check if the theme resource is valid.
                if (string.IsNullOrEmpty(themeResource))
                {
                    throw new ArgumentException("Theme resource cannot be null or empty.");
                }

                // Set the new theme.
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(new StyleProvider(themeResource));
            }
            catch (Exception ex)
            {
                // Handle exceptions.
                Console.WriteLine("An error occurred while switching themes: " + ex.Message);
            }
        }

        // Helper method to set the theme.
        private void SetTheme(string themeResource)
        {
            if (!Application.Current.Resources.MergedDictionaries.ContainsKey("Theme"))
            {
                Application.Current.Resources.MergedDictionaries.Add(new StyleProvider(themeResource));
            }
        }
    }

    // Define a custom class for theme resources.
    public class StyleProvider : IStyleProvider
    {
        private readonly string _themeResource;

        public StyleProvider(string themeResource)
        {
            _themeResource = themeResource;
        }

        public Style GetStyle(string styleKey)
        {
            // Load the style from the theme resource file.
            var style = new Style(styleKey);
            // Return the loaded style.
            return style;
        }
    }
}

// MainPage.xaml - The main page of the application with a button to switch themes.
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ThemeSwitcherApp.MainPage">
    <VerticalStackLayout>
        <!-- Button to switch to the default theme. -->
        <Button Text="Switch to Default Theme" Clicked="SwitchToDefaultTheme" />
        <!-- Button to switch to the dark theme. -->
        <Button Text="Switch to Dark Theme" Clicked="SwitchToDarkTheme" />
    </VerticalStackLayout.CodeBehind>
</ContentPage>

// MainPage.xaml.cs - The code-behind for the main page.
using Microsoft.Maui.Controls;

namespace ThemeSwitcherApp
{    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SwitchToDefaultTheme(object sender, EventArgs e)
        {
            // Switch to the default theme.
            Application.Current as ThemeSwitcherApp.SwitchTheme(ThemeSwitcherApp.DefaultTheme);
        }

        private void SwitchToDarkTheme(object sender, EventArgs e)
        {
            // Switch to the dark theme.
            Application.Current as ThemeSwitcherApp.SwitchTheme(ThemeSwitcherApp.DarkTheme);
        }
    }
}