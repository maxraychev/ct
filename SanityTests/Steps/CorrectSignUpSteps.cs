 using System.Threading;
using AE.Net.Mail;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Pages;
using CoolToolSite.Tests.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.SanityTests.Steps
{
    [Binding]
    public class CorrectSignUpSteps
    {
        protected User User;
        protected static LoginPage LoginPage;
        protected HomePage HomePage;
        protected static SignUpFrame SignUpFrame;
        protected ProjectPage SampleProjectPage;
        protected string AlertBoxText;

        [BeforeScenario("newUser")]
        public void Setup()
        {
            CommonHelper.RemoveTestUser();
        }

        [Given(@"I have gmail test account with email: ""(.*)"" and password: ""(.*)""")]
        public void GivenIHaveGmailTestAccountWithEmailAndPassword(string login, string password)
        {
            //Refresh the User
            User.Password = password;
            User.Name = login.Substring(0, 12);

            // Clean Up an old emails
            var client = EmailClient.ConnectToGmail(User.Login, User.Password);
            MailMessage[] mailMessages = client.GetMessages(0, 100, false, true);
            foreach (var mailMessage in mailMessages)
            {
                client.DeleteMessage(mailMessage);
            }
            client.Disconnect();
        }

        [When(@"I use these for creation of new account")]
        public static void WhenIUseTheseForCreationOfNewAccount()
        {
            LoginPage = new LoginPage(WebBrowser.Current);
            LoginPage.Open();
            SignUpFrame = LoginPage.OpenSignUpDialog();
            SignUpFrame.SignUpAs(User.Name, User.Login, User.Password);

        }

        [Then(@"I should see an alert box with message: ""(.*)""")]
        public void ThenIShouldSeeAnAlertBoxWithMessage(string p0)
        {
            AlertBoxText = SignUpFrame.GetDialogMessage();
            Assert.AreEqual(p0, AlertBoxText);
        }

        [Then(@"I should see the link to my profile with my name")]
        public void ThenIShouldSeeTheLinkToMyProfileWithMyName()
        {
            HomePage = new HomePage(WebBrowser.Current);
            Assert.AreEqual(User.Name, HomePage.GetProfileLinkText());

        }

        [Then(@"I should see ""(.*)"" on my dashboard")]
        public void ThenIShouldSeeOnMyDashboard(string p0)
        {
            Assert.AreEqual(p0, HomePage.GetProjectLinkText());
        }

        [Then(@"on attempt to launch this project I should see the message: ""(.*)""")]
        public void ThenOnAttemptToLaunchThisProjectIShouldSeeTheMessage(string p0)
        {
            SampleProjectPage = HomePage.OpenSampleProjectPage();
            Thread.Sleep(1000);
            SampleProjectPage.LaunchProject();
            Assert.AreEqual(p0, SampleProjectPage.GetActivationReminderText());
        }
    }
}
