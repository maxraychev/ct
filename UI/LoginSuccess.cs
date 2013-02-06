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
    public class LoginSuccess : BaseTest
    {
        private string txtEmailId = "txtEmail";
        private string txtPasswordId = "txtPassword";
        private string btnLoginId = "btnLogin";


        private string login = "nm.tamila@gmail.com";
        private string pass = "Tsymb4lnfvbkf";

        [Test]
        public void TheLoginSuccess()
        {
            driver.Navigate().GoToUrl(baseURL);
            ById(txtEmailId).Clear();
            ById(txtEmailId).SendKeys(login);
            ById(txtPasswordId).Clear();
            ById(txtPasswordId).SendKeys(pass);
            ById(btnLoginId).Click();
            WaitForAjaxControls();
            //Thread.Sleep(1000);
            Assert.AreEqual("logout", ByLinkText("logout").Text);
            Assert.AreEqual("My projects", ByCssSelector("h1").Text);
            try
            {
                Assert.AreEqual("Create new project", ByCssSelector("button.btnl.newproj").Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
    }
}