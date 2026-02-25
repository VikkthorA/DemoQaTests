using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoQaTests.Base
{
    public class BaseTest : IDisposable
    {
        protected readonly IWebDriver Driver;

        public BaseTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
