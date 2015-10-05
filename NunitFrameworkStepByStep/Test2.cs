using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;

namespace NUnitSelenium
{
    [TestFixture]
    public class UnitTest2
    {

        [SetUp]
        public void SetupTest()
        {
        }

        [Test]
        public void Test2()
        {
            // Step b - Initiating webdriver
            IWebDriver driver = new FirefoxDriver();
            //Step c : Making driver to navigate
            driver.Navigate().GoToUrl("http://docs.seleniumhq.org/");

            //Step d 
            IWebElement myLink = driver.FindElement(By.LinkText("Download"));
            myLink.Click();

           
            //Step e
            Console.WriteLine("End of test");
            driver.Quit();



        }
 
    }
}
