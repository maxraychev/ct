using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CoolToolSite.Tests.Pages
{
    public class MarketPlaceQuestsPage : MarketplacePage
    {
        public MarketPlaceQuestsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Navigate().GoToUrl(MarketPlaceQuestsUrl);
        }

        public string GetHeaderText()
        {
            return FindElement(Driver, By.XPath("//h1[contains(text(), 'quests')]")).Text;
        }

    }
}
