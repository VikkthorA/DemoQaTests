using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class BrowserWindowsPage : BasePage
{
    public BrowserWindowsPage(IWebDriver driver) : base(driver) { }

    private readonly By _newTabButton = By.Id("tabButton");
    private readonly By _newWindowButton = By.Id("windowButton");
    private readonly By _newWindowMessageButton = By.Id("messageWindowButton");

    public string GetTextFromNewTab() // works as well for new window, because the content is the same
    {
        Driver.FindElement(_newTabButton).Click();
        Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        string text = Driver.FindElement(By.Id("sampleHeading")).Text;
        Driver.Close();
        Driver.SwitchTo().Window(Driver.WindowHandles.First());
        return text;
    }

    public void OpenAndCloseNewWindowMessage()
    {
        string originalWindow = Driver.CurrentWindowHandle;

        Driver.FindElement(_newWindowMessageButton).Click();

        var newWindow = Driver.WindowHandles.Last();

        Driver.SwitchTo().Window(newWindow);
        Driver.Close();
        Driver.SwitchTo().Window(originalWindow);
    }
}
