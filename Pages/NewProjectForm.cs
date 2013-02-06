using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.Pages
{
    public class NewProjectForm : PageObject
    {
        public NewProjectForm(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "newProjectName")] 
        protected IWebElement NewProjectNameField;

        protected IWebElement OkButton;

        public ProjectPage CreateNewProject(string projectName)
        {
            Type(NewProjectNameField, projectName);
            this.FindElement(Driver, By.CssSelector(".btn")).Click();
            //OkButton.Click();
            return new ProjectPage(Driver);
        }

        public override void Open()
        {
        //    using (var hp = new HomePage(Driver))
        //    {
        //        hp.Open();
        //        hp.FindElement()
        //    }
        }
    }
}
