using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DemoQaTests.ElementsPages
{
    public class WebTablesPage : BasePage
    {
        public WebTablesPage(IWebDriver driver) : base(driver) { }

        private readonly By _addButton = By.Id("addNewRecordButton");
        private readonly By _firstNameField = By.Id("firstName");
        private readonly By _lastNameField = By.Id("lastName");
        private readonly By _emailField = By.Id("userEmail");
        private readonly By _ageField = By.Id("age");
        private readonly By _salaryField = By.Id("salary");
        private readonly By _departmentField = By.Id("department");
        private readonly By _submitButton = By.Id("submit");

        public void AddNewRecord(string firstName, string lastName, string email, string age, string salary, string department)
        {
            WaitForElement(_addButton).Click();
            WaitForElement(_firstNameField).SendKeys(firstName);
            WaitForElement(_lastNameField).SendKeys(lastName);
            WaitForElement(_emailField).SendKeys(email);
            WaitForElement(_ageField).SendKeys(age);
            WaitForElement(_salaryField).SendKeys(salary);
            WaitForElement(_departmentField).SendKeys(department);
            WaitForElement(_submitButton).Click();
        }

        public void ClickEditButton(string email)
        {
            var editButton = By.XPath(
                $"//td[contains(text(), '{email}')]/ancestor::tr//span[@title='Edit']"
            );
            WaitForElement(editButton).Click();  
        }

        public void EditRecord(string firstName = null, string lastName = null, string email = null, string age = null, string salary = null, string department = null)
        {
            if (firstName != null)
            {
                var firstNameElement = WaitForElement(_firstNameField);
                firstNameElement.Clear(); 
                firstNameElement.SendKeys(firstName); 
            }

            if (lastName != null)
            {
                var lastNameElement = WaitForElement(_lastNameField);
                lastNameElement.Clear();
                lastNameElement.SendKeys(lastName);
            }

            if (email != null)
            {
                var emailElement = WaitForElement(_emailField);
                emailElement.Clear();
                emailElement.SendKeys(email);
            }
            if(age != null)
                {
                var ageElement = WaitForElement(_ageField);
                ageElement.Clear();
                ageElement.SendKeys(age);
            }
            if (salary != null)
            {
                var salaryElement = WaitForElement(_salaryField);
                salaryElement.Clear();
                salaryElement.SendKeys(salary);
            }
            if (department != null)
            {
                var departmentElement = WaitForElement(_departmentField);
                departmentElement.Clear();
                departmentElement.SendKeys(department);
            }

            WaitForElement(_submitButton).Click();
        }
        public void ClickDeleteButton(string email)
        {
            var deleteButton = By.XPath($"//td[contains(text(), '{email}')]/ancestor::tr//span[@title='Delete']");
            WaitForElement(deleteButton).Click();
        }

        private readonly By _searchBox = By.Id("searchBox");
        public void SearchRecord(string searchText)
        {
            var searchBox = WaitForElement(_searchBox);
            searchBox.Clear();
            WaitForElement(_searchBox).SendKeys(searchText);
        }
        public void SearchClear()
        {
            var searchBox = WaitForElement(_searchBox);
            searchBox.SendKeys(Keys.Control + "a");
            searchBox.SendKeys(Keys.Backspace);

        }

        private readonly By _rowsDropdown = By.CssSelector("select.form-control");
        public void SelectRowsPerPage(string rows)
        {
            var selectElement = new SelectElement(WaitForElement(_rowsDropdown));
            selectElement.SelectByValue(rows);
        }


    }
}