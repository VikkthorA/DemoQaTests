using DemoQaTests.Base;
using OpenQA.Selenium;

namespace DemoQaTests.Pages
{
    public class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver) : base(driver) { }

        private readonly By _usernameField = By.Id("userName");
        private readonly By _emailField = By.Id("userEmail");
        private readonly By _currentAddressField = By.Id("currentAddress");
        private readonly By _permanentAddressField = By.Id("permanentAddress");
        private readonly By _submitButton = By.Id("submit");

        public void FillTextBoxes(string username, string email, string currentAddress, string permanentAddress)
        {
            WaitForElement(_usernameField).SendKeys(username);
            WaitForElement(_emailField).SendKeys(email);
            WaitForElement(_currentAddressField).SendKeys(currentAddress);
            WaitForElement(_permanentAddressField).SendKeys(permanentAddress);
            WaitForElement(_submitButton).Click();
        }

            public string GetOutputText()
            {
                var outputElement = WaitForElement(By.Id("output"));
                return outputElement.Text;
            }
            public string GetInputText()
            {
                var username = WaitForElement(_usernameField).GetAttribute("value");
                var email = WaitForElement(_emailField).GetAttribute("value");
                var currentAddress = WaitForElement(_currentAddressField).GetAttribute("value");
                var permanentAddress = WaitForElement(_permanentAddressField).GetAttribute("value");
                return $"Name:{username}\r\nEmail:{email}\r\nCurrent Address :{currentAddress}\r\nPermananet Address :{permanentAddress}";
            }
    }
}