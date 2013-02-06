using System;
using System.Linq;
using System.Text.RegularExpressions;
using AE.Net.Mail;

namespace CoolToolSite.Tests.Utils
{
    public static class EmailClient
    {
        public static MailMessage ConfirmationEmail;
        public static string ConfirmationLink;
        public static string SearchPattern;

        public static ImapClient ConnectToGmail(string email, string password)
        {
            var client = new ImapClient("imap.gmail.com", email, password, ImapClient.AuthMethods.Login, 993, true);
            //client.SelectMailbox("INBOX");
            return client;
            
        }

        /// <summary>
        /// Delete all messages
        /// </summary>
        /// <param name="client">IMAP client</param>
        public static void DeleteAllMessages(this ImapClient client)
        {
            var messages =  client.GetMessages(0, 1000);
            foreach (var msg in messages)
            {
                client.DeleteMessage(msg);
            }
        }

        public static string GetConfirmationLink(this ImapClient client)
        {
            var mm = client.GetMessages(0, 1000, false, true);
            foreach (var mailMessage in mm)
            {
                SearchPattern = @"http[s]?://.+\?mode=verification&hash=[\w]+";
                var regex = new Regex(SearchPattern);
                MatchCollection matches = regex.Matches(mailMessage.Body);
                foreach (Match match in matches)
                {
                    ConfirmationLink = match.Value;
                    break;
                }
            }
            return ConfirmationLink;           
        }


        //public void GetMail()
        //{
        //    using (var imap = new ImapClient(Host, Login, Password, AE.Net.Mail.ImapClient.AuthMethods.Login, Port, UseSSL))
        //    {
        //        var msgs = imap.SearchMessages(
        //          SearchCondition.Undeleted().And(
        //            SearchCondition.From("david"),
        //            SearchCondition.SentSince(new DateTime(2000, 1, 1))
        //          ).Or(SearchCondition.To("andy"))
        //        );

        //        Assert.AreEqual(msgs[0].Value.Subject, "This is cool!");

        //        imap.NewMessage += (sender, e) =>
        //        {
        //            var msg = imap.GetMessage(e.MessageCount - 1);
        //            Assert.AreEqual(msg.Subject, "IDLE support?  Yes, please!");
        //        };
        //    }
        //}
    }
}
