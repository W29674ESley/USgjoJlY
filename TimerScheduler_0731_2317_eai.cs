// 代码生成时间: 2025-07-31 23:17:58
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 定时任务调度器，用于在MAUI框架中实现定时任务的调度和执行。
/// </summary>
public class TimerScheduler
{
    private readonly Timer _timer;
    private readonly Action _task;
    private readonly TimeSpan _interval;
    private bool _timerRunning = false;

    /// <summary>
    /// 初始化定时任务调度器实例。
    /// </summary>
    /// <param name="task">要执行的任务。</param>
    /// <param name="interval">执行任务的时间间隔。</param>
    public TimerScheduler(Action task, TimeSpan interval)
    {
        _task = task ?? throw new ArgumentNullException(nameof(task));
        _interval = interval;
        _timer = new Timer(TimerCallback, null, Timeout.Infinite, Timeout.Infinite);
    }

    /// <summary>
    /// 开始执行定时任务。
    /// </summary>
    public void Start()
    {
        if (_timerRunning)
        {
            throw new InvalidOperationException("Timer is already running.");
        }

        _timer.Change(_interval, _interval);
        _timerRunning = true;
    }

    /// <summary>
    /// 停止执行定时任务。
    /// </summary>
    public void Stop()
    {
        if (!_timerRunning)
        {
            throw new InvalidOperationException("Timer is not running.");
        }

        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        _timerRunning = false;
    }

    /// <summary>
    /// 定时器回调函数，用于执行具体的任务。
    /// </summary>
    private void TimerCallback(object state)
    {
        try
        {
            _task.Invoke();
        }
        catch (Exception ex)
        {
            // 错误处理：记录错误日志或抛出异常
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
}

/// <summary>
/// 程序主入口，用于示例演示定时任务调度器的使用方法。
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 定义一个示例任务：每秒打印当前时间
        Action printTimeTask = () => Console.WriteLine($"Current time: {DateTime.Now}");

        // 创建定时任务调度器实例，设置任务执行间隔为1秒
        TimerScheduler timerScheduler = new TimerScheduler(printTimeTask, TimeSpan.FromSeconds(1));

        // 启动定时任务
        timerScheduler.Start();

        // 模拟程序运行3秒后停止定时任务
        Task.Delay(3000).Wait();
        timerScheduler.Stop();
    }
}