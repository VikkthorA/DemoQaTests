using DemoQaTests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoQaTests.ElementsPages
{
    public class FilesManagerPage : BasePage
    {
        public FilesManagerPage(IWebDriver driver) : base(driver) { }


        private readonly By _downloadButton = By.Id("downloadButton");
        private readonly By _uploadFileInput = By.Id("uploadFile");
        private readonly By _uploadedFilePathResult = By.Id("uploadedFilePath");

        public void ClickDownload()
        {
            WaitForElement(_downloadButton).Click();
        }

        public void UploadFile(string filePath)
        {
            var uploadElement = WaitForElement(_uploadFileInput);
            uploadElement.SendKeys(filePath);
        }

        public string GetUploadedFilePathText()
        {
            return WaitForElement(_uploadedFilePathResult).Text;
        }
    }
}
