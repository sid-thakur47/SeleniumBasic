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

        [Test]
        public void StaleElement()
        {
            driver.Url="http://the-internet.herokuapp.com/dynamic_controls";
            IWebElement checkBox = driver.FindElement(By.Id("checkbox"));
            IWebElement removeButton = driver.FindElement(By.XPath("//button[contains(text(),'Remove')]"));
            removeButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Assert.True(wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(checkBox)),//wait until element disappears
                    "Checkbox is still visible, but shouldn't be");
            IWebElement addButton = driver.FindElement(By.XPath("//button[contains(text(),'Add')]"));
            addButton.Click();//click on add button
            //verify the element
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("checkbox")));
            IWebElement checkbox = driver.FindElement(By.Id("checkbox"));
            checkbox.Click();
            Thread.Sleep(5000);
            IWebElement message = driver.FindElement(By.XPath("//p[@id='message']"));
            Assert.AreEqual(message.Text,"It's back!");
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
