using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasics.ActionClass
{
   public class ActionClass
    {
        public 
        Actions action; 
        IWebDriver driver = new ChromeDriver();

        [OneTimeSetUp]
        public void SetUp() 
        {
            action = new Actions(driver);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void MouseOverTest()
        {
            driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/validateCredentials";
            //Login
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(2000);
            Actions action = new Actions(driver);
            IWebElement admin = driver.FindElement(By.XPath("//b[contains(text(),'Admin')]"));
            Thread.Sleep(2000);
            IWebElement usermanagement = driver.FindElement(By.XPath("//a[contains(text(),'User Management')]"));
            Thread.Sleep(2000);
            IWebElement user = driver.FindElement(By.XPath("//a[contains(text(),'Users')]"));
            Thread.Sleep(2000);
            action.MoveToElement(admin).Build().Perform(); //mouse move from one place to another
            Thread.Sleep(2000);
            action.MoveToElement(usermanagement).Build().Perform();//Build and perform used in actions class to perfrom task
            Thread.Sleep(2000);
            action.MoveToElement(user).Click().Build().Perform();
            Thread.Sleep(2000);
        }

        [Test]
        public void DragAndDropTest()
        {
            driver.Url="http://www.dhtmlgoodies.com/submitted-scripts/i-google-like-drag-drop/index.html"; //get url
            Thread.Sleep(1000);
            IWebElement element1 = driver.FindElement(By.XPath("//h1[.='Block 1']"));//find elements
            Thread.Sleep(1000);
            IWebElement element2 = driver.FindElement(By.XPath("//h1[.='Block 2']"));
            Thread.Sleep(1000);
            action.DragAndDrop(element2, element1).Build().Perform();//drag element 2 to element 1
            Thread.Sleep(5000);
        }

        [Test]
        public void MouseClickTest() 
        {
             driver.Url="https://www.google.com";//get url
            Thread.Sleep(1000);
            IWebElement imLucky = driver.FindElement(By.XPath("//div[@class='FPdoLc tfB0Bf']//input[@class='RNmpXc']"));
            Actions action = new Actions(driver);
            Thread.Sleep(1000);
            action.MoveToElement(imLucky).Perform();//move element at particular element
            Thread.Sleep(1000);
            imLucky.Click();//click on element
            Thread.Sleep(1000);
        }

        [Test]
        public void RightClick()
        {
            driver.Url="http://swisnl.github.io/jQuery-contextMenu/demo.html";//get url
            Thread.Sleep(5000);
            IWebElement context = driver.FindElement(By.XPath("//span[@class='context-menu-one btn btn-neutral']"));
            Thread.Sleep(5000);
            action.ContextClick(context).Perform();//right click on element
        }
        [Test]
        public void SliderTest()
        {
            driver.Url = "http://the-internet.herokuapp.com/horizontal_slider";//get url
            Thread.Sleep(1000);
            IWebElement slider = driver.FindElement(By.XPath("//div[@class='sliderContainer']//input"));
            Thread.Sleep(1000);
            action.MoveToElement(slider).DragAndDropToOffset(slider, 200, 0).Build().Perform();
            Thread.Sleep(2000);
        }

        [Test]
        public void SendKeysTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://www.browserstack.com/automate";
            Thread.Sleep(2000);
            action.SendKeys(driver.FindElement(By.XPath("//a[@class='btn-primary btn-lg col-md-3']")), Keys.Enter).Build().Perform();
            //here user will send key values like enter to web elements on click botton

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            driver.Quit();
        }
    }
}
