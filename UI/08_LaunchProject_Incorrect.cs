using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
    public class LaunchProjectIncorrect
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
        public void TheLaunchProjectIncorrectTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";
            String Day = DateTime.Today.ToShortDateString();
            

            String pr_name = "Project Online " + Day + " LaunchInccorect";
            Console.WriteLine(pr_name);
            String q_name = "Quest Online " + Day;
            Console.WriteLine(q_name);
            String qm_name = "Quest Mobile " + Day;
            Console.WriteLine(qm_name);
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
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("launch")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("launch")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.dlgmessage")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Console.WriteLine("если запущена селения это окно не отображается");
            driver.FindElement(By.CssSelector("div.tac > button.btn")).Click();
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

            driver.FindElement(By.CssSelector("div.l_dg > div.itemblock.cl > div.l_vid")).Click();
            driver.FindElement(By.LinkText("set as current")).Click();
            driver.FindElement(By.LinkText(pr_name)).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.CssSelector("span.status")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Assert.IsTrue(IsElementPresent(By.XPath("//table[@id='projectTypeSelector']/tbody/tr[2]/td[2]")));
            driver.FindElement(By.XPath("//table[@id='projectTypeSelector']/tbody/tr[2]/td[2]")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'set as\n                                current')])[2]")).Click();
            driver.FindElement(By.CssSelector("div.close")).Click();
            driver.FindElement(By.Id("launch")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [getAlert]]
            driver.FindElement(By.CssSelector("span.status")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'set as current')])[2]")).Click();
            driver.FindElement(By.CssSelector("div.close")).Click();
            driver.FindElement(By.LinkText("All questionnaires")).Click();
            // ---
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(qm_name);
            driver.FindElement(By.CssSelector("div.filter")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.XPath("//a[contains(text(),'${qm_name}')]"));

            driver.FindElement(By.XPath("//a[contains(text(),'${qm_name}')]")).Click();
            driver.FindElement(By.LinkText("set as current")).Click();
            driver.FindElement(By.LinkText(pr_name)).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            driver.FindElement(By.Id("launch")).Click();
            Console.WriteLine("Алерт не отображется");
            // ERROR: Caught exception [ERROR: Unsupported command [getAlert]]
            driver.FindElement(By.CssSelector("span.status")).Click();
            driver.FindElement(By.XPath("//table[@id='projectTypeSelector']/tbody/tr/td[2]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'set as\n                                current')]")).Click();
            driver.FindElement(By.CssSelector("div.close")).Click();
            driver.FindElement(By.LinkText("All questionnaires")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            driver.FindElement(By.CssSelector("div.filter")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.XPath("//a[contains(text(),'${q_name}')]"));
            driver.FindElement(By.XPath("//a[contains(text(),'${q_name}')]")).Click();
            driver.FindElement(By.LinkText("set as current")).Click();
            driver.FindElement(By.LinkText(pr_name)).Click();
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
