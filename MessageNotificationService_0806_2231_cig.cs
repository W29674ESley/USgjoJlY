// 代码生成时间: 2025-08-06 22:31:36
// MessageNotificationService.cs
// This class provides a message notification system.

using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Services;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiNotificationDemo
{
    public class MessageNotificationService
    {
        // Send a notification message to the user.
        public async Task SendNotificationAsync(string title, string message)
        {
            try
            {
                // Use the ToastService to send a toast notification.
                await ToastService.ShowToastAsync(new ToastOptions
                {
                    Title = title,
                    Message = message,
                    Duration = ToastDuration.Long,
                    Position = ToastPosition.Bottom
                });
            }
            catch (Exception ex)
            {
                // Log the error and handle it appropriately.
                Console.WriteLine($"Error sending notification: {ex.Message}");
            }
        }
    }
}
