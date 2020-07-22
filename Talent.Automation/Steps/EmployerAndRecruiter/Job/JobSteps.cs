using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MVPStudio.Framework.Config;
using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps;
using MVPStudio.Framework.Helps.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using Talent.Automation.Enums;
using Talent.Automation.Model;
using Talent.Automation.Page;
using Talent.Automation.Page.EmployerAndRecruiter.Job;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Talent.Automation.Steps.EmployerAndRecruiter.Job
{
    /// <summary>This class contains step definitions related to job post.<br/>
    /// These bindings are scoped and will only be executed if one of the following 
    /// scenario tags are present:<br/>
    /// <c>jobs</c>, <c>recruiter</c>, <c>employer</c></summary>
    [Binding, Scope(Tag = "jobs")]
    [Scope(Tag = "recruiter")]
    [Scope(Tag = "employer")]
    public class JobSteps : Base
    {
        private readonly ScenarioContext _context;
        private JobPost jobPost;
        // this is essentially mapping field label (or label-equivalent if not available)
        // and the property of the page object which repesents the page field
        private static readonly IDictionary<string, string> _fieldMapper = new Dictionary<string, string>()
        {
            { "Years of experience", "YearsOfExperience" },
            { "Start Date",  "StartDate" },
            { "End Date",  "EndDate" },
            { "Expiry Date",  "ExpiryDate" }
        };

        public JobSteps(ScenarioContext injectedContext, IWebDriver driver) : base(driver)
        {
            _context = injectedContext;
        }

        private void PerformLoginAsRecruiterOrEmployer()
        {
            // this method relies on scenario tags
            // if one of the tags is a recruiter then it will login as recruiter
            // otherwise it will login as employer
            string recruiterOrEmployer = _context.ScenarioInfo.Tags.Where(t => t == "recruiter").FirstOrDefault() ?? "employer";
            _ = Enum.TryParse(recruiterOrEmployer, out RoleEnum enumRole);
            Driver.Navigate().GoToUrl(new Uri($"{Settings.AUT}user/login"));
            CurrentPage = GetInstance<LoginPage>(Driver);
            CurrentPage = CurrentPage.As<LoginPage>().LoginAs(enumRole);
        }

        [Given(@"I am on Job post page")]
        public void GivenIAmOnJobPostPage()
        {
            PerformLoginAsRecruiterOrEmployer();

            // navigate to job post page
            CurrentPage = GetInstance<JobPostPage>(Driver);
            CurrentPage.As<JobPostPage>().Open();

            // load any data here
            ExcelUtil.SetDataSource("Job.xlsx");
            // would be nice to perhaps make use of tags to programmatically grab the data without having to
            // specify a specific row to grab from the spreadsheet
            jobPost = ObjectFactory.CreateInstance<JobPost>(ExcelUtil.DataSet.SelectSheet("ADD").GetRowByKey("Valid"));
        }

        [When(@"I post a new job")]
        public void WhenIPostANewJob()
        {
            CurrentPage = CurrentPage.As<JobPostPage>().PostAJob(jobPost); // updated to new page
        }

        [Then(@"the job management page displays the newly added job")]
        public void ThenTheJobManagementPageDisplaysTheNewlyAddedJob()
        {
            Driver.WaitForPageLoaded("Jobs");
            Assert.IsTrue(CurrentPage.As<JobsPage>().SearchResultByTitle(jobPost.Title));
        }

        [When(@"I cancel posting a new job")]
        public void WhenICancelPostingANewJob()
        {
            CurrentPage = CurrentPage.As<JobPostPage>().PostAJob(jobPost, false);
        }

        [Then(@"the job is not posted")]
        public void ThenTheJobIsNotPosted()
        {
            // still on the same job post page, user is not redirected to the jobs managemenet page
            Assert.That(Driver.Url, Is.EqualTo($"{Settings.AUT}jobs/post"));
        }

        [When(@"I post a new job without entering any data")]
        public void WhenIPostANewJobWithoutEnteringAnyData()
        {
            // passing in null skips entering form details
            CurrentPage.As<JobPostPage>().PostAJob(null, true);
        }

        [Then(@"all the mandatory fields are highlighted in red with appropriate error messages")]
        public void ThenAllTheMandatoryFieldsAreHighlightedInRedWithAppropriateErrorMessages()
        {
            // expecting 12 mandatory fields on screen
            Assert.That(Driver.GetAllFieldValidationMessages().Count, Is.EqualTo(12));
        }

        [When(@"I fill out a job post with a requirement of '(.*)' years of experience")]
        public void WhenIFillOutAJobPostWithARequirementOfYearsOfExperience(string yearsOfExperience)
        {
            // trick is to unset all the fields
            // and leave years of experience only
            jobPost = new JobPost
            {
                YearsOfExperience = yearsOfExperience,
                StartDate = null,
                ExpiryDate = null
            };
            CurrentPage.As<JobPostPage>().PostAJob(jobPost, true);
        }

        [Then(@"the years of experience is converted to '(.*)'")]
        public void ThenTheYearsOfExperienceIsConvertedTo(string yearsOfExperience)
        {
            Assert.That(CurrentPage.As<JobPostPage>().GetFieldValue(_fieldMapper["Years of experience"]), Is.EqualTo(yearsOfExperience));
        }

        [When(@"I post a new job with '(.*)' for '(.*)'")]
        public void WhenIPostANewJobWithFor(string value, string fieldName)
        {
            // not using SpecFlow Table
            // have to rely on reflection here
            PropertyInfo propertyInfo = jobPost.GetType().GetProperty(fieldName);
            propertyInfo.SetValue(jobPost, value, null);

            CurrentPage.As<JobPostPage>().PostAJob(jobPost, true);
        }

        [When(@"I fill out a job post with the following details:")]
        public void WhenIFillOutAJobPostWithTheFollowingDetails(Table table)
        {
            jobPost = new JobPost
            {
                StartDate = null,
                ExpiryDate = null
            };
            table.FillInstance(jobPost);
            CurrentPage.As<JobPostPage>().PostAJob(jobPost);
        }

        [Then(@"those date fields are not changed")]
        public void ThenThoseDateFieldsAreNotChanged()
        {
            Assert.Multiple(() =>
            {
                var today = DateTime.Today;
                Assert.That(CurrentPage.As<JobPostPage>().GetFieldValue(_fieldMapper["Start Date"]),
                            Is.EqualTo(today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
                Assert.True(string.IsNullOrEmpty(CurrentPage.As<JobPostPage>().GetFieldValue(_fieldMapper["End Date"])));
                Assert.That(CurrentPage.As<JobPostPage>().GetFieldValue(_fieldMapper["Expiry Date"]),
                            Is.EqualTo(today.AddDays(14).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            });
        }

        [Then(@"the error message '(.*)' is displayed")]
        public void ThenTheErrorMessageIsDisplayed(string expectedError)
        {
            Assert.Contains(expectedError, Driver.GetAllFieldValidationMessages());
        }

        [When(@"I post a new job with a requirement of '(.*)' years of experience")]
        public void WhenIPostANewJobWithARequirementOfYearsOfExperience(string yearsOfExperience)
        {
            jobPost.YearsOfExperience = yearsOfExperience;
            CurrentPage.As<JobPostPage>().PostAJob(jobPost, true);
        }

        [Then(@"the job management page does not display the newly added job")]
        public void ThenTheJobManagementPageDoesNotDisplayTheNewlyAddedJob()
        {
            Assert.Multiple(() =>
            {
                // Verify that user is back on Jobs management page
                // TC-419 has been logged
                // once that has been completed, this needs to be revisited to changed
                Assert.That(Driver.Url, Is.EqualTo($"{Settings.AUT}jobs"));
                // no matching title
                Assert.IsFalse(CurrentPage.As<JobsPage>().SearchResultByTitle(jobPost.Title));
            });
        }

    }
}
