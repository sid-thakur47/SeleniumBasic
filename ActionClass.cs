using System;

public class Class1
{
    IWebDriver driver = new ChromeDriver();

    [Test]
    public void MouseOverTest()
    {
        driver.Manage().Window.Maximize();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/validateCredentials";
        //Login
        driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
        Thread.Sleep(2000);

        driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
        Thread.Sleep(2000);

        driver.FindElement(By.Id("btnLogin")).Click();
        Thread.Sleep(2000);

        //Actions class
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

        driver.Quit();
    }

}
