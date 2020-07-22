using MVPStudio.Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    [Scope(Feature = "JobsWatchList")]

    public class JobsWatchListSteps : Base
    {
        public JobsWatchListSteps(IWebDriver driver) : base(driver)
        {
        }

        [Given(@"I am on Jobs Watch List page")]
        public void GivenIAmOnJobsWatchListPage()
        {
            CurrentPage = GetInstance<JobsWatchListPage>(Driver);
        }

        [When(@"I add a filter search Job title '(.*)'")]
        public void WhenIAddAFilterSearchJobTitle(string jobTitle)
        {
            CurrentPage.As<JobsWatchListPage>().SearchByJobTitle(jobTitle);
        }

        [Then(@"The results should match the Job Title '(.*)'")]
        public void ThenTheResultsShouldMatchTheJobTitle(string jobTitle)
        {
            var filter = new Dictionary<string, string>
            {
                ["jobTitle"] = jobTitle
            };
            Assert.IsTrue(Driver.VerifyFilteredResults(CurrentPage.As<JobsWatchListPage>().ValidateResultByTitle, filter));
        }
    }
}
