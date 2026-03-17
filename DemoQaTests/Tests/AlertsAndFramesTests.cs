using DemoQaTests.Base;
using DemoQaTests.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


public class AlertsAndFramesTests : BaseTest
{
    [Fact]
    public void NewWindows()
    {
        var browserWindowsPage = new BrowserWindowsPage(Driver);
        
        Driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
        var newTabText = browserWindowsPage.GetTextFromNewTab();
        var newWindowText = browserWindowsPage.GetTextFromNewTab();
        browserWindowsPage.OpenAndCloseNewWindowMessage();
        Assert.Equal("This is a sample page", newWindowText);
        Assert.Equal("This is a sample page", newTabText);
    }

}