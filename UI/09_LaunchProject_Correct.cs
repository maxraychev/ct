using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
    public class LaunchProjectCorrect
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dev.2futureresearch.com";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheLaunchProjectCorrectTest()
        {
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";


            String Day = DateTime.Today.ToShortDateString();



            String pr_name = "Project Online " + Day + " LaunchCorrect";
            Console.WriteLine(pr_name);
            String q_name = "Quest Online " + Day;
            Console.WriteLine(q_name);
            // Script
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys(login);
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(pass);
            driver.FindElement(By.Id("btnLogin")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("button.btnl.newproj")).Click();
            driver.FindElement(By.Id("newProjectName")).Clear();
            driver.FindElement(By.Id("newProjectName")).SendKeys(pr_name);
            driver.FindElement(By.CssSelector("button.btn")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[5]/a/span[2]")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            driver.FindElement(By.CssSelector("div.filter")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.l_dg > div.itemblock.cl > div.l_vid")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.CssSelector("div.l_dg > div.itemblock.cl > div.l_vid"));
            driver.FindElement(By.LinkText("set as current")).Click();
            driver.FindElement(By.LinkText(pr_name)).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("span.icon.i-lonline")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'set as\n                                current')]")).Click();
            driver.FindElement(By.CssSelector("div.close")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.Id("launch")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("div.tar.space > div.mt-0 > button.btna")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.Id("launch")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.Id("confirmProject")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText("logout")).Click();
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
