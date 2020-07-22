using MVPStudio.Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    public class JobsSteps : Base
    {
        private readonly ScenarioContext context;

        public JobsSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            context = injectedContext;
        }

        [Given(@"I am on Jobs page")]
        public void GivenIAmOnJobsPage()
        {
            CurrentPage = GetInstance<JobsPage>(Driver);
        }

        [When(@"I add a filter search Job title '(.*)'")]
        public void WhenIAddAFilterSearchJobTitle(string jobTitle)
        {
            CurrentPage.As<JobsPage>().SearchByJobTitle(jobTitle);
        }

        [Then(@"The results should match the Job Title '(.*)'")]
        public void ThenTheResultsShouldMatchTheJobTitle(string jobTitle)
        {
            var filter = new Dictionary<string, string>
            {
                ["jobTitle"] = jobTitle
            };
            Assert.IsTrue(Driver.VerifyFilteredResults(CurrentPage.As<JobsPage>().ValidateResultByTitle, filter));
        }

        [When(@"I click the job switch button on the first job card")]
        public void WhenIClickTheJobSwitchButtonOnTheFirstJobCard()
        {
            context["statusText"] = CurrentPage.As<JobsPage>().ReturnFirstJobStatusText();
            CurrentPage.As<JobsPage>().ClickFirstJobSwitch();
        }

        [Then(@"The first job status should update and the job switch button should update")]
        public void ThenTheFirstJobStatusShouldChangeAndTheJobSwitchButtonShouldChange()
        {
            //Wait element txt/format/color updated and check the value
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

            try
            {
                var result = wait.Until(Driver =>
                 {
                     if (context["statusText"].ToString() == "Closed")
                         return (
                     CurrentPage.As<JobsPage>().ReturnFirstJobStatusText() == "Active" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobStatusColor() == "rgba(16, 142, 233, 1)" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobSwitchText() == "Close" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobSwitchIcon().Contains("stop")
                     );
                     else if (context["statusText"].ToString() == "Active")
                         return (
                     CurrentPage.As<JobsPage>().ReturnFirstJobStatusText() == "Closed" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobStatusColor() == "rgba(128, 128, 128, 1)" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobSwitchText() == "Reopen" &&
                     CurrentPage.As<JobsPage>().ReturnFirstJobSwitchIcon().Contains("check-circle")
                     );
                     else
                         return false;
                 });
                Assert.IsTrue(result);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Wait Time Out. The job status won't update successfully");
            }

        }

    }
}
