// 代码生成时间: 2025-08-12 06:08:14
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Linq;
using OfficeOpenXml;

// Excel表格自动生成器
public partial class ExcelGeneratorApp : ContentPage
{
    // 构造函数
    public ExcelGeneratorApp()
    {
        InitializeComponent();
    }

    // 生成Excel文件的方法
    private async void GenerateExcelFile(object sender, EventArgs e)
    {
        try
        {
            // 使用EPPlus库创建Excel文件
            using (var package = new ExcelPackage())
            {
                // 添加一个新的工作簿
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 填充数据
                worksheet.Cells["A1"].Value = "Column 1";
                worksheet.Cells["B1"].Value = "Column 2";
                // 可以根据需要添加更多的单元格数据

                // 保存文件到临时目录
                var tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ExcelFile.xlsx");
                await using (var stream = File.Create(tempFilePath))
                {
                    package.SaveAs(stream);
                }

                // 通知用户文件已生成
                await DisplayAlert("Success", $"Excel file generated at: {tempFilePath}", "OK");
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
