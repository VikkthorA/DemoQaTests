using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace DemoQaTests.Widgets
{
    public class AutoComplete : BasePage
    {
        public AutoComplete(IWebDriver driver) : base(driver) { }

        private readonly By _multipleInput = By.CssSelector("#autoCompleteMultipleContainer input");
        private readonly By _singleInput = By.CssSelector("#autoCompleteSingleContainer input");

        public void MultipleColorsInput(string color, int selectIndex = 0)
        {
            var input = Driver.FindElement(_multipleInput);
            input.Click();
            input.SendKeys(color);

            // first selected
            if (selectIndex == 0)
            {
                input.SendKeys(Keys.Enter);
                return;
            }

            //if u want to select other option, u need to send ArrowDown key n times, where n is the index of the option in the dropdown list (starting from 0)
            for (int i = 0; i < selectIndex; i++)
            {
                input.SendKeys(Keys.ArrowDown);
            }
            input.SendKeys(Keys.Enter);

        }
        public void RemoveColorTag(string color)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));

            var removeBtn = wait.Until(ExpectedConditions.ElementToBeClickable(
                By.XPath($"//div[contains(@class,'multi-value')]//div[text()='{color}']/following-sibling::div")
            ));

            removeBtn.Click();
        }

        public void SingleColorInput(string color)
        {
            var input = Driver.FindElement(_singleInput);
            input.Clear();
            input.SendKeys(color);
            input.SendKeys(Keys.Enter);
        }
    }
}
