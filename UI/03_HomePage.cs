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
    public class HomePage
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
        public void TheHomePageTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
            Assert.AreEqual("Login", driver.FindElement(By.Id("btnLogin")).Text);
            try
            {
                Assert.AreEqual("Sign up", driver.FindElement(By.Id("btnReg")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("ABOUT", driver.FindElement(By.CssSelector("span.menu-item.text-gray")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("HOW IT WORKS", driver.FindElement(By.XPath("//li[3]/a/span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("FEATURES", driver.FindElement(By.XPath("//li[5]/a/span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("MARKETPLACE", driver.FindElement(By.XPath("//span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("REGISTER NOW, IT IS FREE", driver.FindElement(By.Id("register_action")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//li[3]/a/span")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
            try
            {
                Assert.AreEqual("Conduct market research projects from A to Z", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Collaborate with your Partners and Clients", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div[2]/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Buy content and services from other researchers", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div[3]/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Sell research services and make money using CoolTool", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div[5]/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//li[5]/a/span")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
            try
            {
                Assert.AreEqual("Free Powerful Research Production Webtool", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Various research methods", driver.FindElement(By.CssSelector("div.caption-level-4")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Different ways to publish survey/ collect results", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[5]/div/div[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Comfortable project management tools", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[5]/div[2]/div[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Automated reports", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[5]/div[3]/div[3]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Open Collaboration Platform", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div[2]/div[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//span[2]")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
            try
            {
                Assert.AreEqual("Marketplace / projects", driver.FindElement(By.CssSelector("div.MarketLayout > div.Header > h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Questionnaires")).Click();
            Thread.Sleep(3000);
            try
            {
                Assert.AreEqual("Marketplace / quests", driver.FindElement(By.CssSelector("div.MarketLayout > div.Header > h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Respondents (panels)")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("Marketplace / respondents (panels)", driver.FindElement(By.CssSelector("div.MarketLayout > div.Header > h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
