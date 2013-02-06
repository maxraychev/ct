using System;
using CoolToolSite.Tests.Entities;
using CoolToolSite.Tests.Utils;
using NUnit.Core;
using NUnit.Framework;

namespace CoolToolSite.Tests.SanityTests
{
    [TestFixture, Description("Suite of acceptance tests for CoolTool")]
    public class AllTests
    {
        [Suite]
        public static TestSuite Suite
        {
            get
            {
                TestSuite suite = new TestSuite("Sanity Tests");
                suite.Add(new Features.SignUp.CorrectSignUpFeature());
                suite.Add(new Features.Project.SetUpAndLaunchNewProjectFeature());
                suite.Add(new Features.Questionnarie.BuyQuestionnarieFeature());
                suite.Add(new Features.Project.AddQuestToProjectFeature());
                suite.Add(new Features.Project.BuyProjectFeature());

                //suite.Add(new Features.SignUp.ValidateConnfirmationFeature());
                //suite.Add(new Features.Login.IncorrectLoginValidationFeature());
                //suite.Add(new Features.Login.CorrectLoginFeature());
                return suite;
            }
            set { throw new NotImplementedException(); }
        }

        [TestCase("Firefox")]
        [TestCase("Chrome")]
        public static void RunAll(string driver)
        {
            CommonHelper.SetDriver(driver);
            var suite = AllTests.Suite;
            suite.Run(new NullListener(), TestFilter.Empty);
        }

        
        
    }
}
