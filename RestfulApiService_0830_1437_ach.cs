// 代码生成时间: 2025-08-30 14:37:48
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// 定义一个简单的数据模型
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// RESTful API接口控制器
[ApiController]
[Route("[controller]/[action]