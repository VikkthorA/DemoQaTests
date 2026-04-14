using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

public class SliderPage : BasePage
{
    public SliderPage(IWebDriver driver) : base(driver) { }

    private readonly By _sliderPointer = By.CssSelector("input[type='range']");
    private readonly By _sliderValueBox = By.Id("sliderValue"); 

    public void MoveSliderByOffset(int offsetX)
    {
        var slider = Driver.FindElement(_sliderPointer);
        Actions actions = new Actions(Driver);

        actions.DragAndDropToOffset(slider, offsetX, 0).Perform();
    }

    public string GetSliderAttributeValue()
    {
        return Driver.FindElement(_sliderPointer).GetAttribute("value");
    }

    public string GetValueFromBox()
    {
        return Driver.FindElement(_sliderValueBox).GetAttribute("value");
    }
}