using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.Pages
{
    public class ProjectPage : HomePage
    {
        public ProjectPage(IWebDriver driver)
            : base(driver)
        {
        }

        #region Elements on Home Page

        protected IWebElement LaunchProjectButton;

        protected IWebElement ActivationReminder;

        protected IWebElement LaunchConfirmationPopup;

        protected IWebElement ConfirmProjectButton;

        protected IWebElement ProjectLaunchedAlertBox;

        protected IWebElement ProjectStatusIndicator;

        protected IWebElement ProjectNameField;

        protected IWebElement QuestionnarieLink;

        public string ProjectStatusIndicatorText; 
        #endregion

        public override void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetProjectName()
        {
            ProjectNameField = FindElement(Driver, By.ClassName("editableNameH"));
            return ProjectNameField.Text;
        }

        public string GetProjectStatusIndicatorText()
        {

            return FindElement(Driver, By.CssSelector("div.fr.tar")).Text;
        }

        public IWebElement GetNoQuestionnarieLink()
        {
            QuestionnarieLink = FindElement(Driver, By.XPath("//*[contains(@href, 'questlist?project')]"));
            return QuestionnarieLink;
        }

        public bool IsNoQuestionnarieSet()
        {
            return IsElementPresent(GetNoQuestionnarieLink());
        }

        public MyQuestsPage OpenMyQuestList()
        {
            GetNoQuestionnarieLink().Click();
            return new MyQuestsPage(Driver);
        }

        public void LaunchProject()
        {
            Thread.CurrentThread.Join(1000);
            FindElement(Driver,By.CssSelector(".btn#launch")).Click();
            //LaunchProjectButton.Click();
        }

        public string LauchProjectAfterActivation()
        {
            LaunchProject();
            //FindElement(Driver, By.Id("launch")).Click();
            //LaunchConfirmationPopup = FindElement(Driver, By.ClassName("ppopup_wizard"));
            ConfirmProjectButton = FindElement(Driver, By.Id("confirmProject"));
            ConfirmProjectButton.Click();
            Thread.Sleep(1000);
            var alertBoxText = FindElement(Driver, By.ClassName("alertBox")).Text;
            DismissAlertBox();
            
            ProjectStatusIndicatorText = GetProjectStatusIndicatorText();
            return alertBoxText;

        }


        public string GetActivationReminderText()
        {
            ActivationReminder = FindElement(Driver, By.ClassName("activation-reminder"));
            return ActivationReminder.Text;
        }

        public void DismissAlertBox()
        {
            ((IJavaScriptExecutor) Driver).ExecuteScript("$('button.btn')[2].click()");
        }

    }
}