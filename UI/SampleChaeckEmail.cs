using CoolToolSite.Tests.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AE.Net.Mail;
using System.Threading;

namespace CoolToolSite.Tests.UI
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
    class SampleChaeckEmail
    {
        private const string TestEmail = "cooltooltestlogin@gmail.com";
        private const string TestPassword = "12#%cooltooltestlogin";

        private ImapClient CreateCleint()
        {
            return EmailClient.ConnectToGmail(TestEmail, TestPassword);
        }

        [SetUp]
        public void SetupTest()
        {
            using (var emailClient = CreateCleint())
            {
                emailClient.DeleteAllMessages();
            }
            //to remove user call /TestRemoveDefaultTestUser.cmd using POST request
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {//clean all messages

            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        [Test]
        public void CheckImap()
        {
            using (var emailClient = CreateCleint())
            {
                for (int i = 0; i < 20; i++)
                {
                    foreach (var message in emailClient.SearchMessages(SearchCondition.Undeleted(), true))
                    {
                        var body = message.Value.Body;
                        //check activation link here
                        //if (body)
                    }
                    //Thread.Sleep();
                }
            }
        }
    }
}
