using System;
using System.Configuration;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class BuyQuestionnarieSteps
    {
        public LoginPage _loginPage;
        public HomePage _homePage;
        public MarketPlaceQuestsPage _marketPlaceQuestsPage;
        public MyQuestsPage _myQuestsPage;

        [BeforeScenario("buyQuestionnary")]
        public void Setup()
        {
            _loginPage = new LoginPage(WebBrowser.Current);
            _loginPage.Open();
            _homePage = _loginPage.LoginAs(ConfigurationManager.AppSettings["Login"],
                                           ConfigurationManager.AppSettings["Password"]);
        }


        [Given(@"that I navigagete to ""(.*)""")]
        public void GivenThatINavigageteTo(string p0)
        {
            Assert.True(_homePage.IsLoggedIn());
            _marketPlaceQuestsPage = new MarketPlaceQuestsPage(WebBrowser.Current);
            _marketPlaceQuestsPage.Open();
            Assert.AreEqual(p0, _marketPlaceQuestsPage.GetHeaderText());

        }
        
        [Given(@"should be able to see ""(.*)"" in the free quests")]
        public void GivenShouldBeAbleToSeeInTheFreeQuests(string p0)
        {
            Assert.AreEqual(p0, _marketPlaceQuestsPage.GetLinkByText(p0).Text);
        }
        
        [When(@"I buy the ""(.*)"" quest")]
        public void WhenIBuyTheQuest(string p0)
        {
            _marketPlaceQuestsPage.BuyItemByName(p0);
        }
        
        [Then(@"I should see the message: ""(.*)""")]
        public void ThenIShouldSeeTheMessage(string p0)
        {
            Assert.AreEqual(p0, _marketPlaceQuestsPage.GetDialogMessage());
        }
        
        [Then(@"I should see the ""(.*)"" in my questlist")]
        public void ThenIShouldSeeTheInMyQuestlist(string p0)
        {
            _myQuestsPage = new MyQuestsPage(WebBrowser.Current);
            _myQuestsPage.Open();
           // 
            Assert.AreEqual(p0, _myQuestsPage.GetLinkByText(p0).Text);
        }
    }
}
