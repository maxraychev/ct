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
    public class CreateQuestMobile
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
        public void TheCreateQuestMobileTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";
            
            String Day = DateTime.Today.ToShortDateString();
            
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]
            
            // ERROR: Caught exception [ERROR: Unsupported command [getEval]]

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
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("div.finder-menu")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'All questionnaires')]")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("My questionnaires", driver.FindElement(By.CssSelector("h1")).Text);
            driver.FindElement(By.CssSelector("button.btnl.createnew")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("Create new questionnaire", driver.FindElement(By.CssSelector("h2.highlight")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("newQuestName")).Clear();
            driver.FindElement(By.Id("newQuestName")).SendKeys(q_name);
            driver.FindElement(By.XPath("//div[@id='newQuestForm']/div[2]/div[2]/label[2]")).Click();
            driver.FindElement(By.Id("QuestionnaireTypeMobile")).Click();
            driver.FindElement(By.CssSelector("button.btn")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("#questSettingsButton > div")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [isTextPresent]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));

            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("div.questionType.singleAnswer")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("single answer");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("1\n2\n3\n4");
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector("div.questionType.singleAnswer")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("single answer");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("5\n6\n7\n8");
            driver.FindElement(By.LinkText("All quests")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            Assert.AreEqual(q_name, driver.FindElement(By.LinkText(q_name)).Text);
            Thread.Sleep(5000);
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.Util.MouseOver(driver, By.LinkText(q_name));
            try
            {
                Assert.AreEqual("delete", driver.FindElement(By.LinkText("delete")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("edit", driver.FindElement(By.LinkText("edit")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("preview", driver.FindElement(By.LinkText("preview")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
