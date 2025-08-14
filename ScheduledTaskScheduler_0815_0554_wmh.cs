// 代码生成时间: 2025-08-15 05:54:19
using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls;

// 定时任务调度器类
public class ScheduledTaskScheduler
{
    private readonly DispatcherTimer _timer;
    private readonly TimeSpan _interval;
    private readonly Action _action;
    private bool _isRunning;

    // 构造函数，初始化定时器和任务间隔
    public ScheduledTaskScheduler(Action action, TimeSpan interval)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
        _interval = interval;
        _timer = new DispatcherTimer
        {
            Interval = interval,
            IsRepeating = true
        };
        _timer.Tick += OnTick;
    }

    // 启动定时任务
    public void Start()
    {
        if (!_isRunning)
        {
            _timer.Start();
            _isRunning = true;
        }
    }

    // 停止定时任务
    public void Stop()
    {
        if (_isRunning)
        {
            _timer.Stop();
            _isRunning = false;
        }
    }

    // 定时器触发事件的处理
    private void OnTick(object sender, EventArgs e)
    {
        try
        {
            // 执行传入的动作
            _action.Invoke();
        }
        catch (Exception ex)
        {
            // 错误处理，记录异常信息
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
}

// 定时任务调度器的使用示例
public class MainPage : ContentPage
{
    public MainPage()
    {
        // 创建一个定时任务，每5秒执行一次
        var scheduler = new ScheduledTaskScheduler(ExecuteTask, TimeSpan.FromSeconds(5));

        // 启动定时任务
        scheduler.Start();
    }

    // 定义需要执行的任务
    private void ExecuteTask()
    {
        // 这里放置需要定时执行的代码
        Console.WriteLine("Task executed at: " + DateTime.Now.ToString());
    }
}
