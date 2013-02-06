using System;
using System.Configuration;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class BuyProjectSteps
    {
        public LoginPage LoginPage;
        public HomePage HomePage;
        public MarketplaceProjectsPage MarketplaceProjectsPage;

        [BeforeScenario("buyProject")]
        public void Setup()
        {
            LoginPage = new LoginPage(WebBrowser.Current);
            LoginPage.Open();
            HomePage = LoginPage.LoginAs(ConfigurationManager.AppSettings["Login"],
                                           ConfigurationManager.AppSettings["Password"]);
        }

        [Given(@"that I navigage to ""(.*)""")]
        public void GivenThatINavigageTo(string p0)
        {
            Assert.True(HomePage.IsLoggedIn());
            MarketplaceProjectsPage = new MarketplaceProjectsPage(WebBrowser.Current);
            MarketplaceProjectsPage.Open();
            Assert.AreEqual(p0, MarketplaceProjectsPage.GetHeaderText());

        }

        [Given(@"I should be able to see ""(.*)"" in the free projects")]
        public void GivenIShouldBeAbleToSeeInTheFreeProjects(string p0)
        {
            Assert.AreEqual(p0, MarketplaceProjectsPage.GetLinkByText(p0).Text);
        }
        
        [When(@"I buy the project ""(.*)""")]
        public void WhenIBuyTheProject(string p0)
        {
            MarketplaceProjectsPage.BuyItemByName(p0);
        }
        
        [Then(@"I should see the message ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string p0)
        {
            Assert.AreEqual(p0, MarketplaceProjectsPage.GetDialogMessage());
        }
        
        [Then(@"the project ""(.*)"" should be available in My projects list")]
        public void ThenTheProjectShouldBeAvailableInMyProjectsList(string p0)
        {
            HomePage.Open();
            Assert.AreEqual(p0,HomePage.GetLinkByText(p0).Text);
        }
    }
}
