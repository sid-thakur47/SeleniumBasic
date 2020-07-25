using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumBasics.BrowserStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasics.BrowserStackTool
{
    [TestFixture("single", "chrome")]
    public class BrowserStackTest : BrowserStackNUnitTest
    {
        public BrowserStackTest(string profile, string environment) : base(profile, environment)
        {

        }
        [Test]
        public void SearchGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com/ncr");
            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("BrowserStack");
            query.Submit();
            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual("BrowserStack - Google Search", driver.Title);
        }
    }
}
