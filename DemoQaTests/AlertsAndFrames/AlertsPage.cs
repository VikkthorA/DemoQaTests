using DemoQaTests.Base;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQaTests.AlertsAndFrames
{
    public class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver) : base(driver) { }

        private readonly By _alertButton = By.Id("alertButton");
        private readonly By _timerAlertButton = By.Id("timerAlertButton");
        private readonly By _confirmButton = By.Id("confirmButton");
        private readonly By _confirmResult = By.Id("confirmResult");
        private readonly By _promptButton = By.Id("promtButton");
        private readonly By _promptResult = By.Id("promptResult");

        public string ClickAllertButton()
        {
            Driver.FindElement(_alertButton).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();
            return text;
        }
        public string ClickTimerAlertButton()
        {
            Driver.FindElement(_timerAlertButton).Click();
            IAlert alert = Wait.Until(ExpectedConditions.AlertIsPresent());
            string text = alert.Text;
            alert.Accept();
            return text;
        }
        public string ClickConfirmButton(bool accept)
        {
            Driver.FindElement(_confirmButton).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string text = alert.Text;

            if (accept)
                alert.Accept();
            else
                alert.Dismiss();

            return text;
        }
        public string GetConfirmResultText() => Driver.FindElement(_confirmResult).Text;

        public string ClickPromptButton(string input)
        {
            Driver.FindElement(_promptButton).Click();
            IAlert alert = Driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.SendKeys(input);
            alert.Accept();
            return text;
        }
        public string GetPromptResult() => Driver.FindElement(_promptResult).Text;

    }
}
