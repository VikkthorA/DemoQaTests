using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoQaTests.Forms
{
    public class PracticeFormPage : BasePage
    {
        public PracticeFormPage(IWebDriver driver) : base(driver) { }

        private readonly By _firstNameInput = By.Id("firstName");
        private readonly By _lastNameInput = By.Id("lastName");
        private readonly By _emailInput = By.Id("userEmail");
        private readonly By _genderLabel = By.XPath("//label[contains(@for,'gender-radio')]");
        private readonly By _mobileInput = By.Id("userNumber");
        private readonly By _dateOfBirth = By.Id("dateOfBirthInput");
        private readonly By _subjects = By.CssSelector("#subjectsInput");
        private readonly By _hobbiesLabels = By.XPath("//label[contains(@for, 'hobbies-checkbox')]");
        private readonly By _uploadPicture = By.Id("uploadPicture");
        private readonly By _currentAdress = By.Id("currentAddress");
        private readonly By _state = By.CssSelector("#state input");
        private readonly By _city = By.CssSelector("#city input");
        private readonly By _submitButton = By.Id("submit");

        public void SelectGender(string genderName)
        {
            var gender = Driver.FindElements(_genderLabel);
            var target = gender.FirstOrDefault(g => g.Text == genderName);
            target?.Click();
        }
        public void SelectHobbies(string hobbyName)
        {
            var hobby = Driver.FindElements(_hobbiesLabels);
            var target = hobby.FirstOrDefault(h => h.Text == hobbyName);
            target?.Click();
        }
        public void SetDateOfBirth(string day, string month, string year)
        {
            Driver.FindElement(_dateOfBirth).Click();

            var monthSelect = new SelectElement(Driver.FindElement(By.ClassName("react-datepicker__month-select")));
            monthSelect.SelectByText(month);

            var yearSelect = new SelectElement(Driver.FindElement(By.ClassName("react-datepicker__year-select")));
            yearSelect.SelectByText(year);

            string dayXpath = $"//div[contains(@class, 'react-datepicker__day') and text()='{day}' and not(contains(@class, 'outside-month'))]";

            Driver.FindElement(By.XPath(dayXpath)).Click();
        }
        public void UploadFile(string filePath)
        {
            var uploadElement = WaitForElement(_uploadPicture);
            uploadElement.SendKeys(filePath);
        }
        public void SelectStateAndCity(string state, string city)
        {
            var stateField = Driver.FindElement(_state);
            stateField.Click();
            stateField.SendKeys(state);
            stateField.SendKeys(Keys.Enter);

            var cityInput = Wait.Until(ExpectedConditions.ElementToBeClickable(_city));
            cityInput.Click();
            cityInput.SendKeys(city);
            cityInput.SendKeys(Keys.Enter);

        }
        public void SubjectSelect(string subject)
        {
            var subjectField = Driver.FindElement(_subjects);
            subjectField.SendKeys(subject);
            subjectField.SendKeys(Keys.Enter);
        }

        public void FillEntireForm(string fName, string lName, string email, string gender, string mobile, string day, string month, string year, string subject, string hobby, string filePath, string address, string state, string city)
        {
            Driver.FindElement(_firstNameInput).SendKeys(fName);
            Driver.FindElement(_lastNameInput).SendKeys(lName);
            Driver.FindElement(_emailInput).SendKeys(email);
            SelectGender(gender);
            MobileField(mobile);
            SetDateOfBirth(day, month, year);
            SubjectSelect(subject);
            SelectHobbies(hobby);
            UploadFile(filePath);
            CurrentAdress(address);
            ScrollToElement(_state);
            SelectStateAndCity(state, city);
            SubmitButton();
        }
        public Dictionary<string, string> GetResultsAsDictionary()
        {
           var results = new Dictionary<string, string>();

           var rows = Driver.FindElements(By.CssSelector(".table-responsive tbody tr"));
            foreach (var row in rows)
            {
                var cells = row.FindElements(By.TagName("td"));
                if (cells.Count == 2)
                {
                    string key = cells[0].Text; 
                    string value = cells[1].Text;
                    results[key] = value;
                }
            }
            return results;
        }
        public bool IsMobileFieldInvalid()
        {
            var mobileElement = Driver.FindElement(_mobileInput);
            string className = mobileElement.GetAttribute("class");
            return className.Contains("is-invalid"); 
        }
        public void MobileField(string mobile)
        {
           var mobileNum = Driver.FindElement(_mobileInput);
           mobileNum.SendKeys(mobile);
        }
        public void SubmitButton() => Driver.FindElement(_submitButton).Click();
        public void CurrentAdress(string adress)
        {
            var adressCurrent = Driver.FindElement(_currentAdress);
            adressCurrent.SendKeys(adress);
        }

    }
}