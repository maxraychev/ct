using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CoolToolSite.Tests.UI
{

    [TestFixture]
    [Ignore("Ignore a fixture")]
    public class TestLogin : BaseTest
    {
//_________________Locators__________________________________________
        private string txtEmailId = "txtEmail";
        private string txtPasswordId = "txtPassword";
        private string btnLoginId = "btnLogin";
        private string btnSignUpId = "btnReg";
        private string logoXPath = "html/body/div[1]/div[2]/div/a";
        private string IconmarketplaceXPath = "html/body/div[1]/div[3]/div/div/ul/li[7]/a/span[1]";
        private string linkHowItWorks = "HOW IT WORKS";
        private string linkAbout = "ABOUT";
        private string linkFeatures = "FEATURES";
        private string linkMarketplace = "MARKETPLACE";
        private string linkPureDigitalMarketResearchHUB = "pure digital market research HUB";
        private string linkMuchMore = "much more";
        private string btnRegisterNowItIsFreeId = "register_action";
        private string linkMarketplace2XPath = ".//*[@id='mainPlaceHolder']/div/div[4]/div[3]/span[2]/a";
        private string linkMarketplace3XPath = ".//*[@id='mainPlaceHolder']/div/div[4]/div[3]/span[4]/a";
        private string linkPrivacyPolicy = "Privacy policy";
        private string linkTermsOfUse = "Terms of use";
        private string linkContactUs = "Contact us";
        private string btnLinkedInXPath = "html/body/div[2]/div/div/div[2]/div[1]/a[1]";
        private string btnFacebookXPath = "html/body/div[2]/div/div/div[2]/div[1]/a[2]";
        private string btnTwitterXPath = "html/body/div[2]/div/div/div[2]/div[1]/a[3]";

//__________________Data_____________________________________________
        private string existentLogin = "dipsel@mail.ru";
        private string existentPassword = "test123";

        public void LoginAsUser() 
        { 
            ById(txtEmailId).SendKeys(existentLogin);      
            ById(txtPasswordId).SendKeys(existentPassword);
            ById(btnLoginId).Click();
        }
       

        [Test]
        public void TestSuccessLogin()
        { 
            driver.Navigate().GoToUrl(baseURL);
            LoginAsUser();
          //  TestLogin page = new TestLogin();
         //   PageFactory.InitElements(driver, page);
            
       /*    
                                
            ById(txtEmailId).Clear();
            ById(txtEmailId).SendKeys(existentLogin);

            ById(txtPasswordId).Clear();
            ById(txtPasswordId).SendKeys(existentPassword);

            ById(btnLoginId).Click();
            Thread.Sleep(6000);
*/         
        }

        [Test]
        public void TestElementsMainPage()
        {
            driver.Navigate().GoToUrl(baseURL);
            Assert.AreEqual("http://www.cooltool.com/features.aspx", ByLinkText(linkPureDigitalMarketResearchHUB).GetAttribute("href"));           
            Assert.AreEqual("http://www.cooltool.com/", ByXPath(logoXPath).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/howitworks.aspx", ByLinkText(linkMuchMore).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/?mode=register", ById(btnRegisterNowItIsFreeId).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/publicmarketplace.aspx", ByXPath(linkMarketplace2XPath).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/publicmarketplace.aspx", ByXPath(linkMarketplace3XPath).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/privacypolicy.aspx", ByLinkText(linkPrivacyPolicy).GetAttribute("href"));
            Assert.AreEqual("http://www.cooltool.com/termsofuse.aspx", ByLinkText(linkTermsOfUse).GetAttribute("href"));
            Assert.AreEqual("mailto:support@cooltool.com?subject=Request%20to%20CoolTool.com", ByLinkText(linkContactUs).GetAttribute("href"));
            Assert.AreEqual("http://www.linkedin.com/company/2540126?trk=tyah", ByXPath(btnLinkedInXPath).GetAttribute("href"));
            Assert.AreEqual("https://www.facebook.com/pages/CoolTool/205085392933669", ByXPath(btnFacebookXPath).GetAttribute("href"));
            Assert.AreEqual("https://twitter.com/#!/CoolToolMR", ByXPath(btnTwitterXPath).GetAttribute("href"));
            Assert.AreEqual("24px", ByXPath(IconmarketplaceXPath).GetCssValue("Height"));
            Assert.AreEqual("24px", ByXPath(IconmarketplaceXPath).GetCssValue("Width"));
            ByLinkText(linkHowItWorks).Click();
            ByLinkText(linkAbout).Click();
            ByLinkText(linkFeatures).Click();
            ByLinkText(linkMarketplace).Click();

        }

    
    }
}
