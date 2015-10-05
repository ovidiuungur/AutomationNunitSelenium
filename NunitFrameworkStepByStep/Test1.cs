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
    public class UnitTest1
    {

        [SetUp]
        public void SetupTest()
        {
        }

        [Test]
        public void Test_OpeningHomePage()
        {
            // Step b - Initiating webdriver
            IWebDriver driver = new FirefoxDriver();
            //Step c : Making driver to navigate
            driver.Navigate().GoToUrl("http://docs.seleniumhq.org/");

            //Step d 
            IWebElement myLink = driver.FindElement(By.LinkText("Download"));
            myLink.Click();

            TakeScreenshot (driver,"");


            //Step e
            Console.WriteLine("End of test");
            driver.Quit();



        }
        private int _screenshotCount;
        private void TakeScreenshot(IWebDriver driver, string fileName = "")
        {

            var screenshotDriver = driver as ITakesScreenshot;

            if (screenshotDriver == null) return;

            var currentDirectory = Directory.GetCurrentDirectory();
            var testName = TestContext.CurrentContext.Test.Name;

            // If no name is given it will default to TESTSUITE_TESTCASE_COUNT.png.
            if (String.IsNullOrWhiteSpace(fileName))
                fileName = string.Format("{0}_{1}_{2:00}.png", GetType().Name, testName, _screenshotCount);

            _screenshotCount++;

            Console.WriteLine("Taking screenshot.");
            var screenshot = screenshotDriver.GetScreenshot();

            Console.WriteLine("Saving screenshot {0}.", fileName);
            screenshot.SaveAsFile(currentDirectory + "\\" + fileName, ImageFormat.Png);
        }
    }
}
    