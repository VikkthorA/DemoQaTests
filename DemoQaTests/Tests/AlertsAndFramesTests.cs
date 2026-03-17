using DemoQaTests.AlertsAndFrames;
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

    [Fact]
    public void AlertTest()
    {
        var alertsPage = new AlertsPage(Driver);
        Driver.Navigate().GoToUrl("https://demoqa.com/alerts");

        string alertText = alertsPage.ClickAllertButton();
        Assert.Equal("You clicked a button", alertText);

        string alertTextAfter5Seconds = alertsPage.ClickTimerAlertButton();
        Assert.Equal("This alert appeared after 5 seconds", alertTextAfter5Seconds);

        string alertTextConfirm = alertsPage.ClickConfirmButton(true);
        Assert.Equal("Do you confirm action?", alertTextConfirm);

        string resultTextAccept = alertsPage.GetConfirmResultText(); //accept
        Assert.Contains("Ok", resultTextAccept);

        string alertTextDismiss = alertsPage.ClickConfirmButton(false); // Dismiss
        string resultTextDismiss = alertsPage.GetConfirmResultText();
        Assert.Contains("Cancel", resultTextDismiss);


        string promptAlertText = alertsPage.ClickPromptButton("Test input");
        Assert.Equal("Please enter your name", promptAlertText); 

        string promptResultText = alertsPage.GetPromptResult();  
        Assert.Contains("Test input", promptResultText);


    }
}