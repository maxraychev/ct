using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using CoolToolSite.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CoolToolSite.Tests
{
    [TestFixture]
    public class CreateProject_Online
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
        public void a7CreateProjectOnline()
        {
            String login = "nm.tamila@gmail.com";
            String pass = "Tsymb4lnfvbkf";
            String Day = DateTime.Today.ToShortDateString();
            String p_name = "Project Online " + Day;
            Console.WriteLine(p_name);
            String q_name = "Quest Online " + Day;
            Console.WriteLine(q_name);

            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys(login);
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(pass);
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("CoolTool | Research opportunities platform", driver.Title);
            
            // pause
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
                Assert.AreEqual("Create new project", driver.FindElement(By.CssSelector("button.btnl.newproj")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.btnl.newproj")).Click();
            try
            {
                Assert.AreEqual("Create new project", driver.FindElement(By.CssSelector("h2.highlight")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Cancel", driver.FindElement(By.CssSelector("button.btna")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//div[2]/button")).Click();
            driver.FindElement(By.CssSelector("button.btnl.newproj")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newProjectName")).Clear();
            driver.FindElement(By.Id("newProjectName")).SendKeys(p_name);
            driver.FindElement(By.CssSelector("button.btn")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Method\n Online", driver.FindElement(By.CssSelector("div.prjsettings")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Launch project", driver.FindElement(By.Id("launch")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Project status: Design", driver.FindElement(By.CssSelector("div.fr")).Text);
            try
            {
                Assert.AreEqual("Method\n Online", driver.FindElement(By.CssSelector("div.prjsettings")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("span.icon.i-lonline")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Research method", driver.FindElement(By.XPath("//div[@id='prjSetiingsHeader']/div/span[2]")).Text);
            try
            {
                Assert.AreEqual("Online (any web browser on any device)", driver.FindElement(By.CssSelector("label.i-monitor.method_icon > span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("method_online")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("label.i-cont-list.method_icon > span")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("contactlist_present")).Click();
            try
            {
                Assert.AreEqual("Ok", driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Schedule", driver.FindElement(By.XPath("//div[@id='prjSetiingsHeader']/div/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Util.MouseOver(driver, By.CssSelector("div.iPhoneCheckHandle"));
            driver.FindElement(By.CssSelector("div.iPhoneCheckHandle")).Click();
            driver.FindElement(By.XPath("//div[2]/div/div/table/tbody/tr/td[2]/div/div/div")).Click();
            Thread.Sleep(1000);
            Util.MouseOver(driver, By.CssSelector("span.ui-selectBox-arrow"));
            driver.FindElement(By.CssSelector("span.ui-selectBox-arrow")).Click();
            //Util.MouseDown(driver, By.CssSelector("span.ui-selectBox-arrow"));
            Util.MouseOver(driver, By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[15]"));
            driver.FindElement(By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[15]")).Click();
            driver.FindElement(By.CssSelector("div.letterbg-container")).Click();
            driver.FindElement(By.CssSelector("textarea.uniform")).Clear();
            driver.FindElement(By.CssSelector("textarea.uniform")).SendKeys("Hi @firstName, \n\nWe would like to invite you to participate in our survey. Your response is very much appreciated. Please click the link below or copy it and paste the URL into your browser to begin the survey.\nTest TMT");
            Util.MouseOver(driver, By.CssSelector("button.prjsettings-apply-button"));
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            Thread.Sleep(500);
            try
            {
                Assert.AreEqual("Reminders", driver.FindElement(By.XPath("//div[@id='prjSetiingsHeader']/div/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("div.iPhoneCheckHandle")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.Id("Reminder1Subject")).Click();
            driver.FindElement(By.CssSelector("textarea.uniform")).Clear();
            driver.FindElement(By.CssSelector("textarea.uniform")).SendKeys("Hi @firstName, \n\n @inviteDate you were sent an invitation to participate in survey.Your response is very much appreciated. Please click the link below or copy it and paste the URL into your browser to begin the survey.\n\nThank you for your time spending with us. \n\nTest TMT");
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Rewards", driver.FindElement(By.XPath("//div[@id='prjSetiingsHeader']/div/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("BARCODE", driver.FindElement(By.XPath("//div[@id='ProjectRewards']/div/table/tbody/tr[2]/td[2]/label")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.Id("barcoderewards")).Click();
            driver.FindElement(By.Id("SingleBarcodeString")).Clear();
            driver.FindElement(By.Id("SingleBarcodeString")).SendKeys("1234567891");
            driver.FindElement(By.Id("barcode-rewards-block")).Click();
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("img.fl")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Util.MouseOver(driver, By.CssSelector("span.ui-selectBox-arrow"));
            driver.FindElement(By.CssSelector("span.ui-selectBox-arrow")).Click();
            //Util.MouseDown(driver, By.CssSelector("span.ui-selectBox-arrow"));
            Util.MouseOver(driver, By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[7]"));
            driver.FindElement(By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[7]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseDown]]
            // ERROR: Caught exception [ERROR: Unsupported command [mouseUp]]
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("img.fl")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.prjsettings-apply-button")).Click();
            Thread.Sleep(500);
            try
            {
                Assert.AreEqual("Authority", driver.FindElement(By.XPath("//div[@id='prjSetiingsHeader']/div/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("div.close")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("div.close")).Click();
            Thread.Sleep(500);
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("span.icon.i-lquest")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("span.icon.i-lquest")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("My questionnaires", driver.FindElement(By.CssSelector("h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Create new questionnaire", driver.FindElement(By.CssSelector("button.btnl.createnew")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
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
            // change button
            driver.FindElement(By.Id("newQuestName")).Clear();
            driver.FindElement(By.Id("newQuestName")).SendKeys(q_name);
            driver.FindElement(By.XPath("//div[@id='newQuestForm']/div[3]/div/button")).Click();
            Thread.Sleep(1000);
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
                Assert.AreEqual("All quests", driver.FindElement(By.LinkText("All quests")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }

            driver.FindElement(By.LinkText("All quests")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("My questionnaires", driver.FindElement(By.CssSelector("h1")).Text);
            driver.FindElement(By.LinkText(p_name)).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("All questionnaires", driver.FindElement(By.LinkText("All questionnaires")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual(q_name, driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[5]/a/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("RESPONDENTS", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[6]")).Text);
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("span.icon.i-lcontacts")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("span.icon.i-lcontacts")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("My contact lists", driver.FindElement(By.CssSelector("h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Create new contact list", driver.FindElement(By.CssSelector("button.btnl.createNew")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("My contact");
            driver.FindElement(By.CssSelector("h1")).Click();
            Thread.Sleep(500);
            Util.MouseOver(driver, By.LinkText("My contact"));
            driver.FindElement(By.LinkText("set as current")).Click();
            driver.FindElement(By.LinkText(p_name)).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("All contact lists", driver.FindElement(By.LinkText("All contact lists")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("My contact", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[7]/a/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[7]/a[2]/i")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("RandomSamplingOption")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.Id("NumberOfInvitationsToSend")).Clear();
            driver.FindElement(By.Id("NumberOfInvitationsToSend")).SendKeys("2");
            driver.FindElement(By.Id("SampleSizeEditor")).Clear();
            driver.FindElement(By.Id("SampleSizeEditor")).SendKeys("2");
            driver.FindElement(By.LinkText(p_name)).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Random sampling (2 respondents)", driver.FindElement(By.XPath("//div[@id='mainPlaceHolder']/div/div/div[3]/div[7]/a[2]/span[2]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All projects")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(p_name);
            driver.FindElement(By.CssSelector("h1")).Click();
            Thread.Sleep(500);
            try
            {
                Assert.AreEqual(p_name, driver.FindElement(By.LinkText(p_name)).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText(p_name)).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Launch project", driver.FindElement(By.Id("launch")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All projects")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(p_name);
            driver.FindElement(By.CssSelector("h1")).Click();
            Thread.Sleep(500);
            Util.MouseOver(driver, By.LinkText(p_name));
            driver.FindElement(By.LinkText("edit")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Launch project", driver.FindElement(By.Id("launch")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Project status: Design", driver.FindElement(By.CssSelector("div.fr")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("All projects")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(p_name);
            driver.FindElement(By.CssSelector("h1")).Click();
            Thread.Sleep(500);
            Util.MouseOver(driver, By.LinkText(p_name));
            driver.FindElement(By.LinkText("delete")).Click();
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.dlgmessage > div")).Text, "^exact:Do you realy want to delete this item[\\s\\S]$"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Cancel", driver.FindElement(By.CssSelector("button.btna")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Delete", driver.FindElement(By.CssSelector("button.btn")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            // change button
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(100);
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            Util.MouseOver(driver, By.LinkText(p_name));
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            driver.FindElement(By.LinkText("delete")).Click();
            driver.FindElement(By.XPath("//div[3]/button")).Click();

            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("p_name");
            driver.FindElement(By.CssSelector("h1")).Click();
            Assert.AreEqual("No items", driver.FindElement(By.CssSelector("div.gray.noitems")).Text);
            driver.FindElement(By.CssSelector("div.finder-menu")).Click();
            driver.FindElement(By.LinkText("All questionnaires")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            driver.FindElement(By.CssSelector("h1")).Click();
            Util.MouseOver(driver, By.LinkText(q_name));
            // ERROR: Caught exception [ERROR: Unsupported command [mouseOver]]
            driver.FindElement(By.LinkText("delete")).Click();
            driver.FindElement(By.XPath("//div[3]/button")).Click();
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys(q_name);
            driver.FindElement(By.CssSelector("div.Header.myItemsHead")).Click();
            Assert.AreEqual("No items", driver.FindElement(By.CssSelector("div.gray.noitems")).Text);
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
