using System.Diagnostics;
using CoolToolSite.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace CoolToolSite.Tests.Entities
{
    [Binding]
    public class WebBrowser
    {
        private static ChromeDriverService _driverService;

        public static IWebDriver Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    if (CommonHelper.GetDriver() == null)
                    {
                        ScenarioContext.Current["browser"] = new ChromeDriver();
                    }
                    else
                    {
                       switch (CommonHelper.GetDriver())
                        {
                            case "Firefox":
                                //Select Firefox browser
                                ScenarioContext.Current["browser"] = new FirefoxDriver();
                                break;

                            case "Chrome":
                                //Select Chrome browser
                                ScenarioContext.Current["browser"] = new ChromeDriver();
                                break;
                        } 
                        
                    }

                }
                return (IWebDriver)ScenarioContext.Current["browser"];
            }
        }

        

        public static ChromeDriverService CreateAndStartChromeService()
        {
            var driverPath = System.Environment.GetEnvironmentVariable("CHROMEDRIVER");
            _driverService = ChromeDriverService.CreateDefaultService(driverPath);
            _driverService.Start();
            return _driverService;
        }

        [AfterScenario()]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                Current.Quit();
            }

            if (ScenarioContext.Current.GetType() != typeof (ChromeDriver)) return;
            var aProcesses = Process.GetProcessesByName("chromedriver.exe");
            foreach (var aProcess in aProcesses)
            {
                aProcess.Kill();
            }
        }
    }
}
