// 代码生成时间: 2025-08-30 22:10:20
using System;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Maui.Controls; // Ensure that this is included for MAUI controls

// SchedulerPage is a simple MAUI page that contains a button to start and stop the scheduler
namespace ScheduledTaskManager
{
    public class SchedulerPage : ContentPage
    {
        private Timer timer;
        private bool isRunning = false;
        private readonly object _lock = new object();

        public SchedulerPage()
        {
            // Initialize components
            Button startButton = new Button
            {
                Text = "Start Scheduler",
                HorizontalOptions = LayoutOptions.Center
            };
            startButton.Clicked += OnStartClicked;

            Button stopButton = new Button
            {
                Text = "Stop Scheduler",
                HorizontalOptions = LayoutOptions.Center
            };
            stopButton.Clicked += OnStopClicked;

            // Add buttons to the page
            Content = new StackLayout
            {
                Children = { startButton, stopButton }
            };
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (!isRunning)
                {
                    timer = new Timer(1000); // Set timer interval to 1000ms (1 second)
                    timer.Elapsed += OnTimerElapsed;
                    timer.AutoReset = true;
                    timer.Start();
                    isRunning = true;
                    ((Button)sender).Text = "Stop Scheduler";
                }
            }
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            lock (_lock)
            {
                if (isRunning)
                {
                    timer?.Stop();
                    timer?.Dispose();
                    timer = null;
                    isRunning = false;
                    ((Button)sender).Text = "Start Scheduler";
                }
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // Execute scheduled task here
                Console.WriteLine("Scheduled task executed at: " + DateTime.Now);
                // You can add more logic to perform the scheduled tasks
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the task execution
                Console.WriteLine("Error occurred during scheduled task execution: " + ex.Message);
            }
        }
    }
}
