using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ProgressBarPage : BasePage
{
    public ProgressBarPage(IWebDriver driver) : base(driver) { }

    private readonly By _startStopButton = By.Id("startStopButton");
    private readonly By _progressBar = By.CssSelector("div[role='progressbar']");
    private readonly By _resetButton = By.Id("resetButton");

    public void ClickStart() => Driver.FindElement(_startStopButton).Click();

    //most basic way to wait for the progress bar to reach 100% is to wait for the reset button to be displayed, as it only appears after the progress bar is full
    public bool WaitForResetButton()
    {
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        try
        {
            return wait.Until(d => d.FindElement(_resetButton).Displayed);
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
    public string GetProgressBarValue()
    {
        return Driver.FindElement(_progressBar).Text;
    }
}