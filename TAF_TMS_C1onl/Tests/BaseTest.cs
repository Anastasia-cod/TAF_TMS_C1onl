using Allure.Commons;
using NLog;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;

namespace TAF_TMS_C1onl.Tests;

[AllureNUnit]
[Parallelizable(ParallelScope.All)]
public class BaseTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    protected IWebDriver Driver;
    protected NavigationSteps NavigationSteps;
    protected ProjectSteps ProjectSteps;
    private AllureLifecycle _allure;

    [SetUp]
    public void Setup()
    {
        _logger.Trace(message: "Message level Trace");
        _logger.Debug(message: "Message level Debug");
        _logger.Info(message: "Message level Info");
        _logger.Warn(message: "Message level Warn");
        _logger.Error(message: "Message level Error");
        _logger.Fatal(message: "Message level Fatal");

        Driver = new Browser().Driver;
        
        // Инициализация Steps
        NavigationSteps = new NavigationSteps(Driver);
        ProjectSteps = new ProjectSteps(Driver);

        //Инициализация Allure
        _allure = AllureLifecycle.Instance;
    }

    [TearDown]
    public void TearDown()
    {
        //Проверка, что тест упал
        if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            //Создание скриншота
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            //Прикрепление скриншота
            _allure.AddAttachment(name: "Screenshot", type:"image/png", screenshotBytes);
        }

        Driver.Quit();
        Driver.Dispose();
    }
}