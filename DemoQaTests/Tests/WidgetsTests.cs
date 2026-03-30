using DemoQaTests.Base;
using DemoQaTests.Widgets;

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

}