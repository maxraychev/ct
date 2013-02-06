using System;
using System.Configuration;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class AddQuestToProjectSteps
    {
        private LoginPage _loginPage;
        private HomePage _homePage;
        private ProjectPage _projectPage;
        private MyQuestsPage _myQuestsPage;

        [BeforeScenario("addQuest")]
        public void Setup()
        {
            _loginPage = new LoginPage(WebBrowser.Current);
            _loginPage.Open();
            _homePage = _loginPage.LoginAs(ConfigurationManager.AppSettings["Login"],
                                           ConfigurationManager.AppSettings["Password"]);
        }


        [Given(@"I have ""(.*)"" avaialble in my projects list")]
        public void GivenIHaveAvaialbleInMyProjectsList(string p0)
        {
            Assert.AreEqual(p0, _homePage.GetLinkByText(p0).Text);
            _homePage.GetLinkByText(p0).Click();
            
        }
        
        [Given(@"I have no questionnaries set to it")]
        public void GivenIHaveNoQuestionnariesSetToIt()
        {
            _projectPage = new ProjectPage(WebBrowser.Current);
            Project.Url = _projectPage.GetPageUrl();
            Assert.True(_projectPage.IsNoQuestionnarieSet());
        }
        
        [When(@"I open ""(.*)"" list")]
        public void WhenIOpenList(string p0)
        {
            _myQuestsPage = _projectPage.OpenMyQuestList();
            Assert.AreEqual(p0, _myQuestsPage.GetHeaderText());
        }
        
        [When(@"click ""(.*)"" for ""(.*)"" quest")]
        public void WhenClickForQuest(string p0, string p1)
        {
            _myQuestsPage.SetQuestAsCurrentForProject(p1);
            
        }
        
        [Then(@"I should see that ""(.*)"" quest added to ""(.*)""")]
        public void ThenIShouldSeeThatQuestAddedTo(string p0, string p1)
        {
            _homePage.Open();
            _homePage.GetLinkByText(p1).Click();
            _projectPage = new ProjectPage(WebBrowser.Current);
           Assert.AreEqual(p0,_projectPage.GetAnyElementByText(p0).Text);

        }
    }
}
