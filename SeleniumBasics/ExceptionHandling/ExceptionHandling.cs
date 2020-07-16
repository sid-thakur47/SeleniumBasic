using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

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

        [Test]
        public void TimeOutTest()
        {
            IWebElement finishElement = driver.FindElement(By.Id("finish"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));//wait for 2 sec
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("finish")));//wait until visibility of finish element
            }
            catch (TimeoutException exception)
            {
               Console.WriteLine("Exception: " + exception.Message);//if element is not visible  catch exception and print it
                Thread.Sleep(3000);
            }
            String finishText = finishElement.Text; //element is visible the get its text
            Assert.True(finishText.Contains("Hello World!"));//verify the text
        }

        [Test]
        public void NoSuchElementTest()
        { 
            driver.Url="http://the-internet.herokuapp.com/dynamic_loading/2";
            IWebElement startButton = driver.FindElement(By.XPath("//div[@id='start']//button"));
            startButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //wait unit element text is located at location and verify the text
            Assert.True(
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.Id("finish"), "Hello World!")),
                    "Couldn't verify 'Hello World!'");
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
