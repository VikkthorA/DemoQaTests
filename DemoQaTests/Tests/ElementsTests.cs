using DemoQaTests.Base;
using DemoQaTests.ElementsPages;
using DemoQaTests.Pages;


public class ElementsTests : BaseTest
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

    [Fact]
    public void WebTables()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/webtables");
        var webTablesPage = new WebTablesPage(Driver);
        webTablesPage.AddNewRecord("John", "Doe", "john@example.com", "30", "50000", "IT");
        webTablesPage.ClickEditButton("john@example.com");
        webTablesPage.EditRecord(age: "77");
        webTablesPage.ClickDeleteButton("alden@example.com");
        webTablesPage.SearchRecord("Cierra");
        webTablesPage.ClickDeleteButton("cierra@example.com");
        webTablesPage.SearchClear();    
        webTablesPage.SelectRowsPerPage("50");
    }


    [Fact]
    public void ButtonClicks()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/buttons");
        var buttonsPage = new ButtonsPage(Driver);
        buttonsPage.PerformDoubleClick();
        Assert.Equal("You have done a double click", buttonsPage.GetDoubleClickMessage());
        buttonsPage.PerformRightClick();
        Assert.Equal("You have done a right click", buttonsPage.GetRightClickMessage());
        buttonsPage.PerformClickMeButton();
        Assert.Equal("You have done a dynamic click", buttonsPage.GetDynamicClickMessage());

    }


}