// 代码生成时间: 2025-08-06 00:20:59
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace BatchRenamerApp
{
    public class BatchRenamer
    {
        // 初始化方法，用于设置文件夹路径和重命名模式
        public BatchRenamer(string folderPath, string renamePattern)
        {
            FolderPath = folderPath;
            RenamePattern = renamePattern;
        }

        // 文件夹路径
        private string FolderPath { get; }

        // 重命名模式
        private string RenamePattern { get; }

        // 执行重命名操作
        public void RenameFiles()
        {
            var files = Directory.GetFiles(FolderPath);
            int counter = 1;
            foreach (var file in files)
            {
                try
                {
                    var fileName = Path.GetFileName(file);
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    var fileExtension = Path.GetExtension(file);

                    // 生成新文件名
                    var newFileName = $