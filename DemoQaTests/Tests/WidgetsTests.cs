using DemoQaTests.Base;
using DemoQaTests.Widgets;
using OpenQA.Selenium;

public class WidgetsTests : BaseTest
{
    [Fact]
    public void AccordianTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/accordian");
        var accordianPage = new AccordianPage(Driver);

        int totalButtons = accordianPage.ButtonCount;

        for (int i = 0; i < totalButtons; i++)
        {
            accordianPage.ClickButton(i);
            Assert.True(accordianPage.IsExpanded(i));
        }
    }

    [Fact]
    public void TestColorAutocomplete()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/auto-complete");
        var autoCompletePage = new AutoComplete(Driver);

        autoCompletePage.MultipleColorsInput("R");  // selectIndex=0 (default)

        autoCompletePage.MultipleColorsInput("Y");  // ArrowDown x2

        autoCompletePage.MultipleColorsInput("B", 2); //blue

        autoCompletePage.RemoveColorTag("Blue");
        autoCompletePage.RemoveColorTag("Yellow");

        autoCompletePage.MultipleColorsInput("Purple");

        autoCompletePage.SingleColorInput("Red");
        autoCompletePage.SingleColorInput("Green");

    }

    [Fact]
    public void TestDatePicker()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/date-picker");
        var datePickerPage = new DatePicker(Driver);
        datePickerPage.SetDate("15", "March", "1980");


        datePickerPage.SelectMonthByArrows("10", "March", "2025", "22:45");

        datePickerPage.SetDateAndTime("10", "December", "2035", "22:45");

        datePickerPage.SetDateAndTime("10", "December", "2025", "22:45");
    }
    [Fact]
    public void TestSlider()
    {
    Driver.Navigate().GoToUrl("https://demoqa.com/slider");
        var sliderPage = new SliderPage(Driver);

    sliderPage.MoveSliderByOffset(120);

    string actualSliderValue = sliderPage.GetSliderAttributeValue();

    string boxValue = sliderPage.GetValueFromBox();

    Assert.Equal(actualSliderValue, boxValue);    
    }

    [Fact]
    public void ProgressBar_ShouldReach100Percent_AndShowResetButton()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/progress-bar");

        var progressBarPage = new ProgressBarPage(Driver);

        progressBarPage.ClickStart();

        bool isResetDisplayed = progressBarPage.WaitForResetButton();

        Assert.True(isResetDisplayed);

        string finalValue = progressBarPage.GetProgressBarValue();
        Assert.Equal("100%", finalValue);
    }
}