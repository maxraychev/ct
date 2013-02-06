using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.Pages
{
    public class HomePage : PageObject, IDisposable
    {
        protected static string HomePageUrl = ConfigurationManager.AppSettings["BaseUrl"];
        protected string MyQuestPageUrl = HomePageUrl + "/questlist";

        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }
        #region ElementsOnPage
        protected IWebElement MyProjectsHeader;
        protected IWebElement SapmleProjectLink;
        protected IWebElement ProjectLink;
        protected IWebElement ProfileLink;
        protected IWebElement NewProjectButon;
        protected IWebElement FinderMenu;
        #endregion


        public bool IsLoggedIn()
        {
           return IsElementPresent(FindElement(Driver, By.ClassName("log_out")));
        }

        public ProjectPage OpenSampleProjectPage()
        {
            FindElement(Driver, By.XPath("//*[contains(@href, 'projectsummary')]")).Click(); 
            return new ProjectPage(Driver);
        }

        public ProjectPage OpenProjectByLinkText(string linkText)
        {
            GetLinkByText(linkText).Click();
            return new ProjectPage(Driver);
        }

        public NewProjectForm OpenNewProjectForm()
        {
            NewProjectButon = FindElement(Driver, By.XPath("//*[@class='btnl newproj']"));
            NewProjectButon.Click();
            return new NewProjectForm(Driver);
        }

        public string GetProfileLinkText()
        {
            return FindElement(Driver, By.CssSelector(".top-bar-user-name-container.tal>a>span")).Text;
        }



        public string GetProjectLinkText()
        {
            SapmleProjectLink = FindElement(Driver, By.XPath("//*[contains(@href, 'projectsummary')]"));
            return SapmleProjectLink.Text;
        }

        public string GetMyProjectsHeaderText()
        {
            MyProjectsHeader = FindElement(Driver, By.XPath("//h1[contains(text(),'projects')]"));
            return MyProjectsHeader.Text;
        }

        public override void Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
