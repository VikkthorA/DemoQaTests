using DemoQaTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQaTests.AlertsAndFrames
{
    public class NestedFramesPage : BasePage
    {
        public NestedFramesPage(IWebDriver driver) : base(driver) { }

        private readonly By _parentFrame = By.Id("frame1");
        private readonly By _childFrame = By.CssSelector("iframe[srcdoc]");

        public string GetTextFromParent()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(_parentFrame));
            string text = Driver.FindElement(By.TagName("body")).Text;
            Driver.SwitchTo().DefaultContent();
            return text;
        }
        public string GetTextFromChild()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(_parentFrame));
            Driver.SwitchTo().Frame(Driver.FindElement(_childFrame));
            string text = Driver.FindElement(By.TagName("body")).Text;
            Driver.SwitchTo().DefaultContent();
            return text;
        }
    }
}