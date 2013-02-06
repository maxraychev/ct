using System;
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
    public class VaidateConfirmationSteps
    {
        public ImapClient Client;
        protected string ConfirmationLink;
        public HomePage HomePage;
        public ProjectPage ProjectPage;

        [When(@"I open the confirmation e-mail and click the confirmation link")]
        public void WhenIOpenTheConfirmationEMailAndClickTheConfirmationLink()
        {
            Client = EmailClient.ConnectToGmail(User.Login, User.Password);
            for (var i = 0;; i++)
            {
                ConfirmationLink = Client.GetConfirmationLink();
                if (ConfirmationLink != null)
                {
                    WebBrowser.Current.Navigate().GoToUrl(ConfirmationLink);
                    break;
                }
                if(i >=60) Assert.Fail("timeout");
                Thread.Sleep(1000);
            }

            
             

        }
        
        [Then(@"I should be redirected to my CoolTool home page")]
        public void ThenIShouldBeRedirectedToMyCoolToolHomePage()
        {
            HomePage = new HomePage(WebBrowser.Current);
            Assert.AreEqual(User.Name, HomePage.GetProfileLinkText());
        }
        
        [Then(@"I should be able to launch the sample project seeing dialog box with text ""(.*)""")]
        public void ThenIShouldBeAbleToLaunchTheSampleProjectSeeingDialogBoxWithText(string p0)
        {
            ProjectPage = HomePage.OpenSampleProjectPage();
            Assert.AreEqual(p0, ProjectPage.LauchProjectAfterActivation());
        }
        
        [Then(@"I should see that project status indicator contains text ""(.*)""")]
        public void ThenIShouldSeeThatProjectStatusIndicatorContainsText(string p0)
        {
            Assert.AreEqual(p0, ProjectPage.GetProjectStatusIndicatorText());
        }
    }
}
