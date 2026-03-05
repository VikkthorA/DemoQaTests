using DemoQaTests.Base;
using DemoQaTests.ElementsPages;
using DemoQaTests.Pages;
using OpenQA.Selenium;
using System.Diagnostics;


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

    [Fact]
    public void LinksTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/links");
        var linksPage = new LinksPage(Driver);

        var allOriginalWindows = new List<string>(Driver.WindowHandles);
        var firstWindow = allOriginalWindows[0];

        linksPage.ClickHomeLink();
        linksPage.WaitForNewTab();
        linksPage.SwitchToNewTab();
        Driver.Close();
        Driver.SwitchTo().Window(firstWindow);

        linksPage.ClickDynamicLink();
        linksPage.WaitForNewTab();
        linksPage.SwitchToNewTab();
        Driver.Close();
        Driver.SwitchTo().Window(firstWindow);

        linksPage.ClickApiLink("created");
        Assert.Contains("201", linksPage.GetApiResponse("created"));

        linksPage.ClickApiLink("no-content");
        Assert.Contains("204", linksPage.GetApiResponse("no-content"));

        linksPage.ClickApiLink("moved");
        Assert.Contains("301", linksPage.GetApiResponse("moved"));

        linksPage.ClickApiLink("bad-request");
        Assert.Contains("400", linksPage.GetApiResponse("bad-request"));

        linksPage.ClickApiLink("unauthorized");
        Assert.Contains("401", linksPage.GetApiResponse("unauthorized"));

        linksPage.ClickApiLink("forbidden");
        Assert.Contains("403", linksPage.GetApiResponse("forbidden"));

        linksPage.ClickApiLink("invalid-url");
        Assert.Contains("404", linksPage.GetApiResponse("invalid-url"));

    }
    [Fact]
    public void BrokenLinksTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/broken");
        var brokenLinksPage = new BrokenLinks(Driver);
        brokenLinksPage.ValidateImages();
        brokenLinksPage.ValidateLinks();
    }
    [Fact]
    public void UploadDownloadFile()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/upload-download");
        var filesManagerPage = new FilesManagerPage(Driver);

        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); //the path to the user's folder
        string downloadsFolder = Path.Combine(userPath, "Downloads");
        string fileName = "sampleFile.jpeg"; 
        string fullPath = Path.Combine(downloadsFolder, fileName);

        filesManagerPage.ClickDownload();

        Assert.True(File.Exists(fullPath)); // Verify that the file was downloaded successfully

        filesManagerPage.UploadFile(fullPath);
        string resultText = filesManagerPage.GetUploadedFilePathText();
        Assert.Contains(fileName, resultText);
    }
    [Fact]
    public void DynamicPropertiesTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/dynamic-properties");
        var dynamicPage = new DynamicButton(Driver);

        Assert.True(dynamicPage.isVisiableAfterButtonDisplay());

        string finalColor = dynamicPage.GetColorChangeButtonColor();
        Assert.True(
         finalColor.StartsWith("rgb(220, 53, 69") ||
         finalColor.StartsWith("rgba(220, 53, 69"));


        Assert.True(dynamicPage.isButtonEnabled());
    }
}

