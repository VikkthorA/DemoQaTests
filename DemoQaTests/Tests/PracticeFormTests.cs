using DemoQaTests.Base;
using DemoQaTests.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


public class PracticeFormTest : BaseTest
{
    [Fact]
    public void PracticeFormPositiveTest()
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        var practiceFormPage = new PracticeFormPage(Driver);
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); //the path to the user's folder
        string downloadsFolder = Path.Combine(userPath, "Downloads");
        string fileName = "sampleFile.jpeg";
        string fullPath = Path.Combine(downloadsFolder, fileName);
        practiceFormPage.FillEntireForm(
            "Ivan", "Ivanov", "ivan@test.bg", "Male", "0888123456",
            "19", "June", "2004", "English", "Sports", fullPath, "Sofia, Bulgaria",
            "NCR", "Delhi"
        );

        var results = practiceFormPage.GetResultsAsDictionary();
        Assert.Equal("Ivan Ivanov", results["Student Name"]);
        Assert.Equal("ivan@test.bg", results["Student Email"]);
        Assert.Equal("Male", results["Gender"]);
        Assert.Equal("0888123456", results["Mobile"]);
        Assert.Equal("19 June,2004", results["Date of Birth"]);
        Assert.Equal("English", results["Subjects"]);
        Assert.Equal("Sports", results["Hobbies"]);
        Assert.Equal("sampleFile.jpeg", results["Picture"]);
        Assert.Equal("Sofia, Bulgaria", results["Address"]);
        Assert.Equal("NCR Delhi", results["State and City"]);
    }


    [Theory] // BVA DDT for phone num field
    [InlineData("123456789")]    
    [InlineData("abcdefghij")]   
    [InlineData("")]             
    public void MobileNumber_InvalidInput(string invalidMobile) 
    {
        Driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        var practiceFormPage = new PracticeFormPage(Driver);

        var mobileField = Driver.FindElement(By.Id("userNumber"));
        mobileField.SendKeys(invalidMobile);

        Actions actions = new Actions(Driver);
        actions.MoveToElement(Driver.FindElement(By.Id("submit")))
               .Click()
               .Perform();
        Assert.False(practiceFormPage.IsMobileFieldInvalid());
    }
}