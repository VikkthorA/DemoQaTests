using DemoQaTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQaTests.Pages
{
    public class RadioButtonPage : BasePage
    {
        public RadioButtonPage(IWebDriver driver) : base(driver) { }

        private readonly By _yesRadioButton = By.Id("yesRadio");
        private readonly By _impressiveRadioButton = By.Id("impressiveRadio");
        private readonly By _textSuccess = By.ClassName("text-success");

        public void ClickYes() => WaitForElement(_yesRadioButton).Click();
        public void ClickImpressive() => WaitForElement(_impressiveRadioButton).Click();
        public string GetSelectedOption()
        {
            return WaitForElement(_textSuccess).Text;
        }
    }
}
