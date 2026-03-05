using DemoQaTests.Base;
using OpenQA.Selenium;
using System.Diagnostics;


namespace DemoQaTests.ElementsPages
{
    public class BrokenLinks : BasePage
    {
        public BrokenLinks(IWebDriver driver) : base(driver) { }

        private readonly By _headerImgage = By.XPath("//img[contains(@src, 'Toolsqa-DZdwt2ul.jpg')]");
        private readonly By _validImage = By.XPath("//img[contains(@src, 'Toolsqa.jpg')]");
        private readonly By _brokenImage = By.XPath("//img[contains(@src, 'Toolsqa_1.jpg')]");

        public bool isImageValid(By imageLocator)
        {
            var imageElement = WaitForElement(imageLocator);
            long width = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].naturalWidth;", imageElement);

            return width > 0;  // 0 = broken

        }

        public void ValidateImages()
        {
           
            Assert.False(isImageValid(_validImage)); // false here bcz both of them doesnt work properly rn(bcz of the site)
            Assert.False(isImageValid(_brokenImage));
            Assert.True(isImageValid(_headerImgage)); //true here bcz header img is working properly
        }

        private readonly By _validLink = By.LinkText("Click Here for Valid Link");
        private readonly By _brokenLink = By.LinkText("Click Here for Broken Link");

        public bool isLinkValid(By linkLocator)
        {
            var linkElement = WaitForElement(linkLocator);
            var url = linkElement.GetAttribute("href");

            using var httpClient = new HttpClient();
            try
            {
                var response = httpClient.GetAsync(url).Result;

                return response.IsSuccessStatusCode; //  status code is 200-299
            }
            catch (Exception)
            {
                return false; //  status code is 400-599
            }
        }
        public void ValidateLinks()
        { 
            Assert.True(isLinkValid(_validLink)); // return 200 - true
            Assert.False(isLinkValid(_brokenLink)); // return 500 - false
        }

    }
}