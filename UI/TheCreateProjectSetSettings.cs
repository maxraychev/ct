using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    public class CreateProjectSetting : BaseTest
    {
        private string txtEmailId = "txtEmail";
        private string txtPasswordId = "txtPassword";
        private string btnLoginId = "btnLogin";
        private string btnCreateProject = "button.btnl.newproj";
        private string PopUpbtnCancel = "//*[@id='newProjectForm']/div[3]/div[2]/button";
        private string PopUpbtnOk = "//*[@id='newProjectForm']/div[3]/div[1]/button";
        private string newProjectName = "newProjectName";
        //settings
        private string selectMethod = "span.icon.i-lonline";
        private string methodOnline = "method_online";
        private string settingsOk = "button.prjsettings-apply-button";
        private string Start = "div.iPhoneCheckHandle";
        private string Stop = "//div[2]/div/div/table/tbody/tr/td[2]/div/div/div";
        private string BoxMessage = "textarea.uniform";
        private string btnbarcoderewards = "barcoderewards";
        private string radiobtnSingleBarcode = "SingleBarcodeString";
        private string barcodeimg = "barcode-rewards-block";
        private string dropdown = "span.ui-selectBox-arrow";
        private string linklogout = "logout";


        private string login = "nm.tamila@gmail.com";
        private string pass = "Tsymb4lnfvbkf";
        private string Day = DateTime.Today.ToShortDateString();
        private string invMessage = "Hi @firstName, \n\nWe would like to invite you to participate in our survey. Your response is very much appreciated. Please click the link below or copy it and paste the URL into your browser to begin the survey.\nTest TMT";
        private string remMessage = "Hi @firstName, \n\n @inviteDate you were sent an invitation to participate in survey.Your response is very much appreciated. Please click the link below or copy it and paste the URL into your browser to begin the survey.\n\nThank you for your time spending with us. \n\nTest TMT";
        private string vbarcode = "123456798";

        [Test]
        public void TheCreateProjectSetSettings()
        {

            String p_name = "Project Online " + Day;
            Console.WriteLine(p_name);
            String q_name = "Quest Online " + Day;
            Console.WriteLine(q_name);

            driver.Navigate().GoToUrl(baseURL);
//LogIn
            ById(txtEmailId).Clear();
            ById(txtEmailId).SendKeys(login);
            ById(txtPasswordId).Clear();
            ById(txtPasswordId).SendKeys(pass);
            ById(btnLoginId).Click();
            WaitForAjaxControls();
            Assert.AreEqual("logout", ByLinkText("logout").Text);
            Assert.AreEqual("My projects", ByCssSelector("h1").Text);
            Assert.AreEqual("Create new project", ByCssSelector(btnCreateProject).Text);
//CreateProject 
            ByCssSelector(btnCreateProject).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Create new project", ByCssSelector("h2.highlight").Text);
            Assert.AreEqual("Cancel", ByXPath(PopUpbtnCancel).Text);
            ByXPath(PopUpbtnCancel).Click();
            ByCssSelector(btnCreateProject).Click();
            Thread.Sleep(3000);
            ById(newProjectName).Clear();
            ById(newProjectName).SendKeys(p_name);
            ByXPath(PopUpbtnOk).Click();
            WaitForAjaxControls();
            Assert.AreEqual("Method\r\nOnline", ByCssSelector("div.prjsettings").Text);
            Assert.AreEqual("Launch project", ById("launch").Text);
            Assert.AreEqual("Project status: Design", ByCssSelector("div.fr").Text);
//Select Method - > Online -> Contact List
            ByCssSelector(selectMethod).Click();
            WaitForAjaxControls();
            Assert.AreEqual("Research method", ByXPath("//*[@id='prjSetiingsHeader']/div/span[2]").Text);
            Assert.AreEqual("", ById(methodOnline).Text);
            ById(methodOnline).Click();
            ById("contactlist_present").Click();
            Assert.AreEqual("Ok", ByCssSelector(settingsOk).Text);
            ByCssSelector(settingsOk).Click();
            WaitForAjaxControls();
//Set Schedule
            Assert.AreEqual("Schedule", ByXPath("//div[@id='prjSetiingsHeader']/div/span[2]").Text);
            Util.MouseOver(driver, By.CssSelector(Start));
            ByCssSelector(Start).Click();
            ByXPath(Stop).Click();
            Util.MouseOver(driver, By.CssSelector(dropdown));
            ByCssSelector(dropdown).Click();
            Util.MouseOver(driver, By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[15]"));
            ByXPath("//div[@id='ui-selectBox-dropdown']/ul/li[15]").Click();
            ByCssSelector("div.letterbg-container").Click();
            ByCssSelector(BoxMessage).Clear();
            ByCssSelector(BoxMessage).SendKeys(invMessage);
            ByCssSelector(settingsOk).Click();
            WaitForAjaxControls();
//Set Reminders
            Assert.AreEqual("Reminders", ByXPath("//div[@id='prjSetiingsHeader']/div/span[2]").Text);
            ByCssSelector(Start).Click();
            Thread.Sleep(500);
            ById("Reminder1Subject").Click();
            ByCssSelector(BoxMessage).Clear();
            ByCssSelector(BoxMessage).SendKeys(remMessage);
            ByCssSelector(settingsOk).Click();
            WaitForAjaxControls();
// Set Rewards
            Assert.AreEqual("Rewards", ByXPath("//div[@id='prjSetiingsHeader']/div/span[2]").Text);
            Assert.AreEqual("BARCODE", ByXPath("//div[@id='ProjectRewards']/div/table/tbody/tr[2]/td[2]/label").Text);
            ById(btnbarcoderewards).Click();
            ById(radiobtnSingleBarcode).Clear();
            ById(radiobtnSingleBarcode).SendKeys(vbarcode);
            ById(barcodeimg).Click();
            Assert.AreEqual("", ByCssSelector("img.fl").Text);
            Util.MouseOver(driver, By.CssSelector(dropdown));
            ByCssSelector(dropdown).Click();
            Util.MouseOver(driver, By.XPath("//div[@id='ui-selectBox-dropdown']/ul/li[7]"));
            ByXPath("//div[@id='ui-selectBox-dropdown']/ul/li[7]").Click();
            Thread.Sleep(1000);
            Assert.AreEqual("", ByCssSelector("img.fl").Text);
            ByCssSelector(settingsOk).Click();
            WaitForAjaxControls();
            Assert.AreEqual("Authority", ByXPath("//div[@id='prjSetiingsHeader']/div/span[2]").Text);
            Assert.AreEqual("", ByCssSelector("div.close").Text);
            ByCssSelector("div.close").Click();
            WaitForAjaxControls();
            Assert.AreEqual("", ByCssSelector("span.icon.i-lquest").Text);
            Assert.AreEqual("Method\r\nOnline", ByCssSelector("div.prjsettings").Text);
            Assert.AreEqual("Launch project", ById("launch").Text);
            Assert.AreEqual("Project status: Design", ByCssSelector("div.fr").Text);
//logout
            ByLinkText(linklogout).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Login", ById(btnLoginId).Text);
        }
    }
}