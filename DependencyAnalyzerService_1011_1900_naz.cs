// 代码生成时间: 2025-10-11 19:00:49
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

// 创建一个简单的依赖关系分析器服务
public class DependencyAnalyzerService
{
    // 构造函数，初始化一个空的依赖项集合
    public DependencyAnalyzerService()
    {
        DependencyGraph = new Dictionary<string, List<string>>();
    }

    // 依赖图，键是模块名，值是依赖它的模块列表
    private Dictionary<string, List<string>> DependencyGraph { get; set; }

    // 添加依赖关系
    public void AddDependency(string module, string dependentModule)
    {
        // 如果模块不存在于依赖图中，则添加它
        if (!DependencyGraph.ContainsKey(module))
        {
            DependencyGraph[module] = new List<string>();
        }

        // 添加依赖项
        DependencyGraph[module].Add(dependentModule);
    }

    // 分析依赖关系
    public void AnalyzeDependencies()
    {
        // 遍历依赖图，寻找循环依赖
        foreach (var module in DependencyGraph)
        {
            foreach (var dependentModule in module.Value)
            {
                // 检查是否存在循环依赖
                if (DependencyGraph.ContainsKey(dependentModule) && DependencyGraph[dependentModule].Contains(module.Key))
                {
                    throw new InvalidOperationException($"Circular dependency detected between '{module.Key}' and '{dependentModule}'");
                }
            }
        }
    }

    // 获取所有依赖于指定模块的模块列表
    public List<string> GetDependents(string module)
    {
        // 检查模块是否存在于依赖图中
        if (!DependencyGraph.ContainsKey(module))
        {
            throw new KeyNotFoundException($"Module '{module}' not found in dependency graph");
        }

        // 返回依赖于指定模块的模块列表
        return DependencyGraph[module];
    }
}
