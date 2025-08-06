// 代码生成时间: 2025-08-06 14:34:09
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace BulkRenameTool
{
    public class BulkRenameTool : ContentPage
    {
        private ListView filesListView;
        private string[] allFiles;
        private List<string> selectedFiles;

        public BulkRenameTool()
        {
            // Initialize the UI components
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Create a label to prompt user
            Label promptLabel = new Label
            {
                Text = "Select files to rename and click rename button."
            };

            // Create a list view for displaying files
            filesListView = new ListView
            {
                ItemsSource = allFiles
            };

            // Create a button for renaming the selected files
            Button renameButton = new Button
            {
                Text = "Rename"
            };
            renameButton.Clicked += OnRenameButtonClicked;

            // Add the controls to the page
            Content = new StackLayout
            {
                Children =
                {
                    promptLabel,
                    filesListView,
                    renameButton
                }
            };
        }

        private void LoadFiles(string directoryPath)
        {
            // Load all files from the specified directory
            allFiles = Directory.GetFiles(directoryPath).ToArray();
            filesListView.ItemsSource = allFiles;
        }

        private async void OnRenameButtonClicked(object sender, EventArgs e)
        {
            // Get selected file names from the list view
            selectedFiles = filesListView.SelectedItems.Cast<string>().ToList();

            if (!selectedFiles.Any())
            {
                await DisplayAlert("Error", "No files selected for renaming.", "OK");
                return;
            }

            // Prompt user for new file name pattern
            string newFileNamePattern = await DisplayPromptAsync("New File Name", "Enter new file name pattern: ", "NewName", "Create");
            if (string.IsNullOrEmpty(newFileNamePattern))
            {
                return;
            }

            try
            {
                // Rename the files
                int index = 1;
                foreach (var filePath in selectedFiles)
                {
                    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), $