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
    public class CreateQuestOnline
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        //private ISelenium selenium;

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
        public void TheCreateQuestOnlineTest()
        {
            // Store values
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";


            String Day = DateTime.Today.ToShortDateString();
            String q_name = "Quest Online " + Day;
            Console.WriteLine(q_name);

            // Script
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys(login);
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(pass);
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
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
                Assert.AreEqual("finder", driver.FindElement(By.CssSelector("div.finder-menu")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("div.finder-menu")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("All questionnaires")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("My questionnaires", driver.FindElement(By.CssSelector("h1")).Text);
            driver.FindElement(By.CssSelector("button.btnl.createnew")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Create new questionnaire", driver.FindElement(By.CssSelector("h2.highlight")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("QuestionnaireTypeOnline")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newQuestName")).Clear();
            driver.FindElement(By.Id("newQuestName")).SendKeys(q_name);
            driver.FindElement(By.XPath("//div[@id='newQuestForm']/div[3]/div/button")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("All quests", driver.FindElement(By.LinkText("All quests")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("All projects", driver.FindElement(By.LinkText("All projects")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("All projects ← All quests ← " + q_name, driver.FindElement(By.Id("mainPlaceHolder")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("#questSettingsButton > div")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Questionnaire type: Online", driver.FindElement(By.CssSelector("b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("Test");
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            driver.FindElement(By.CssSelector("b.activetxt")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Single answer");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("a\nb\nc\nd");
            driver.FindElement(By.Id("RequiredOption")).Click();
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[4]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("single answer (dropdown)");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("q\nw\ne\nr\nt");
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[7]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("single answer matrix");
            driver.FindElement(By.Id("goSimpleEditor")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("td.vtop > textarea.uniform")).Clear();
            driver.FindElement(By.CssSelector("td.vtop > textarea.uniform")).SendKeys("1\n2\n3");
            driver.FindElement(By.XPath("//div[@id='matrixAltCont']/div/table/tbody/tr[2]/td/textarea")).Clear();
            driver.FindElement(By.XPath("//div[@id='matrixAltCont']/div/table/tbody/tr[2]/td/textarea")).SendKeys("a\ns\nd");
            driver.FindElement(By.Id("RequiredOption")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("section")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("sectionNameEdit")).Clear();
            driver.FindElement(By.Id("sectionNameEdit")).SendKeys("Section 2");
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[10]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("continuous sum");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("x\nc\nv\nb");
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[2]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Multiple answer");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Click();
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("t\ny\nu\ni\no");
            driver.FindElement(By.Id("UseDifficultToSay")).Click();
            driver.FindElement(By.Id("RequiredOption")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[5]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Rating");
            driver.FindElement(By.Id("questionAlternativesTextArea")).Clear();
            driver.FindElement(By.Id("questionAlternativesTextArea")).SendKeys("re\ntr\nyt\nuy\niu");
            driver.FindElement(By.Id("RequiredOption")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[8]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Multiple answer matrix");
            driver.FindElement(By.Id("goSimpleEditor")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("td.vtop > textarea.uniform")).Clear();
            driver.FindElement(By.CssSelector("td.vtop > textarea.uniform")).SendKeys("1\n2\n3\n4");
            driver.FindElement(By.XPath("//div[@id='matrixAltCont']/div/table/tbody/tr[2]/td/textarea")).Clear();
            driver.FindElement(By.XPath("//div[@id='matrixAltCont']/div/table/tbody/tr[2]/td/textarea")).SendKeys("Row 1\nRow 2\nRow 3");
            driver.FindElement(By.Id("RequiredOption")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[11]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Semantic differential");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input.fl.text")).Clear();
            driver.FindElement(By.CssSelector("input.fl.text")).SendKeys("Alternative 1");
            driver.FindElement(By.XPath("(//input[2])")).Clear();
            driver.FindElement(By.XPath("(//input[2])")).SendKeys("Answer 2");
            driver.FindElement(By.Id("advEditAddAlternative")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("page break")).Click();
            Thread.Sleep(1000);
            Util.Util.MouseOver(driver, By.CssSelector("div.qOperationsBar"));
            driver.FindElement(By.LinkText("question")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Show all types")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='questionTypeSelect']/div[2]/div[14]/b")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("questionNameDiv")).Clear();
            driver.FindElement(By.Id("questionNameDiv")).SendKeys("Test");
            driver.FindElement(By.LinkText("All quests")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("My questionnaires", driver.FindElement(By.CssSelector("h1")).Text);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual(q_name, driver.FindElement(By.LinkText(q_name)).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            //driver.FindElement(By.LinkText(q_name)).Click();
            Util.Util.MouseOver(driver, By.LinkText(q_name));
            Assert.IsTrue(IsElementPresent(By.LinkText("delete")));
            Assert.IsTrue(IsElementPresent(By.LinkText("edit")));
            Assert.IsTrue(IsElementPresent(By.LinkText("preview")));
            try
            {
                Assert.IsFalse(IsElementPresent(By.LinkText("set as current")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("logout")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("CoolTool - Digital Market Research HUB", driver.Title);
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
