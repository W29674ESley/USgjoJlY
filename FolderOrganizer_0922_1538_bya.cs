// 代码生成时间: 2025-09-22 15:38:31
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// 文件夹结构整理器
public class FolderOrganizer
{
    // 目标文件夹路径
    private readonly string targetFolderPath;

    // 构造函数
    public FolderOrganizer(string targetFolderPath)
    {
        if (!Directory.Exists(targetFolderPath))
        {
            throw new ArgumentException($"The specified path '{targetFolderPath}' does not exist.");
        }

        this.targetFolderPath = targetFolderPath;
    }

    // 整理文件夹
    public void OrganizeFolders()
    {
        try
        {
            // 获取目标文件夹下的所有文件和子文件夹
            var items = Directory.EnumerateFileSystemEntries(targetFolderPath);

            // 创建一个字典来保存文件类型与文件路径的映射
            var fileTypeMap = new Dictionary<string, List<string>>();

            foreach (var itemPath in items)
            {
                var extension = Path.GetExtension(itemPath);
                if (!fileTypeMap.ContainsKey(extension))
                {
                    fileTypeMap[extension] = new List<string>();
                }

                fileTypeMap[extension].Add(itemPath);
            }

            // 根据文件类型移动文件到对应的子文件夹中
            foreach (var fileType in fileTypeMap)
            {
                var folderPath = Path.Combine(targetFolderPath, fileType.Key.TrimStart('.'));
                Directory.CreateDirectory(folderPath);
                foreach (var filePath in fileType.Value)
                {
                    var fileName = Path.GetFileName(filePath);
                    var destFilePath = Path.Combine(folderPath, fileName);
                    File.Move(filePath, destFilePath);
                }
            }

            Console.WriteLine("Well done! Folders have been organized successfully.");
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// 演示如何使用文件夹结构整理器
class Program
{
    static void Main(string[] args)
    {
        try
        {
            var organizer = new FolderOrganizer("C:\MyDocuments");
            organizer.OrganizeFolders();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to organize folders: {ex.Message}");
        }
    }
}