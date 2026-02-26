using DemoQaTests.Base;
using OpenQA.Selenium;

namespace DemoQaTests.Pages
{
    public class CheckBoxPage : BasePage
    {
        private readonly By _homeExpand = By.CssSelector("span.rc-tree-switcher.rc-tree-switcher_close");

        public CheckBoxPage(IWebDriver driver) : base(driver) { }

        public void ExpandAll() => WaitForElement(_homeExpand).Click();

        private string ToDisplayName(CheckboxNode node) => node switch
        {
            CheckboxNode.WordFile => "Word File.doc",
            CheckboxNode.ExcelFile => "Excel File.doc",
            _ => node.ToString()
        };

        public void ClickNode(CheckboxNode node)
        {
            string name = ToDisplayName(node);
            var locator = By.CssSelector($"span[aria-label='Select {name}']");
            WaitForElement(locator).Click();
        }

        public void ExpandNode(CheckboxNode node)
        {
            string name = ToDisplayName(node);
            var locator = By.XPath(
                $"//span[@aria-label='Select {name}']" +
                "/preceding-sibling::span[contains(@class,'rc-tree-switcher_close')]"
            );
            var elements = Driver.FindElements(locator);
            if (elements.Count > 0)
                elements[0].Click();


        }
    }
}