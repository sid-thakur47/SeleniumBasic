using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasics.BrokenLinks
{
    public class BrokenLink : Base
    {
        [Test]
        public void BrokenLinks()
        {

            Initialize();//browser initialization
            driver.Url = "http://google.com/";//open  URL
            Thread.Sleep(5000);
            IList<IWebElement> list = driver.FindElements(By.TagName("a"));//get all elements with a tag
            for (int i = 0; i < list.Count; i++)
            {
                String url = list.ElementAt(i).GetAttribute("href"); // links of page

                if (url == null)
                {
                    Console.WriteLine(url + "   url is not configured");
                    continue;
                }
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url); //create httprequest for url
                try
                {
                    var response = (HttpWebResponse)hwr.GetResponse(); //get response of Url
                    int responsecode = (int)response.StatusCode; //get status code

                    if (responsecode >= 400)
                    {
                        Console.WriteLine(url + "is broken link");// status code more than 400 is broken link
                    }
                    else
                    {
                        Console.WriteLine(url + "is safe link");
                    }
                }
                catch (WebException e)
                {
                    var errorRosponse = (HttpWebResponse)e.Response;
                    int responsecode = (int)errorRosponse.StatusCode;
                    Console.WriteLine($"URL: {url.ToString()}  Url is :{"It is a broken link"}   status is :{responsecode}");
                }
            }
        }
    }
}