// 代码生成时间: 2025-08-24 22:15:31
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace SystemPerformanceMonitorApp
{
    public class SystemPerformanceMonitor : ContentView
    {
        private readonly Label cpuUsageLabel;
        private readonly Label memoryUsageLabel;
        private readonly Label diskUsageLabel;

        public SystemPerformanceMonitor()
        {
            // Initialize the labels to display performance metrics
            cpuUsageLabel = new Label
            {
                Text = "CPU Usage: 0%"
            };
            memoryUsageLabel = new Label
            {
                Text = "Memory Usage: 0%"
            };
            diskUsageLabel = new Label
            {
                Text = "Disk Usage: 0%"
            };

            // Add labels to the content view
            Content = new VerticalStackLayout
            {
                Children =
                {
                    cpuUsageLabel,
                    memoryUsageLabel,
                    diskUsageLabel
                }
            };
        }

        // Start monitoring system performance metrics
        public async Task StartMonitoringAsync()
        {
            try
            {
                while (true)
                {
                    // Update CPU usage
                    double cpuUsage = GetCpuUsage();
                    cpuUsageLabel.Text = $"CPU Usage: {cpuUsage}%";

                    // Update memory usage
                    double memoryUsage = GetMemoryUsage();
                    memoryUsageLabel.Text = $"Memory Usage: {memoryUsage}%";

                    // Update disk usage
                    double diskUsage = GetDiskUsage();
                    diskUsageLabel.Text = $"Disk Usage: {diskUsage}%";

                    // Update labels every second
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during monitoring
                Console.WriteLine($"Error monitoring system performance: {ex.Message}");
            }
        }

        // Get CPU usage as a percentage
        private double GetCpuUsage()
        {
            // Get the total processor time
            double totalProcessorTime = 0;
            foreach (var proc in Process.GetProcesses())
            {
                totalProcessorTime += proc.TotalProcessorTime.TotalMilliseconds;
            }

            // Calculate the CPU usage percentage
            double cpuUsage = totalProcessorTime / (Environment.ProcessorCount * 1000.0);
            return cpuUsage;
        }

        // Get memory usage as a percentage
        private double GetMemoryUsage()
        {
            // Get the total physical memory and the amount of memory in use
            long totalMemory = new DriveInfo("C").TotalSize;
            long usedMemory = new DriveInfo("C").UsedSpace;

            // Calculate the memory usage percentage
            double memoryUsage = usedMemory / (double)totalMemory * 100.0;
            return memoryUsage;
        }

        // Get disk usage as a percentage
        private double GetDiskUsage()
        {
            // Get the total disk space and the amount of disk space in use
            long totalDiskSpace = new DriveInfo("C").TotalSize;
            long usedDiskSpace = new DriveInfo("C").UsedSpace;

            // Calculate the disk usage percentage
            double diskUsage = usedDiskSpace / (double)totalDiskSpace * 100.0;
            return diskUsage;
        }
    }
}
