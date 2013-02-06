using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
    public class DeleteProjectStatusDesign
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
        public void TheDeleteProjectStatusDesignTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";
            

            String Day = DateTime.Today.ToShortDateString();
            Console.WriteLine(Day);
            String pr_name = "Project Mobile " + Day;
            Console.WriteLine(pr_name);

            //String q_name = "Quest Mobile" + Day + "-" + Month + "-" + Year;
            //Console.WriteLine(q_name);



            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            //Console.WriteLine(Year);
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            //Console.WriteLine(Month);
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            //Console.WriteLine(Day);
            //String pr_name = "Project Mobile " + Day + "-" + Month + "-" + Year;
            //Console.WriteLine(pr_name);
            // Script
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys(login);
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(pass);
            driver.FindElement(By.Id("btnLogin")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(pr_name);
            driver.FindElement(By.CssSelector("div.filter")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            driver.FindElement(By.LinkText("delete")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("button.btna")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText("delete")).Click();
            driver.FindElement(By.CssSelector("button.btn")).Click();
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
