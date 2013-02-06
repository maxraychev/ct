using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class IncorrectLoginSteps
    {
        protected User User;
        protected LoginPage LoginPage;

        [BeforeScenario("incorrectLogin")]
        public void Setup()
        {
            User.Password = "";
            LoginPage = new LoginPage(WebBrowser.Current);
            LoginPage.Open();
        }

        [When(@"I perform Login with blank Email")]
        public void WhenIPerformLoginWithBlankEmail()
        {
            LoginPage.LoginAs(User.Login, User.Password);

        }
        
        [Then(@"alertBox containing text ""(.*)"" is displayed")]
        public void ThenAlertBoxContainingTextIsDisplayed(string p0)
        {
            Assert.AreEqual(p0, LoginPage.GetAlertBoxText());
        }
        
        [Then(@"after dismiss alertBox I shoud be returned to Login again")]
        public void ThenAfterDismissAlertBoxIShoudBeReturnedToLoginAgain()
        {
            Assert.True(LoginPage.IsLoginFrameExists());
        }
    }
}
