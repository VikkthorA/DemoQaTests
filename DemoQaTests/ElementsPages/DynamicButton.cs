using DemoQaTests.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace DemoQaTests.ElementsPages
{
    public class DynamicButton : BasePage
    {
        private readonly By _enableAfterButton = By.Id("enableAfter");
        private readonly By _colorChangeButton = By.Id("colorChange");
        private readonly By _visibleAfterButton = By.Id("visibleAfter");
        public DynamicButton(IWebDriver driver) : base(driver) { }

        public bool isVisiableAfterButtonDisplay()
        {
            return WaitForElement(_visibleAfterButton).Displayed;
        }

        public string GetColorChangeButtonColor()
        {
            
            var button = WaitForElement(_colorChangeButton);
            string intialColor = button.GetCssValue("color");

            Wait.Until(d => d.FindElement(_colorChangeButton).GetAttribute("class").Contains("text-danger"));
            return button.GetCssValue("color");
        }
        public bool isButtonEnabled()
        {
            var element = Wait.Until(ExpectedConditions.ElementToBeClickable(_enableAfterButton));
            return element.Enabled;
        }
    }
}
