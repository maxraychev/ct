using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace CoolToolSite.Tests.Pages
{
    public class MyQuestsPage : HomePage
    {
        
        public MyQuestsPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement SetAsCurrentLink;


        public override void Open()
        {
            Driver.Navigate().GoToUrl(MyQuestPageUrl);
        }

        public string GetHeaderText()
        {
            return FindElement(Driver, By.XPath("//h1[contains(text(),'questionnaires')]")).Text;
        }

        public void SetQuestAsCurrentForProject(string questName)
        {
            var questlist = FindElements(Driver, By.CssSelector("a.l_tName"));
            foreach (var element in questlist.Where(element => element.Text.Contains(questName)))
            {
                MouseOver(element);
                Thread.Sleep(2000);
                GetLinkByText("set as current").Click(); 
                Thread.Sleep(1000);
                break;
            }
            
        }


    }
}
