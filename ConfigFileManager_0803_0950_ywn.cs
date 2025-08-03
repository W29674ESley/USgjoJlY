// 代码生成时间: 2025-08-03 09:50:56
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
# TODO: 优化性能
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Controls;

namespace MauiApp
{
    /// <summary>
# 添加错误处理
    /// 配置文件管理器，用于加载和保存配置文件。
    /// </summary>
    public class ConfigFileManager
    {
        private readonly string _configFilePath;

        /// <summary>
# 扩展功能模块
        /// 初始化配置文件管理器。
        /// </summary>
        /// <param name="configFilePath">配置文件路径</param>
# TODO: 优化性能
        public ConfigFileManager(string configFilePath)
        {
            _configFilePath = configFilePath ?? throw new ArgumentNullException(nameof(configFilePath));
        }

        /// <summary>
        /// 加载配置文件。
        /// </summary>
        /// <typeparam name="T">配置文件中的数据类型</typeparam>
        /// <returns>返回配置文件中的数据对象</returns>
# NOTE: 重要实现细节
        public T LoadConfig<T>() where T : class
        {
            try
            {
                if (File.Exists(_configFilePath))
                {
                    string configJson = File.ReadAllText(_configFilePath);
                    return JsonSerializer.Deserialize<T>(configJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    throw new FileNotFoundException("配置文件未找到。");
                }
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("配置文件格式错误。", ex);
# 优化算法效率
            }
            catch (Exception ex)
            {
                throw new Exception("加载配置文件时发生错误。", ex);
            }
        }

        /// <summary>
# TODO: 优化性能
        /// 保存配置文件。
        /// </summary>
        /// <param name="config">要保存的配置对象</param>
        public void SaveConfig<T>(T config) where T : class
        {
# 优化算法效率
            try
            {
                string configJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true });
                File.WriteAllText(_configFilePath, configJson);
            }
            catch (Exception ex)
            {
                throw new Exception("保存配置文件时发生错误。", ex);
            }
        }
    }
}
