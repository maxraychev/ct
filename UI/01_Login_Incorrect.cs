using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
    public class LoginIncorrect
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://dev.2futureresearch.com/";
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
        public void C01LoginIncorrectTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String i_pass = "tamila";
            
            // Script
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.AreEqual("Email is required", driver.FindElement(By.CssSelector("div.dlgmessage")).Text); 
            //driver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click();
            driver.FindElement(By.XPath("//div[3]/button")).Click();
            driver.FindElement(By.XPath("//button[2]")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys(login);
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.AreEqual("Password is required", driver.FindElement(By.CssSelector("div.dlgmessage")).Text);
            driver.FindElement(By.XPath("//div[3]/button")).Click();
            driver.FindElement(By.XPath("//button[2]")).Click();
            driver.FindElement(By.Id("inPwd")).Click();
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(i_pass);
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("Incorrect login or password.", driver.FindElement(By.CssSelector("div.dlgmessage")).Text);
            driver.FindElement(By.XPath("//div[3]/button")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[2]/button")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("* Value is required", driver.FindElement(By.CssSelector("div.formErrorContent")).Text);
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
