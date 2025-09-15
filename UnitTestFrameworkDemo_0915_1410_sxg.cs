// 代码生成时间: 2025-09-15 14:10:29
using System;
using Microsoft.Maui.Controls;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

// 单元测试框架演示程序
namespace UnitTestFrameworkDemo
{
    public class UnitTestFrameworkDemo
    {
        // 测试用例1：测试加法运算
        [Test]
        public void TestAddition()
        {
            // 准备测试数据
            int a = 1;
            int b = 2;
            int expected = 3;
            // 执行测试
            int result = Add(a, b);
            // 验证结果
            Assert.AreEqual(expected, result);
        }

        // 测试用例2：测试减法运算
        [Test]
        public void TestSubtraction()
        {
            // 准备测试数据
            int a = 5;
            int b = 2;
            int expected = 3;
            // 执行测试
            int result = Subtract(a, b);
            // 验证结果
            Assert.AreEqual(expected, result);
        }

        // 被测函数：加法运算
        private int Add(int a, int b)
        {
            return a + b;
        }

        // 被测函数：减法运算
        private int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
