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
}