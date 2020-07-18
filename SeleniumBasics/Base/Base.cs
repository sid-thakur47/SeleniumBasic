using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasics
{
    public class Base
    {
        public static IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }
    }
}
