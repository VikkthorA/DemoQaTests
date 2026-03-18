using DemoQaTests.Base;
using OpenQA.Selenium;


namespace DemoQaTests.AlertsAndFrames
{
    public class ModalsPage : BasePage
    {
        public ModalsPage(IWebDriver driver) : base(driver) { }

        private readonly By _smallModalButton = By.Id("showSmallModal");
        private readonly By _largeModalButton = By.Id("showLargeModal");

        private readonly By _smallModalTitle = By.Id("example-modal-sizes-title-sm");
        private readonly By _largeModalTitle = By.Id("example-modal-sizes-title-lg");

        private readonly By _smallModalBody = By.CssSelector(".modal-sm .modal-body");
        private readonly By _largeModalBody = By.CssSelector(".modal-lg .modal-body");

        private readonly By smallModalCloseButton = By.Id("closeSmallModal");
        private readonly By largeModalCloseButton = By.Id("closeLargeModal");

        public (string title, string bodyText) GetSmallModalContent()
        {
            Driver.FindElement(_smallModalButton).Click();
            string title = Driver.FindElement(_smallModalTitle).Text;
            string bodyText = Driver.FindElement(_smallModalBody).Text;
            Driver.FindElement(smallModalCloseButton).Click();
            return (title, bodyText);
        }
        public (string title, string bodyText) GetLargeModalContent()
        {
            Driver.FindElement(_largeModalButton).Click();
            string title = Driver.FindElement(_largeModalTitle).Text;
            string bodyText = Driver.FindElement(_largeModalBody).Text;
            Driver.FindElement(largeModalCloseButton).Click();
            return (title, bodyText);
        }
    }
}
