using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace DemoQaTests.Base
{
    public class BaseTest : IDisposable
    {
        protected readonly IWebDriver Driver;

        public BaseTest()
        {
            Driver = new EdgeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
