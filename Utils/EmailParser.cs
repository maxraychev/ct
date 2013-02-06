using System.Text.RegularExpressions;

namespace CoolToolSite.Tests.Utils
{
    public static class EmailParser
    {
        //public static HtmlDocument Doc;
        public static string SearchPattern;
        public static string ConfirmationLink;


        public static string GetConfirmationLink(string emailBody)
        {
            SearchPattern = @"http[s]?://.+\?mode=verification&hash=[\w]+";
            var regex = new Regex(SearchPattern);
            MatchCollection matches = regex.Matches(emailBody);
            foreach (Match match in matches)
            {
                ConfirmationLink = match.Value;
            }
            return ConfirmationLink;
        }


    }
}
