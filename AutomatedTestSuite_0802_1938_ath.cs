// 代码生成时间: 2025-08-02 19:38:03
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Maui.TestUtils.DeviceTests.Runners;

namespace AutomatedTestSuite
{
    /// <summary>
    /// Automation test suite for MAUI applications.
    /// </summary>
    [TestFixture]
    public class AutomatedTestSuite
    {
        /// <summary>
        /// Initializes the test suite with a MAUI application.
        /// </summary>
        [SetUp]
        public void InitializeTestSuite()
        {
            // Initialize the MAUI application before each test
            var app = new MauiApp
            {
               _builder = builder => builder
                   .UseMauiApp<App>()
            };

            app.CreateMockWindow();
        }

        /// <summary>
        /// Tests if the application launches correctly.
        /// </summary>
        [Test]
        public async Task ApplicationLaunchesCorrectly()
        {
            var app = new MauiApp
            {
               _builder = builder => builder
                   .UseMauiApp<App>()
            };

            await app.LaunchAsync();

            Assert.IsTrue(app.IsApplicationRunning, "The application failed to launch correctly.");
        }

        /// <summary>
        /// Tests if a specific page is displayed after navigation.
        /// </summary>
        [Test]
        public async Task NavigationToPage()
        {
            var app = new MauiApp
            {
               _builder = builder => builder
                   .UseMauiApp<App>()
            };

            await app.LaunchAsync();

            // Perform navigation to the target page
            await app.InvokeOnMainThreadAsync(() =>
            {
                var navigationPage = new NavigationPage(new ContentPage
                {
                    Title = "Test"
                });
                app.CurrentWindow.Navigation = navigationPage;
            });

            Assert.IsNotNull(app.CurrentWindow.Navigation, "Navigation page is not found.");
        }

        /// <summary>
        /// Tests if an exception is thrown when a page is not found.
        /// </summary>
        [Test]
        public void PageNotFoundException()
        {
            var app = new MauiApp
            {
               _builder = builder => builder
                   .UseMauiApp<App>()
            };

            // Attempt to navigate to a non-existent page
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await app.InvokeOnMainThreadAsync(() =>
                {
                    var navigationPage = new NavigationPage(new ContentPage
                    {
                        Title = "NonExistentPage"
                    });
                    app.CurrentWindow.Navigation = navigationPage;
                });
            });
        }

        /// <summary>
        /// Tears down the test suite after each test.
        /// </summary>
        [TearDown]
        public void CleanUpTestSuite()
        {
            // Clean up any resources used during the test
            // (e.g., close the application, remove files, etc.)
        }
    }
}
