// 代码生成时间: 2025-09-11 11:21:38
 * Follows C# best practices for maintainability and extensibility.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace MyApp.Services
{
    public class NotificationService
    {
        private readonly IMessenger _messenger;

        public NotificationService(IMessenger messenger)
        {
            _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
        }

        // Sends a notification to all registered receivers.
        public async Task SendNotificationAsync(string notificationKey, object message)
        {
            // Check for null or empty notification key.
            if (string.IsNullOrEmpty(notificationKey))
            {
                throw new ArgumentException("Notification key cannot be null or empty.", nameof(notificationKey));
            }

            // Create a new notification message.
            var notificationMessage = new NotificationMessage<object>(message)
            {
                Key = notificationKey
            };

            // Dispatch the notification to all subscribers.
            await _messenger.SendAsync(notificationMessage).ConfigureAwait(false);
        }

        // Subscribes to a notification key.
        public void Subscribe(string notificationKey, Action<object> callback)
        {
            // Check for null callback.
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            // Register the callback to receive notifications for the given key.
            _messenger.Register<NotificationMessage<object>>(this, notificationKey, callback);
        }

        // Unsubscribes from a notification key.
        public void Unsubscribe(string notificationKey, Action<object> callback)
        {
            // Check for null callback.
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            // Unregister the callback to stop receiving notifications for the given key.
            _messenger.Unregister<NotificationMessage<object>>(this, notificationKey, callback);
        }
    }
}
