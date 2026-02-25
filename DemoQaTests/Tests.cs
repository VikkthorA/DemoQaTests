using DemoQaTests.Base;
using DemoQaTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class Tests : BaseTest
{
    [Fact]
    public void TextBoxTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
        var textBoxTest = new TextBoxPage(Driver);
        textBoxTest.FillTextBoxes("John Doe", "ababa@abv.bg", "USA 41551 51515", "456 Elm St");

        Assert.Equal(textBoxTest.GetInputText(), textBoxTest.GetOutputText());
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

    [Fact]
    public void RadioButton()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/radio-button");
        var radioPage = new RadioButtonPage(Driver);
        radioPage.ClickYes();
        Assert.Equal("Yes", radioPage.GetSelectedOption());
        radioPage.ClickImpressive();
        Assert.Equal("Impressive", radioPage.GetSelectedOption());

    }

}
