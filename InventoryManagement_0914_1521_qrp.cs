// 代码生成时间: 2025-09-14 15:21:43
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementApp
{
    // 库存项模型
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Quantity { get; set; }
    }

    // 库存管理服务
    public class InventoryService
    {
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();

        public InventoryService()
        {
            // 初始化一些库存项
            inventoryItems.Add(new InventoryItem { Id = 1, Name = "Apples", Quantity = 100 });
            inventoryItems.Add(new InventoryItem { Id = 2, Name = "Oranges", Quantity = 150 });
        }

        public InventoryItem[] GetAllItems()
        {
            return inventoryItems.ToArray();
        }

        public InventoryItem? GetItemById(int id)
        {
            return inventoryItems.FirstOrDefault(item => item.Id == id);
        }

        public bool AddItem(InventoryItem item)
        {
            if (inventoryItems.Any(x => x.Id == item.Id))
            {
                throw new ArgumentException("Item with the same ID already exists.");
            }
            inventoryItems.Add(item);
            return true;
        }

        public bool UpdateItem(InventoryItem item)
        {
            var existingItem = inventoryItems.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            existingItem.Name = item.Name;
            existingItem.Quantity = item.Quantity;
            return true;
        }

        public bool RemoveItem(int id)
        {
            var itemToRemove = inventoryItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            return inventoryItems.Remove(itemToRemove);
        }
    }

    // 程序入口点
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var inventoryService = new InventoryService();

                // 示例：添加新库存项
                var newItem = new InventoryItem { Id = 3, Name = "Bananas", Quantity = 200 };
                inventoryService.AddItem(newItem);

                // 示例：获取所有库存项
                var allItems = inventoryService.GetAllItems();
                foreach (var item in allItems)
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}