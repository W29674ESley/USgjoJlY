// 代码生成时间: 2025-08-28 14:31:44
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp
{
    /// <summary>
    /// A page that contains a random number generator.
    /// </summary>
    public class RandomNumberGeneratorPage : ContentPage
    {
        private Label resultLabel;
        private Button generateButton;
        private int lowerBound = 1;
        private int upperBound = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNumberGeneratorPage"/> class.
        /// </summary>
        public RandomNumberGeneratorPage()
        {
            // Initialize components
            InitComponents();
            // Layout setup
            SetLayout();
        }

        private void InitializeComponents()
        {
            // Result label to display the random number
            resultLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Button to generate a random number
            generateButton = new Button
            {
                Text = "Generate Random Number",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            generateButton.Clicked += OnGenerateButtonClicked;
        }

        private void SetLayout()
        {
            // StackLayout for organizing the layout
            var layout = new StackLayout
            {
                Children =
                {
                    resultLabel,
                    generateButton
                }
            };

            // Set the content of the page to the layout
            Content = layout;
        }

        private void OnGenerateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Generate a random number within the specified range
                int randomNumber = GenerateRandomNumber(lowerBound, upperBound);
                resultLabel.Text = $"Random Number: {randomNumber}";
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the generation
                resultLabel.Text = $"Error: {ex.Message}";
            }
        }

        private int GenerateRandomNumber(int lowerBound, int upperBound)
        {
            if (upperBound <= lowerBound)
            {
                throw new ArgumentException("Upper bound must be greater than lower bound.");
            }

            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                byte[] randomNumberBytes = new byte[1];
                rng.GetBytes(randomNumberBytes);
                int randomNumber = lowerBound + (randomNumberBytes[0] % (upperBound - lowerBound + 1));
                return randomNumber;
            }
        }
    }
}