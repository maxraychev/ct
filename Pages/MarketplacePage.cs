using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CoolToolSite.Tests.Pages
{
    public class MarketplacePage : HomePage
    {
        protected static string MarketPlaceUrl = ConfigurationManager.AppSettings["BaseUrl"] + "/market";
        protected string MarketPlacePreojectsUrl = MarketPlaceUrl + "?items=projects";
        protected string MarketPlaceQuestsUrl = MarketPlaceUrl + "?items=quests";

        public MarketplacePage(IWebDriver driver) : base(driver)
        {
        }

        //protected IWebElement ProjectsLink;

        public MarketplaceProjectsPage OpenMarketPlaceProjects()
        {
            FindElement(Driver, By.LinkText("Projects")).Click();
            return new MarketplaceProjectsPage(Driver);
        }


        public MarketPlaceQuestsPage OpenMarketPlaceQuestsPage()
        {
            FindElement(Driver,By.LinkText("Questionnaires")).Click();
            return new MarketPlaceQuestsPage(Driver);
        }



        public void BuyItemByName(string name)
        {
            FindElement(Driver, By.LinkText(name)).Click();
            FindElement(Driver, By.XPath("//*[contains(text(), 'Buy')]")).Click();

        }






        public override void Open()
        {
            Driver.Navigate().GoToUrl(MarketPlaceUrl);
        }
    }
}
