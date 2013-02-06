using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CoolToolSite.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CoolToolSite
{
    [TestFixture]
    public class NNCreateProjectMobile
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
        public void TheCreateProjectMobileTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";
            
          
            String Day = DateTime.Today.ToShortDateString();

            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            
            String pr_name = "Project Mobile " + Day;
            Console.WriteLine(pr_name);
            String q_name = "Quest Mobile " + Day;
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
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("button.btnl.newproj")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newProjectName")).Clear();
            driver.FindElement(By.Id("newProjectName")).SendKeys(pr_name);
            driver.FindElement(By.XPath("//div[@id='newProjectForm']/div[3]/div/button")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("div.prjsettings")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            //Assert.IsTrue(IsElementPresent(By.XPath("//table[@id='projectTypeSelector']/tbody/tr[2]/td[2]")));
            driver.FindElement(By.XPath("//table[@id='projectTypeSelector']/tbody/tr[2]/td[2]")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'set as\n                                current')])[2]")).Click();
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.XPath("//div[@id='ProjectRewards']/div/table/tbody/tr[2]/td[2]/label")).Click();
            driver.FindElement(By.Id("barcoderewards")).Click();
            driver.FindElement(By.CssSelector("span.ui-selectBox-arrow")).Click();
            driver.FindElement(By.Id("SingleBarcodeString")).Clear();
            driver.FindElement(By.Id("SingleBarcodeString")).SendKeys("123456789");
            // ERROR: Caught exception [ERROR: Unsupported command [mouseDown]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseUp]]
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.fl")));
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("div.close")).Click();
            driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[5]/a/span[2]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.MouseOver(driver, By.XPath("//a[contains(text(),'${q_name}')]"));
            driver.FindElement(By.LinkText("set as current")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText(pr_name)).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Assert.AreEqual("All questionnaires", driver.FindElement(By.LinkText("All questionnaires")).Text);
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("span.icon.i-lsample")).Click();
            try
            {
                Assert.AreEqual("Sample Plan / Quotation", driver.FindElement(By.CssSelector("h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Invite all contacts", driver.FindElement(By.CssSelector("label")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("InviteAllContacts")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.LinkText(pr_name)).Click();
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
