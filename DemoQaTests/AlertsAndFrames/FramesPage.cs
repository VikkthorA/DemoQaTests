using DemoQaTests.Base;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using OpenQA.Selenium;

namespace DemoQaTests.AlertsAndFrames
{
    public class FramesPage : BasePage
    {
        public FramesPage(IWebDriver driver) : base(driver) { }

        private readonly By _frame1 = By.Id("frame1");
        private readonly By _frame2 = By.Id("frame2");

        private readonly By _sampleHeading = By.Id("sampleHeading");

        public string GetFrame1HeadingText()
        {
            IWebElement frameElement = Driver.FindElement(_frame1);
            Driver.SwitchTo().Frame(frameElement);

            string headingText = Driver.FindElement(_sampleHeading).Text;
            Driver.SwitchTo().DefaultContent();

            return headingText;
        }     
        
        public string GetTextFromFrame2()
        {
            IWebElement frameElement = Driver.FindElement(_frame2);
            Driver.SwitchTo().Frame(frameElement);

            string headingText = Driver.FindElement(_sampleHeading).Text;
            Driver.SwitchTo().DefaultContent();

            return headingText;
        }
    }
}
