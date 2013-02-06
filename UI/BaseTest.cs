using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
/*	
Правила именования элементов
	lbl - текст
    btn - кнопка
    txb - текстовое поле
    chb - чекбокс
    rbtn - радиокнопка
    link - ссылка
    lbx - список
    cmb - комбобокс

*/

namespace CoolToolSite.Tests.UI
{

    public class BaseTest
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected string id;
        protected string name;
        protected string linktext;
        protected string xpath;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            baseURL = "http://www.cooltool.com/";
            verificationErrors = new StringBuilder();
        }


        public IWebElement ById(string id)
        {
            return driver.FindElement(By.Id(id));
        }

        public IWebElement ByName(string name)
        {
            return driver.FindElement(By.Name(name));
        }

        public IWebElement ByLinkText(string linktext)
        {
            return driver.FindElement(By.LinkText(linktext));
        }

        public IWebElement ByXPath(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        #region mouse interactions
        protected void MouseOver(IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();
        }

        protected void MouseOver(By bySelector)
        {
            MouseOver(driver.FindElement(bySelector));
            Thread.Sleep(200);
        }
        protected void MouseDown(IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.ContextClick(element).Build().Perform();
        }
        protected void MouseDown(By bySelector)
        {
            MouseDown(driver.FindElement(bySelector));
            Thread.Sleep(200);
        }
        #endregion


        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception e)
            {
                // Ignore errors if unable to close the browser (Игнорировать ошибки, если не в состоянии закрыть браузер)
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void WaitForAjaxControls()
        {
            int counter = 0;
            //max wait - 15 seconds
            while (counter < 30)
            {
                if (IsElementPresent(By.CssSelector("div.controlsLoaded")))
                    return;
                Thread.Sleep(500);
            }
        }

        public static object cs { get; set; }
    }
}
