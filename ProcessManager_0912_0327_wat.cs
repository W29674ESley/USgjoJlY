// 代码生成时间: 2025-09-12 03:27:29
// ProcessManager.cs
// 进程管理器程序，用于列出和管理系统进程。

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ProcessManagerApp
{
    public class ProcessManager : ContentPage
    {
        private ListView processListView;
        private List<ProcessListItem> processList;

        public ProcessManager()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            processListView = new ListView
            {
                HasUnevenRows = true,
                RowHeight = -1 // -1 makes the cells as tall as their content
            };

            processListView.ItemTemplate = new DataTemplate(() =>
            {
                var label = new Label();
                label.SetBinding(Label.TextProperty, "Name");
                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, new Binding("Id") { StringFormat = "PID: {0}" });
                var cell = new ViewCell
                {
                    View = new StackLayout
                    {
                        Children = { nameLabel, label }
                    }
                };
                return cell;
            });

            Content = processListView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProcessList();
        }

        private void UpdateProcessList()
        {
            try
            {
                processList = Process.GetProcesses()
                    .Select(p => new ProcessListItem
                    {
                        Id = p.Id,
                        Name = p.ProcessName
                    }).ToList();

                processListView.ItemsSource = processList;
            }
            catch (Exception ex)
            {
                // Handle exceptions such as access denied when trying to get process list
                Console.WriteLine($"Error retrieving process list: {ex.Message}");
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private class ProcessListItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Displays an alert dialog with the given title, message, and button
        private void DisplayAlert(string title, string message, string button)
        {
            DisplayAlert(title, message, button);
        }
    }
}
