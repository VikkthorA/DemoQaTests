using DemoQaTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQaTests.Widgets
{
    public class AccordianPage : BasePage
    {
        public AccordianPage(IWebDriver driver) : base(driver) { }

        private IList<IWebElement> AccordionButtons
        {
            get
            {
                return Driver.FindElements(By.CssSelector("button.accordion-button"));
            }
        }

        public int ButtonCount => AccordionButtons.Count;

        public void ClickButton(int index)
        {
            if (AccordionButtons[index].GetAttribute("aria-expanded") == "false")
            {
                IWebElement button = AccordionButtons[index];

                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", button); //js scroll to elemnt
                
                button.Click();
            }
        }

        public bool IsExpanded(int index)
        {
            return AccordionButtons[index].GetAttribute("aria-expanded") == "true";
        }
    }
}
