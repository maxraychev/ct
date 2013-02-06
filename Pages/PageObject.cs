using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CoolToolSite.Tests.Pages
{
    public abstract class PageObject
    {
        protected readonly IWebDriver Driver;

        protected PageObject(IWebDriver driver)
        {
            this.Driver = driver;
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));
            PageFactory.InitElements(Driver, this);
        }

        public abstract void Open();

        public string GetPageTitle()
        {
            return Driver.Title;
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public IWebElement FindElement(IWebDriver driver, By by)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return wait.Until(d => d.FindElement(by));

        }

        public List<IWebElement> FindElements(IWebDriver driver, By by)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            return new List<IWebElement>(wait.Until(d => d.FindElements(by)));
        }

        public string GetDialogMessage()
        {
            return FindElement(Driver, By.ClassName("dlgmessage")).Text;
        }

        public IWebElement GetLinkByText(string text)
        {
            return FindElement(Driver, By.LinkText(text));
        }

        public IWebElement GetAnyElementByText(string text)
        {
            return FindElement(Driver, By.XPath("//*[contains(text(),'" + text + "')]"));
        }

        #region MouseActions

        public void MouseOver(IWebElement element)
        {
            const string js = @"$(arguments[0]).mouseover()";
            ((IJavaScriptExecutor) Driver).ExecuteScript(js, element);
        }

        #endregion
    }
}