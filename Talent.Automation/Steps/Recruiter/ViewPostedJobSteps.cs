using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.Automation.Page;
using Talent.Automation.Page.Recruiter;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps.Recruiter
{
    class ViewPostedJobSteps: Base
    {
        private readonly IWebDriver Driver;

        public ViewPostedJobSteps(IWebDriver driver): base(driver)
        {
            this.Driver = driver;
            CurrentPage = GetInstance<DashboardPage>(Driver);
        }

        [Given(@"I hover on Job Tab")]
        public void GivenIHoverOnJobTab()
        {
            CurrentPage.As<DashboardPage>().HoverOnJobTab();
        }

        [When(@"I click on Job")]
        public void WhenIClickOnJob()
        {
           CurrentPage = CurrentPage.As<DashboardPage>().GotoPostedJobs();
        }

        [Then(@"All jobs should be listed successfully")]
        public void ThenAllJobsShouldBeListedSuccessfully()
        {
            (var totalJobs, var actualJobs) = CurrentPage.As<ViewPostedJobs>().ValidateTotalJobs();
            Assert.AreEqual(totalJobs, actualJobs);
        }

    }
}
