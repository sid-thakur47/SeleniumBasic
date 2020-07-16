using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumBasics.ExceptionHandling
{
    public class ExceptionHandling : Base
    { 

        [SetUp]
        public void SetUp()
        {
            Initialize();
            driver.Url="http://the-internet.herokuapp.com/dynamic_loading/1";
            IWebElement startButton = driver.FindElement(By.XPath("//div[@id='start']//button"));
            startButton.Click();
        }

        [Test]
        public void ElementNotVisisbleTest()
        {
            IWebElement finishElement = driver.FindElement(By.Id("finish"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("finish")));//wait until visibility of finish element
            string finishText = finishElement.Text;//after visibility of element get text of the element
            Assert.AreEqual(finishText, "Hello World!");//veri
            System.Console.WriteLine(finishText);
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
