using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DemoQaTests.ElementsPages
{
    public class ButtonsPage : BasePage
    {
        private readonly By _doubleClickBtn = By.Id("doubleClickBtn");
        private readonly By _rightClickBtn = By.Id("rightClickBtn");
        private readonly By _clickMeBtn = By.XPath("//button[text()='Click Me']");
        private readonly By _doubleClickMessage = By.Id("doubleClickMessage");
        private readonly By _rightClickMessage = By.Id("rightClickMessage");
        private readonly By _dynamicClickMessage = By.Id("dynamicClickMessage");


        public ButtonsPage(IWebDriver driver) : base(driver)
        {
        }

        public void DoubleClickButton() => WaitForElement(_doubleClickBtn);
        public void RightClickButton() => WaitForElement(_rightClickBtn);
        public void ClickMeButton() => WaitForElement(_clickMeBtn);

        public string GetDoubleClickMessage() => WaitForElement(_doubleClickMessage).Text;
        public string GetRightClickMessage() => WaitForElement(_rightClickMessage).Text;
        public string GetDynamicClickMessage() => WaitForElement(_dynamicClickMessage).Text;

        public void PerformDoubleClick()
        {
            var element = WaitForElement(_doubleClickBtn);
            new Actions(Driver).
                DoubleClick(element).
                Perform();
        }
        public void PerformRightClick()
        {
            var element = WaitForElement(_rightClickBtn);
            new Actions(Driver).
                ContextClick(element).
                Perform();

        }
        public void PerformClickMeButton()
        {
            WaitForElement(_clickMeBtn).Click();
        }
    }
}
