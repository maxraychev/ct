using System;
using System.Configuration;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class SetUpAndLaunchNewProjectSteps
    {
        private LoginPage _loginPage;
        private HomePage _homePage;
        private NewProjectForm _newProjectForm;
        private ProjectPage _projectPage;


        [BeforeScenario("newProject")]
        public void Setup()
        {
            _loginPage = new LoginPage(WebBrowser.Current);
            _loginPage.Open();
            _homePage = _loginPage.LoginAs(ConfigurationManager.AppSettings["Login"],
                                           ConfigurationManager.AppSettings["Password"]);
        }

        [When(@"I create a new project with name: ""(.*)""")]
        public void WhenICreateANewProjectWithName(string p0)
        {
            _newProjectForm = _homePage.OpenNewProjectForm();
           _projectPage = _newProjectForm.CreateNewProject(p0);
        }
        
        [Then(@"I should see that ""(.*)"" displayed")]
        public void ThenIShouldSeeThatDisplayed(string p0)
        {
            Assert.AreEqual(p0,_projectPage.GetProjectName());
        }
        
        [Then(@"I should see that project status indicator text is: ""(.*)""")]
        public void ThenIShouldSeeThatProjectStatusIndicatorTextIs(string p0)
        {
           Assert.AreEqual(p0, _projectPage.GetProjectStatusIndicatorText());
        }
        
        [Then(@"I should see the error message ""(.*)"" on attempt to launch the proejct")]
        public void ThenIShouldSeeTheErrorMessageOnAttemptToLaunchTheProejct(string p0)
        {
            _projectPage.LaunchProject();
            Assert.AreEqual(p0,_projectPage.GetDialogMessage());
        }
    }
}
