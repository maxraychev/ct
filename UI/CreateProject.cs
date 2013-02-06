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
    public class CreateProject : BaseTest
    {
        private string txtEmailId = "txtEmail";
        private string txtPasswordId = "txtPassword";
        private string btnLoginId = "btnLogin";
        private string btnCreateProject = "button.btnl.newproj";
        private string PopUpbtnCancel = "//*[@id='newProjectForm']/div[3]/div[2]/button";
        private string PopUpbtnOk = "//*[@id='newProjectForm']/div[3]/div[1]/button";
        private string newProjectName = "newProjectName";
        private string linklogout = "logout";
        //settings
        private string selectMethod = "span.icon.i-lonline";
        private string methodOnline = "method_online";
        
        
        

        private string login = "nm.tamila@gmail.com";
        private string pass = "Tsymb4lnfvbkf";
        private string p_name = "Project Online " + DateTime.Today.ToShortDateString();
        private string q_name = "Quest Online " +  DateTime.Today.ToShortDateString();
        

        [Test]
        public void TheCreateProject()
        {
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
            Assert.AreEqual("Create new project",ByCssSelector("h2.highlight").Text);
            Assert.AreEqual("Cancel", ByXPath(PopUpbtnCancel).Text);
            ByXPath(PopUpbtnCancel).Click();
            ByCssSelector(btnCreateProject).Click();
            Thread.Sleep(3000);
            ById(newProjectName).Clear();
            ById(newProjectName).SendKeys(p_name);
            ByXPath(PopUpbtnOk).Click();
            WaitForAjaxControls();
            Assert.AreEqual("Launch project", ById("launch").Text);
            Assert.AreEqual("Project status: Design", ByCssSelector("div.fr").Text);
           
//Select Method - > Online -> Contact List
            ByCssSelector(selectMethod).Click();
            WaitForAjaxControls();
            Assert.AreEqual("Research method", ByXPath("//*[@id='prjSetiingsHeader']/div/span[2]").Text);
            Assert.AreEqual("Online (any web browser on any device)", ById(methodOnline).Text);
            ById(methodOnline).Click();
            ById("contactlist_present").Click();
            ByCssSelector("div.close").Click();
            WaitForAjaxControls();
            Assert.AreEqual("Launch project", ById("launch").Text);
            Assert.AreEqual("Project status: Design", ByCssSelector("div.fr").Text);
//logout
            ByLinkText(linklogout).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Login", ById(btnLoginId).Text);
        }
    }
}