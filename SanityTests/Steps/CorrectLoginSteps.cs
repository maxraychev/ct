using System;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class CorrectLoginSteps
    {
        protected User User;
        public LoginPage LoginPage;
        public HomePage HomePage;


        [BeforeScenario("login")]
        public void Setup()
        {

            LoginPage = new LoginPage(WebBrowser.Current);
            LoginPage.Open();
        }


        [When(@"I loging in with correct email:""(.*)"" and password ""(.*)""")]
        public void WhenILogingInWithCorrectEmailAndPassword(string p0, string p1)
        {
            HomePage = LoginPage.LoginAs(p0, p1);
        }

        [Then(@"I should see My Projects")]
        public void ThenIShouldSeeMyProjects()
        {
            Assert.AreEqual("My projects", HomePage.GetMyProjectsHeaderText());
        }
    }
}
