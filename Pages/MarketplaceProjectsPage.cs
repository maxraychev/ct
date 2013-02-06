using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace CoolToolSite.Tests.Pages
{
    public class MarketplaceProjectsPage : MarketplacePage
    {
        public MarketplaceProjectsPage(IWebDriver driver) : base(driver)
        {
        }

        public override void Open()
        {
            Driver.Navigate().GoToUrl(MarketPlacePreojectsUrl);
        }

        public string GetHeaderText()
        {
            return FindElement(Driver, By.XPath("//h1[contains(text(), 'projects')]")).Text;
        }


    }
}
