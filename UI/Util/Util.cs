using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CoolToolSite.Tests.UI.Util
{
    public static class Util
    {
        public static void MouseOver(IWebDriver driver, IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();
        }

        public static void MouseOver(IWebDriver driver, By bySelector)
        {
            MouseOver(driver, driver.FindElement(bySelector));
            Thread.Sleep(100);
        }
        public static void MouseDown(IWebDriver driver, IWebElement element)
        {
            Actions builder = new Actions(driver);
            builder.ContextClick(element).Build().Perform();
        }
        public static void MouseDown(IWebDriver driver, By bySelector)
        {
            MouseDown(driver, driver.FindElement(bySelector));
            Thread.Sleep(1000);
        }

        public static void WaitForElement(this IWebDriver driver, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>((d) =>
            {
                try
                {
                    if (d.FindElement(by).Displayed)
                        return true;
                    else
                        return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }

            });
        }
    }
}
