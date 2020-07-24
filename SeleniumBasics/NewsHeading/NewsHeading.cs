using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumBasics.NewsHeading
{
  public class NewsHeading: Base
    {
        [Test]
        public void NewsHeadingTest()
        {
            Initialize();
            driver.Url = "https://news.ycombinator.com/";
            Thread.Sleep(2000);
            IList<IWebElement> header = driver.FindElements(By.ClassName("storylink"));
            List<string> mylist = new List<string>();
            foreach (var items in header)
            {
                string text = items.Text;
                mylist.Add(text);
                Console.WriteLine(text);
            }


            IList<IWebElement> point = driver.FindElements(By.ClassName("score"));
            List<int> pointlist = new List<int>();
            foreach (var items in point)
            {

                string text = items.Text;
                string filteredText = text.Replace("points", " ");
                pointlist.Add(int.Parse(filteredText));
                Console.WriteLine(filteredText);
            }

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < mylist.Count; i++)
            {
                dict.Add(mylist[i], pointlist[i]);
            }

            foreach (var code in dict)
            {
                Console.WriteLine(code);

            }
            string min = dict.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine(min + "------->" + dict.Values.Max());
        }
    }
 }