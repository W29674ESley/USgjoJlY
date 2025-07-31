// 代码生成时间: 2025-07-31 15:58:35
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.LifecycleEvents;

// 定时任务调度器App
public class ScheduleTaskMauiApp : Application
{
    private readonly ILifecycleEvents _lifecycleEvents;
    private Timer _timer;

    public ScheduleTaskMauiApp(ILifecycleEvents lifecycleEvents)
    {
        _lifecycleEvents = lifecycleEvents;
        _lifecycleEvents.AddEventHandler(LifecycleEvent.ViewDidAppear, OnViewDidAppear);
        _lifecycleEvents.AddEventHandler(LifecycleEvent.ViewDidDisappear, OnViewDidDisappear);

        MainPage = new ContentPage
        {
            Content = new Label
            {
                Text = "定时任务调度器"
            }
        };
    }

    // 当视图出现时，开始定时任务
    private async void OnViewDidAppear(object sender, LifecycleEventArgs e)
    {
        if (_timer == null)
        {
            _timer = new Timer(async _ => await ExecuteTask(), null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
        }
    }

    // 当视图消失时，停止定时任务
    private void OnViewDidDisappear(object sender, LifecycleEventArgs e)
    {
        _timer?.Change(Timeout.Infinite, 0);
    }

    // 执行定时任务
    private async Task ExecuteTask()
    {
        try
        {
            // 这里添加要定时执行的任务代码
            Console.WriteLine("定时任务执行...");
            // 例如，这里可以是数据库操作、文件处理、网络请求等
        }
        catch (Exception ex)
        {
            Console.WriteLine($"执行定时任务时发生错误: {ex.Message}");
        }
    }
}
