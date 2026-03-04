using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace DemoQaTests.ElementsPages
{
    public class LinksPage : BasePage
    {
        public LinksPage(IWebDriver driver) : base(driver) { }

        private readonly By _homeLink = By.Id("simpleLink");

        public void ClickHomeLink() => WaitForElement(_homeLink).Click();

        public void WaitForNewTab()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.WindowHandles.Count > 1);
        }
        public void SwitchToNewTab()
        {
            var originalWindow = Driver.CurrentWindowHandle;
            var newWindow = Driver.WindowHandles.Where(w => w != originalWindow).First();
            Driver.SwitchTo().Window(newWindow);
        }

        private readonly By _dynamicLink = By.Id("dynamicLink");

        public void ClickDynamicLink() => WaitForElement(_dynamicLink).Click();

        private readonly By _linkResponse = By.Id("linkResponse");

        public void ClickApiLink(string apiId)
        {
            var element = WaitForElement(By.Id(apiId));

            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform(); //scrolls to the element and clicks it

            element.Click();
            WaitForElement(_linkResponse);
        }

        public string GetApiResponse(string apiId)
        {
            var element = WaitForElement(By.Id(apiId));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);

            element.Click();
            return WaitForElement(_linkResponse).Text;  
        }

    }
}
