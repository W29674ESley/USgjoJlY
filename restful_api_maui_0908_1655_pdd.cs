// 代码生成时间: 2025-09-08 16:55:30
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
# TODO: 优化性能
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

// 定义一个简单的模型
public class Resource
{
    public int Id { get; set; }
# 增强安全性
    public string Name { get; set; }
}

// API控制器
[ApiController]
[Route("[controller]/[action]