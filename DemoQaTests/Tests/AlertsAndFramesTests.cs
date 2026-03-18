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

    [Fact]
    public void FramesTest()
    {
        var framesPage = new FramesPage(Driver);
        Driver.Navigate().GoToUrl("https://demoqa.com/frames");
        string frame1Text = framesPage.GetFrame1HeadingText();
        string frame2Text = framesPage.GetTextFromFrame2();
        Assert.Equal("This is a sample page", frame1Text);
        Assert.Equal("This is a sample page", frame2Text);
    }

    [Fact]
    public void NestedFramesTest()
    {
        var nestedFramesPage = new NestedFramesPage(Driver);
        Driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
        string parentFrameText = nestedFramesPage.GetTextFromParent();
        string childFrameText = nestedFramesPage.GetTextFromChild();
        Assert.Equal("Parent frame", parentFrameText);
        Assert.Equal("Child Iframe", childFrameText);
    }

    [Fact]
    public void ModalDialogsTest()
    {
        var modalsPage = new ModalsPage(Driver);
        Driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
        var (smallModalTitle, smallModalBody) = modalsPage.GetSmallModalContent();
        Assert.Equal("Small Modal", smallModalTitle);
        Assert.Equal("This is a small modal. It has very less content", smallModalBody);
        var (largeModalTitle, largeModalBody) = modalsPage.GetLargeModalContent();
        Assert.Equal("Large Modal", largeModalTitle);
        Assert.Equal("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", largeModalBody);
    }
}
