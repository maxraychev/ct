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
    public class Registration
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
           
        }
        
        [Test]
        public void TheRegistrationTest()
        {
            String username = "automtest";
            String login = "automtest@mail.zp.ua";
            String pass = "qwerty13";
            String name = "TMT";
            String inlogin = "nm.tamila@gmail.com";
            driver.Navigate().GoToUrl(baseURL + "/");
            try
            {
                Assert.AreEqual("Sign up", driver.FindElement(By.Id("btnReg")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("btnReg")).Click();
            try
            {
                Assert.AreEqual("Create Account", driver.FindElement(By.Id("btnRegister")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("btnRegister")).Click();
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.formErrorContent")).Text, "Value is required"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("Name")).Clear();
            driver.FindElement(By.Id("Name")).SendKeys(name);
            driver.FindElement(By.Id("btnRegister")).Click();
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.formErrorContent")).Text, "Value is required"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("Login")).Clear();
            driver.FindElement(By.Id("Login")).SendKeys(inlogin);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.formErrorContent")).Text, "Email you entered has already been registered\\.(\n|\r\n) Try to recover password"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            driver.FindElement(By.CssSelector("div.formErrorContent")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("div.ppopup_wizardcontent")).Click();
            driver.FindElement(By.Id("Login")).Clear();
            
            driver.FindElement(By.CssSelector("div.ppopup_wizardcontent")).Click();
            driver.FindElement(By.Id("Login")).SendKeys("dsq1sdad1");
            driver.FindElement(By.CssSelector("div.ppopup_wizardcontent")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnRegister")).Click();
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.formErrorContent")).Text, "Invalid email address"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
            driver.FindElement(By.Id("Login")).Clear();
            driver.FindElement(By.CssSelector("div.formErrorContent")).Click();
            driver.FindElement(By.Id("Login")).SendKeys("qw19@qqqq.c.com");
            
            driver.FindElement(By.CssSelector("div.formErrorContent")).Click();
            driver.FindElement(By.CssSelector("div.ppopup_wizardcontent")).Click();
            driver.FindElement(By.Id("Password")).Click();
            //Util.MouseOver(driver, By.Id("Password"));
            driver.FindElement(By.CssSelector("div.login-frame")).Click();
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            driver.FindElement(By.Id("btnRegister")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.formErrorContent")).Text, "Value is required"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(pass);
            driver.FindElement(By.Id("btnRegister")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("Account has been created. Please check you email for an activation link.", driver.FindElement(By.CssSelector("div.alertBox")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ------
            driver.Navigate().GoToUrl("http://www.mail.zp.ua/");
            Assert.AreEqual("Express - Mail :: Первая бесплатная украинская почта", driver.Title);
            // ERROR: Caught exception [ERROR: Unsupported command [selectWindow]]
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("username")).SendKeys(username);
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys(pass);
            driver.FindElement(By.CssSelector("input[type=\"image\"]")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("Express-Mail", driver.Title);
            driver.FindElement(By.LinkText("Входящие")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("Express-Mail", driver.Title);
            driver.FindElement(By.LinkText("Входящие")).Click();
            Assert.AreEqual("Express-Mail", driver.Title);
            driver.FindElement(By.CssSelector("a[title=\"Открыть\"] > span")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Express-Mail", driver.Title);
            driver.FindElement(By.XPath("//a[contains(text(),'http://dev.2futureresearch.com/?mode=veryfication&login=')]")).Click();
            

            driver.SwitchTo().Window(null);
//            driver.Close();            
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("div.ppopup_content > div > a.logo")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [focus]]
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("logEmail")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.Id("inPwd")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Log In", driver.FindElement(By.XPath("//div[2]/button")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("logEmail")).Clear();
            driver.FindElement(By.Id("logEmail")).SendKeys(login);
            driver.FindElement(By.Id("inPwd")).Clear();
            driver.FindElement(By.Id("inPwd")).SendKeys(pass);
            driver.FindElement(By.XPath("//div[2]/button")).Click();
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("a.logo")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("My projects", driver.FindElement(By.CssSelector("h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Online sample project", driver.FindElement(By.LinkText("Online sample project")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        private object FindElement(By by)
        {
            throw new NotImplementedException();
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
