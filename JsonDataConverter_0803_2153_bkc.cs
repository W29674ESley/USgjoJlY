// 代码生成时间: 2025-08-03 21:53:54
using System;
using System.Text.Json;
using Microsoft.Maui.Controls;
using System.IO;

namespace JsonDataConverterApp
{
    // Define a ViewModel for the JSON data converter.
    public class JsonDataConverterViewModel : BindableObject
    {
        private string jsonData;
        private string formattedJsonData;

        public string JsonData
        {
            get { return jsonData; }
            set
            {
                jsonData = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FormattedJsonData));
            }
        }

        public string FormattedJsonData
        {
            get { return formattedJsonData; }
            private set
            {
                formattedJsonData = value;
                OnPropertyChanged();
            }
        }

        public void ConvertJson()
        {
            try
            {
                // Parse the JSON data to check for validity.
                var parsed = JsonSerializer.Deserialize<object>(JsonData);

                if (parsed == null)
                {
                    FormattedJsonData = "Invalid JSON data.";
                    return;
                }

                // Serialize the JSON data to a formatted string.
                FormattedJsonData = JsonSerializer.Serialize(parsed, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (JsonException ex)
            {
                FormattedJsonData = $"Error parsing JSON: {ex.Message}";
            }
        }
    }

    // Define a page for the JSON data converter.
    public class JsonDataConverterPage : ContentPage
    {
        private Entry inputEntry;
        private Button convertButton;
        private Label resultLabel;
        private JsonDataConverterViewModel viewModel;

        public JsonDataConverterPage()
        {
            // Initialize the ViewModel.
            viewModel = new JsonDataConverterViewModel();
            BindingContext = viewModel;

            // Create and configure the input Entry.
            inputEntry = new Entry
            {
                Placeholder = "Enter JSON data"
            };
            inputEntry.SetBinding(Entry.TextProperty, new Binding("JsonData", BindingMode.TwoWay));

            // Create and configure the Convert button.
            convertButton = new Button
            {
                Text = "Convert",
                Command = new Command(viewModel.ConvertJson)
            };

            // Create and configure the result Label.
            resultLabel = new Label();
            resultLabel.SetBinding(Label.TextProperty, new Binding("FormattedJsonData", BindingMode.OneWay));

            // Set the Content of the page.
            Content = new StackLayout
            {
                Children =
                {
                    inputEntry,
                    convertButton,
                    resultLabel
                }
            };
        }
    }
}
