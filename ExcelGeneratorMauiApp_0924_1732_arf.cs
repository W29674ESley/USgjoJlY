// 代码生成时间: 2025-09-24 17:32:53
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ExcelGeneratorMauiApp
{
    public class App : Application
    {
        public App(IActivationState activationState)
        {
            MainPage = new MainPage();
        }
    }

    public class MainPage : ContentPage
    {
        public MainPage()
        {
            // Add a button to the page
            Button generateButton = new Button
            {
                Text = "Generate Excel",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            generateButton.Clicked += GenerateButton_Clicked;
            Content = generateButton;
        }

        private async void GenerateButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Generate the Excel file
                await GenerateExcelFileAsync();
                await DisplayAlert("Success", "Excel file generated successfully!", "OK");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async Task GenerateExcelFileAsync()
        {
            // Define the path for the Excel file
            string filePath = "GeneratedExcel.xlsx";

            // Check if there is already a file with the same name
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create an Excel file using OpenXML SDK
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a WorksheetPart to the Workbook
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add Sheets to the Workbook
                Sheets sheets = workbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet();
                sheet.Id = workbookPart.GetIdOfPart(worksheetPart);
                sheet.SheetId = 1;
                sheet.Name = "MySheet";
                sheets.Append(sheet);

                // Add Data to the Sheet
                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                sheetData.Append(new Row());
                Row row = new Row();
                row.Append(new Cell() { CellValue = new CellValue("Name"), DataType = new EnumValue<CellValues>(CellValues.String) });
                row.Append(new Cell() { CellValue = new CellValue("Age"), DataType = new EnumValue<CellValues>(CellValues.String) });
                sheetData.Append(row);

                // Save the changes to the document
                workbookPart.Workbook.Save();
            }
        }
    }
}

// Configure the Maui application
namespace ExcelGeneratorMauiApp
{    public static class MauiProgram
    {        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            return builder.Build();
        }
    }
}