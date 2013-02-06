using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    public class LoginFail : BaseTest
    {
        private string txtEmailId = "txtEmail";
        private string txtPasswordId = "txtPassword";
        private string btnLoginId = "btnLogin";
        private string btnOk = "//div[3]/button";
        private string btnCancel = "//button[2]";
        private string btnLogin = "//div[2]/button";

        private string login = "nm.tamila@gmail.com";
        private string i_pass = "tamila";

        [Test]
        public void TheFailLogin()
        {
            driver.Navigate().GoToUrl(baseURL);
            ById(btnLoginId).Click();
            Assert.AreEqual("Email is required", ByCssSelector("div.dlgmessage").Text);
           
            ByXPath(btnOk).Click();
            ByXPath(btnCancel).Click();
            ById(txtEmailId).Clear();
            ById(txtEmailId).SendKeys(login);
            ById(btnLoginId).Click();
            Assert.AreEqual("Password is required", ByCssSelector("div.dlgmessage").Text);

            ByXPath(btnOk).Click();
            ByXPath(btnCancel).Click();

            
            ById(txtPasswordId).Clear();
            ById(txtPasswordId).SendKeys(i_pass);
            ById(btnLoginId).Click();
            Thread.Sleep(5000);
            
            Assert.AreEqual("Incorrect login or password.", ByCssSelector("div.dlgmessage").Text);
            ByXPath(btnOk).Click();
            Thread.Sleep(5000);
            
            ByXPath(btnLogin).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("* Value is required", ByCssSelector("div.formErrorContent").Text);
        }
    }
}
