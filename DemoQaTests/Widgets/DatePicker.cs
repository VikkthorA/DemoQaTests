using DemoQaTests.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace DemoQaTests.Widgets
{
    public class DatePicker : BasePage
    {
        public DatePicker(IWebDriver driver) : base(driver) { }

        private readonly By _datePickerMonthYearInput = By.Id("datePickerMonthYearInput");
        private readonly By _monthSelect = By.ClassName("react-datepicker__month-select");
        private readonly By _yearSelect = By.ClassName("react-datepicker__year-select");

        private readonly By _dateAndTimePickerInput = By.Id("dateAndTimePickerInput");
        private readonly By _dateAndTimePickerMonthReadView = By.ClassName("react-datepicker__month-read-view");
        private readonly By _yearTimePickerReadView = By.ClassName("react-datepicker__year-read-view");
        private readonly By _timePickerSelect = By.ClassName("react-datepicker__time-list-item");

        public void SetDate(string day, string month, string year)
        {
            Driver.FindElement(_datePickerMonthYearInput).Click();
            var monthSelect = new SelectElement(Driver.FindElement(_monthSelect));
            monthSelect.SelectByText(month);
            var yearSelect = new SelectElement(Driver.FindElement(_yearSelect));
            yearSelect.SelectByText(year);
            string dayXpath = $"//div[contains(@class, 'react-datepicker__day') and text()='{day}' and not(contains(@class, 'outside-month'))]";
            Driver.FindElement(By.XPath(dayXpath)).Click();
        }

        public void SetDateAndTime(string day, string month, string year, string time)
        {
            OpenCalendar();
            SelectMonthByClick(month); 
            SelectYearSmart(year);
            SelectDay(day);
            SelectTime(time);
        }
        public void SelectMonthByArrows(string day, string month, string year, string time)
        {
            OpenCalendar();
            SelectMonthByArrows(month);
            SelectYearSmart(year);
            SelectDay(day);
            SelectTime(time);
        }
        private void OpenCalendar()
        {
            Driver.FindElement(_dateAndTimePickerInput).Click();
        }

        private void SelectMonthByClick(string month)
        {
            Driver.FindElement(_dateAndTimePickerMonthReadView).Click();
            string xpath = $"//div[contains(@class, 'react-datepicker__month-option') and text()='{month}']";
            Driver.FindElement(By.XPath(xpath)).Click();
        }

        private void SelectYearSmart(string year)
        {
            Driver.FindElement(_yearTimePickerReadView).Click();
            int targetYearInt = int.Parse(year);
            bool yearFound = false;

            while (!yearFound)
            {
                try
                {
                    var yearOption = Driver.FindElement(By.XPath($"//div[contains(@class, 'react-datepicker__year-option') and text()='{year}']"));
                    yearOption.Click();
                    yearFound = true;
                }
                catch (NoSuchElementException)
                {
                    var yearOptions = Driver.FindElements(By.ClassName("react-datepicker__year-option"));

                    string rawYearText = yearOptions[1].Text.Replace("✓", "").Trim();
                    int visibleYear = int.Parse(rawYearText); 

                    if (targetYearInt < visibleYear)
                        Driver.FindElement(By.ClassName("react-datepicker__navigation--years-previous")).Click();
                    else
                        Driver.FindElement(By.ClassName("react-datepicker__navigation--years-upcoming")).Click();
                }
            }
        }

        private void SelectDay(string day)
        {
            string dayXpath = $"//div[contains(@class, 'react-datepicker__day') and text()='{day}' and not(contains(@class, 'outside-month'))]";
            Driver.FindElement(By.XPath(dayXpath)).Click();
        }

        private void SelectTime(string time)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_timePickerSelect));
            var timeOptions = Driver.FindElements(_timePickerSelect);
            foreach (var option in timeOptions)
            {
                if (option.Text.Equals(time, StringComparison.OrdinalIgnoreCase))
                {
                    option.Click();
                    break;
                }
            }
        }

        public void SelectMonthByArrows(string targetMonth)
        {
            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int targetIndex = months.IndexOf(targetMonth);
            bool monthFound = false;

            while (!monthFound)
            {
                string currentMonthText = Driver.FindElement(_dateAndTimePickerMonthReadView).Text;
                int currentIndex = months.IndexOf(currentMonthText);

                if (currentIndex == targetIndex) monthFound = true;
                else if (targetIndex < currentIndex)
                    Driver.FindElement(By.ClassName("react-datepicker__navigation--previous")).Click();
                else
                    Driver.FindElement(By.ClassName("react-datepicker__navigation--next")).Click();
            }
        }
    }
}