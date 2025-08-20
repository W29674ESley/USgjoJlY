// 代码生成时间: 2025-08-20 11:36:41
using System;

namespace MauiApp.Models
{
    // 定义一个基本的数据模型类，用于存储用户信息
    public class UserModel
    {
        // 用户ID
        public int UserId { get; set; }

        // 用户名
        public string Username { get; set; }

        // 用户邮箱
        public string Email { get; set; }

        // 用户创建时间
        public DateTime CreatedAt { get; set; }

        // 用户最后更新时间
        public DateTime LastUpdatedAt { get; set; }

        // 构造函数
        public UserModel()
        {
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = DateTime.UtcNow;
        }
    }

    // 定义一个数据服务类，用于处理数据操作
    public class DataService
    {
        // 模拟数据库或数据存储的集合
        private readonly List<UserModel> database = new List<UserModel>();

        // 添加用户
        public UserModel AddUser(UserModel user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User model cannot be null.");

            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Username and Email are required.");

            // 添加用户到数据库
            database.Add(user);

            return user;
        }

        // 获取所有用户
        public List<UserModel> GetAllUsers()
        {
            return database;
        }

        // 获取单个用户
        public UserModel GetUser(int userId)
        {
            return database.Find(u => u.UserId == userId);
        }

        // 更新用户信息
        public UserModel UpdateUser(UserModel updatedUser)
        {
            if (updatedUser == null)
                throw new ArgumentNullException(nameof(updatedUser), "Updated user model cannot be null.");

            var user = GetUser(updatedUser.UserId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.LastUpdatedAt = DateTime.UtcNow;

            return user;
        }

        // 删除用户
        public void DeleteUser(int userId)
        {
            var user = GetUser(userId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            database.Remove(user);
        }
    }
}
