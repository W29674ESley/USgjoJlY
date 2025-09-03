// 代码生成时间: 2025-09-04 05:14:27
using System;
using Microsoft.Maui.Controls;
using SkiaSharp;
using SkiaSharp.Views.Maui;

// 交互式图表生成器
public class InteractiveChartGenerator : ContentPage
{
    private SKCanvasView canvasView;
    private SKPaint textPaint;
    private float max;
    private float min;
    private Random random;

    public InteractiveChartGenerator()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // 初始化随机数生成器
        random = new Random();

        // 定义画布视图
        canvasView = new SKCanvasView
        {
            IgnorePixelScaling = true,
            EnableTouchEvents = true,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        // 注册触摸事件
        canvasView.Touch += OnTouch;

        // 定义文本绘制工具
        textPaint = new SKPaint
        {
            Color = SKColors.Black,
            TextAlign = SKTextAlign.Center,
            TextSize = 20
        };

        // 设置最大值和最小值
        max = 100;
        min = 0;

        // 添加画布视图到页面
        Content = canvasView;
    }

    private void OnTouch(object sender, SKTouchEventArgs e)
    {
        if (e.ActionType == SKTouchAction.Pressed)
        {
            // 清除画布
            canvasView.InvalidateSurface();
        }
        else if (e.ActionType == SKTouchAction.Moved)
        {
            // 在触摸移动时生成新的图表
            GenerateChart(e.Location);
            canvasView.InvalidateSurface();
        }
    }

    private void GenerateChart(SKPoint point)
    {
        using (var paint = new SKPaint { Mode = SKPaintMode.Stroke, Style = SKPaintStyle.Stroke, Color = SKColors.Blue })
        {
            // 根据触摸位置生成随机数据
            float value = (float)Math.Sin(point.X / 10) * (max - min) + min + random.NextDouble() * 10 - 5;
            if (value > max) value = max;
            if (value < min) value = min;

            // 绘制图表
            using (var canvas = canvasView.CreateDrawingSurface())
            {
                canvas.Clear(SKColors.Transparent);
                SKPath path = new SKPath();
                path.MoveTo(point.X, canvas.Size.Height - value);
                path.LineTo(point.X, canvas.Size.Height);
                canvas.DrawPath(path, paint);

                // 绘制文本
                canvas.DrawText($"Value: {value}", point.X, canvas.Size.Height - 20, textPaint);
            }
        }
    }
}
