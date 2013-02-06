using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.Pages
{
    public class LoginPage : PageObject
    {
        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        #region WebElements on Login Page

        [FindsBy(How = How.Id, Using = "txtEmail")] protected IWebElement EmailField;
        [FindsBy(How = How.Id, Using = "txtPassword")] protected IWebElement PasswordField;
        [FindsBy(How = How.Id, Using = "btnLogin")] protected IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "btnReg")] protected IWebElement SignUpButton;

        #endregion

        [FindsBy(How = How.ClassName, Using = "alertBox")]
        protected IWebElement AlertBox;

        public HomePage LoginAs(string userName, string password)
        {
            Type(EmailField, userName);
            Type(PasswordField, password);
            LoginButton.Click();
            return new HomePage(Driver);
        }

        public SignUpFrame OpenSignUpDialog()
        {
            SignUpButton.Click();
            return new SignUpFrame(Driver);
        }

        public string GetAlertBoxText()
        {
            return AlertBox.Text;
        }


        public IWebElement GetLoginFrame()
        {
            Driver.FindElement(By.ClassName("containerbg")).FindElement(By.XPath("//*[contains(text(),'Ok')]")).Click();
            return Driver.FindElement(By.Id("logEmail"));
        }

        public bool IsLoginFrameExists()
        {
            return IsElementPresent(GetLoginFrame());
        }


        public override void Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrl"]);
        }

    }
}
