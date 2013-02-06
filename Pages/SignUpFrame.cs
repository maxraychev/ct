using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.Pages
{
    public class SignUpFrame : PageObject
    {
        public SignUpFrame(IWebDriver driver)
            : base(driver)
        {
        }

        #region SingUp Frame Web Elements

        [FindsBy(How = How.ClassName, Using = "login-frame")]
        protected IWebElement SignupFrame;

        [FindsBy(How = How.Id, Using = "Name")]
        protected IWebElement NameField;
        [FindsBy(How = How.Id, Using = "Login")]
        protected IWebElement LoginField;
        [FindsBy(How = How.Id, Using = "Password")]
        protected IWebElement PasswordField;

        [FindsBy(How = How.Id, Using = "btnRegister")]
        protected IWebElement CreateAccountButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class,'btna') and text()='Cancel']")]
        protected IWebElement CanceltButton;




        #endregion

        public void SignUpAs(string name, string login, string password)
        {
            Type(NameField,name);
            Type(LoginField, login);
            Type(PasswordField, password);
            CreateAccountButton.Click();
        }






        public override void Open()
        {
            throw new NotImplementedException();
        }
    }
}
