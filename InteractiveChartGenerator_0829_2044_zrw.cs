// 代码生成时间: 2025-08-29 20:44:19
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// 定义交互式图表生成器
public class InteractiveChartGenerator : ContentPage
{
    private SKCanvasView canvasView;
    private List<ChartPoint> points = new List<ChartPoint>();
    private SKPaint linePaint = new SKPaint
    {
        Style = SKPaintStyle.Stroke,
        Color = SKColors.Blue,
        StrokeWidth = 5
    };
    private SKPaint pointPaint = new SKPaint
    {
        Style = SKPaintStyle.Fill,
        Color = SKColors.Red,
        StrokeWidth = 3
    };
    private SKPaint labelPaint = new SKPaint
    {
        Style = SKPaintStyle.Fill,
        TextSize = 20
    };
    private SKPaint gridPaint = new SKPaint
    {
        Style = SKPaintStyle.Stroke,
        Color = SKColors.Gray,
        StrokeWidth = 1
    };
    private float maxPointsCount = 10;
    private float chartWidth = 0;
    private float chartHeight = 0;
    private float pointRadius = 10;
    private SKPoint touchPoint;
    private bool isDrawing = false;

    public InteractiveChartGenerator()
    {
        // 初始化画布
        canvasView = new SKCanvasView
        {
            IgnorePixelScaling = true,
            EnableTouchEvents = true
        };
        canvasView.PaintSurface += OnCanvasViewPaintSurface;
        canvasView.Touch += OnTouch;

        // 添加画布到页面
        Content = canvasView;
    }

    // 绘制图表的方法
    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
    {
        SKCanvas canvas = args.Surface.Canvas;
        canvas.Clear(SKColors.Transparent);
        SKPoint point = new SKPoint(args.Info.Width / 2, args.Info.Height / 2);

        // 绘制网格
        for (float x = 0; x < args.Info.Width; x += 50)
        {
            canvas.DrawLine(x, 0, x, args.Info.Height, gridPaint);
        }

        for (float y = 0; y < args.Info.Height; y += 50)
        {
            canvas.DrawLine(0, y, args.Info.Width, y, gridPaint);
        }

        // 绘制点
        foreach (var p in points)
        {
            canvas.DrawCircle(p.Point, pointRadius, pointPaint);
            canvas.DrawText(p.Value.ToString(), p.Point.X - 20, p.Point.Y + 20, labelPaint);
        }

        // 绘制线
        if (points.Count > 1)
        {
            SKPoint previous = points[0].Point;
            foreach (var p in points.Skip(1))
            {
                canvas.DrawLine(previous, p.Point, linePaint);
                previous = p.Point;
            }
        }
    }

    // 触摸事件处理
    private void OnTouch(object sender, SKTouchEventArgs touchEventArgs)
    {
        switch (touchEventArgs.ActionType)
        {
            case SKTouchAction.Pressed:
                touchPoint = touchEventArgs.Location;
                isDrawing = true;
                break;
            case SKTouchAction.Moved:
                if (isDrawing)
                {
                    points.Add(new ChartPoint
                    {
                        Value = points.Count + 1,
                        Point = new SKPoint(touchPoint.X, touchPoint.Y)
                    });
                    if (points.Count > maxPointsCount)
                    {
                        points.RemoveAt(0);
                    }
                    canvasView.InvalidateSurface();
                }
                break;
            case SKTouchAction.Released:
            case SKTouchAction.Cancelled:
                isDrawing = false;
                break;
        }
    }

    // 定义点的数据模型
    private class ChartPoint
    {
        public float Value { get; set; }
        public SKPoint Point { get; set; }
    }
}
