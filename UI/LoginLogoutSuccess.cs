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
    public class LoginLogoutSuccess : BaseTest
    {
        //id
        private string txtEmailId = "txtEmail";
        private string frameEmail = "logEmail";
        private string txtPasswordId = "txtPassword";
        private string framePassword = "inPwd";
        private string btnLoginId = "btnLogin";
        private string linklogout = "logout";
        //xpath
        private string frameOk = "//div[3]/button";
        private string frameLogin = "//div[2]/button[1]";
        //value
        private string login = "nm.tamila@gmail.com";
        private string pass = "Tsymb4lnfvbkf";

        [Test]
        public void TheLoginAndLogoutAndLogin()
        {
            //Login
            driver.Navigate().GoToUrl(baseURL);
            ById(txtEmailId).Clear();
            ById(txtEmailId).SendKeys(login);
            ById(txtPasswordId).Clear();
            ById(txtPasswordId).SendKeys(pass);
            ById(btnLoginId).Click();
            WaitForAjaxControls();
            Assert.AreEqual("logout", ByLinkText("logout").Text);
            //Logout   
            ByLinkText(linklogout).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Login", ById("btnLogin").Text);
            
            //Login
            ById(btnLoginId).Click();
            Assert.AreEqual("Email is required", ByCssSelector("div.dlgmessage").Text);
            ByXPath(frameOk).Click();
            ById(frameEmail).Clear();
            ById(frameEmail).SendKeys(login);
            ById(framePassword).Clear();
            ById(framePassword).SendKeys(pass);
            ByXPath(frameLogin).Click();
            WaitForAjaxControls();
            Assert.AreEqual("logout", ByLinkText("logout").Text);
        }
    }
}