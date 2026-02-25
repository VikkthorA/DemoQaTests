using DemoQaTests.Base;
using OpenQA.Selenium;
using DemoQaTests.Pages;

public class Tests : BaseTest
{
    [Fact]
    public void Test1()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
        var textBoxTest = new TextBoxPage(Driver);
        textBoxTest.FillTextBoxes("John Doe", "ababa@abv.bg", "USA 41551 51515", "456 Elm St");

    }

    [Fact]
    public void CheckBox()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/checkbox");

        var checkboxPage = new CheckBoxPage(Driver);

        checkboxPage.ExpandAll();
        checkboxPage.ExpandNode(CheckboxNode.Desktop);
        checkboxPage.ClickNode(CheckboxNode.Notes);
        checkboxPage.ClickNode(CheckboxNode.Commands);

        checkboxPage.ClickNode(CheckboxNode.Notes);
        checkboxPage.ClickNode(CheckboxNode.Commands);
        checkboxPage.ClickNode(CheckboxNode.Desktop);

        checkboxPage.ExpandNode(CheckboxNode.Documents);
        checkboxPage.ExpandNode(CheckboxNode.Office);
        checkboxPage.ClickNode(CheckboxNode.Office);
        checkboxPage.ExpandNode(CheckboxNode.WorkSpace);
        checkboxPage.ClickNode(CheckboxNode.WorkSpace);

        checkboxPage.ExpandNode(CheckboxNode.Downloads);
        checkboxPage.ClickNode(CheckboxNode.Downloads);
    }

}
