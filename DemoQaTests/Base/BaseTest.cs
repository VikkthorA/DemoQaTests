using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DemoQaTests.Base
{
    public class BaseTest : IDisposable
    {
        protected readonly IWebDriver Driver;

        public BaseTest()
        {
            BrowserType targetBrowser = BrowserType.Chrome;

            Driver = StartDriver(targetBrowser);
            Driver.Manage().Window.Maximize();
        }
        private IWebDriver StartDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Edge => new EdgeDriver(),
                _ => throw new ArgumentException("Unsupported browser type")
            };
        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
