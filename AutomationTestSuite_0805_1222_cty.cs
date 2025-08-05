// 代码生成时间: 2025-08-05 12:22:30
using Microsoft.Maui.Controls;

using Microsoft.Maui.Essentials;

using System;

using System.Threading.Tasks;

using NUnit.Framework;

using Xamarin.UITest;

using Xamarin.UITest.Queries;



// AutomationTestSuite.cs 是一个用于自动化测试的MAUI框架程序

[TestFixture]

public class AutomationTestSuite

{

    // 定义测试平台

    private readonly Platform[] platforms = { Platform.Android, Platform.iOS };

    private IApp app;


    [OneTimeSetUp]

    // 初始化平台和应用程序

    public void BeforeAll()

    {

        // 配置测试平台

        Configurator.SetDeviceLocatorFlags(DeviceLocatorFlags.PreferLocalToDevice,

            DeviceLocatorFlags.DoNotUseSimulator);




        foreach (var platform in platforms)

        {

            // 启动应用程序并初始化测试

            app = AppInitializer.StartApp(platform);

        }

    }




    [OneTimeTearDown]

    // 清理测试环境

    public void AfterAll()

    {

        app?.Dispose();

        app = null;

    }




    // 测试用例：验证首页标题是否正确

    [Test]

    [Category("Smoke Test")]

    public async Task VerifyHomePageTitleTest()

    {

        try

        {

            // 等待首页加载完成

            await app.WaitForElement(c => c.Marked("Home"));




            // 获取首页标题并验证

            var homePageTitle = app.Query(c => c.Marked("Home")).FirstOrDefault()?.Text ?? "";


            Assert.AreEqual("Home", homePageTitle);




            Console.WriteLine("测试通过：首页标题显示正确");

        }

        catch (Exception ex)

        {

            // 错误处理

            Console.WriteLine("测试失败：" + ex.Message);




            throw;

        }

    }




    // 测试用例：验证按钮点击后页面跳转

    [Test]

    [Category("Functional Test")]

    public async Task VerifyButtonNavigationTest()

    {

        try

        {

            // 点击按钮

            await app.Tap(c => c.Button("GoToDetails"));




            // 等待跳转页面加载完成

            await app.WaitForElement(c => c.Marked("Details"));




            Console.WriteLine("测试通过：按钮点击后成功跳转至详情页");

        }

        catch (Exception ex)

        {

            // 错误处理

            Console.WriteLine("测试失败：" + ex.Message);




            throw;

        }

    }




    // 测试用例：验证输入框内容

    [Test]

    [Category("Regression Test")]

    public async Task VerifyInputFieldContentTest()

    {

        try

        {

            // 输入文本到输入框

            await app.EnterText(c => c.Entry("InputField"), "Test Text");




            // 获取输入框内容并验证

            var inputFieldContent = app.Query(c => c.Entry("InputField")).FirstOrDefault()?.Text ?? "";


            Assert.AreEqual("Test Text", inputFieldContent);




            Console.WriteLine("测试通过：输入框内容显示正确");

        }

        catch (Exception ex)

        {

            // 错误处理

            Console.WriteLine("测试失败：" + ex.Message);




            throw;

        }

    }
}
