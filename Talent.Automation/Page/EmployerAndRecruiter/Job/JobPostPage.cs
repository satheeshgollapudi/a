using System;
using MVPStudio.Framework.Config;
using MVPStudio.Framework.Extensions;
using OpenQA.Selenium;
using Talent.Automation.Model;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page.EmployerAndRecruiter.Job
{
    public class JobPostPage : Base
    {
        public JobPostPage(IWebDriver driver) : base(driver) {}

        private IWebElement Company => Driver.WaitForElement(By.Id("jobPost_company"));
        private IWebElement Title => Driver.WaitForElement(By.Id("jobPost_title"));
        private IWebElement Summary => Driver.WaitForElement(By.Id("jobPost_summary"));
        private IWebElement Description => Driver.WaitForElement(By.CssSelector("#jobPost_description > .ql-container.ql-bubble > .ql-editor"));
        private IWebElement Category => Driver.WaitForElement(By.CssSelector("#jobPost_category > div"));
        private IWebElement SubCategory => Driver.WaitForElement(By.CssSelector("#jobPost_subCategory > div"));
        private IWebElement YearsOfExperience => Driver.WaitForElement(By.Id("jobPost_experience"));
        private static By QualificationTypes => By.CssSelector("#jobPost_qualification > .ant-checkbox-group-item > .ant-checkbox input");
        private static By VisaStatusTypes => By.CssSelector("#jobPost_visaStatus  > .ant-checkbox-group-item > .ant-checkbox input");
        private static By JobTypes => By.CssSelector("#jobPost_jobType > .ant-checkbox-group-item > .ant-checkbox input");
        private readonly string _salaryRangeXPathPrefix = "//label[@for='jobPost_salaryRange']/parent::div/following-sibling::div/descendant::div";
        private IWebElement SalaryRangeSlider => Driver.WaitForElement(By.XPath($"{_salaryRangeXPathPrefix}[@class='ant-slider-rail']"));
        private IWebElement MaximumSalaryCap => Driver.WaitForClickable(By.XPath($"{_salaryRangeXPathPrefix}[contains(@class, 'ant-slider-handle-2')]"));
        private IWebElement MinimumSalaryCap => Driver.WaitForClickable(By.XPath($"{_salaryRangeXPathPrefix}[contains(@class, 'ant-slider-handle-1')]"));
        private IWebElement Country => Driver.WaitForElement(By.CssSelector("#jobPost_country > div"));
        private IWebElement City => Driver.WaitForElement(By.CssSelector("#jobPost_city > div"));
        private IWebElement StartDate => Driver.WaitForElement(By.CssSelector("input[placeholder='Start Date']")); // does not have id
        private IWebElement EndDate => Driver.WaitForElement(By.CssSelector("#jobPost_endDate input"));
        private IWebElement ExpiryDate => Driver.WaitForElement(By.CssSelector("#jobPost_expiryDate input"));
        private IWebElement Save => Driver.WaitForClickable(By.XPath("//button[.='Save']"));
        private IWebElement Cancel => Driver.WaitForClickable(By.XPath("//button[.='Cancel']"));

        public void Open()
        {
            Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "jobs/post"));
            Driver.WaitForPageLoaded("Post a Job");
        }

        public JobsPage PostAJob(JobPost jobPost, bool createFlag = true)
        {
            EnterJobDetails(jobPost);
            if (createFlag)
            {
                return ClickSave();
            }
            return ClickCancel();
        }

        public JobsPage ClickSave()
        {
            Save.Click();
            return new JobsPage(Driver);
        }

        public JobsPage ClickCancel()
        {
            Cancel.Click();
            return new JobsPage(Driver);
        }

        public void EnterJobDetails(JobPost jobPost)
        {
            if (jobPost == null)
            {
                return;
            }
            // Text fields
            Company.EnterText(jobPost.Company);
            Title.EnterText(jobPost.Title);
            Summary.EnterText(jobPost.Summary);
            Description.EnterText(jobPost.Description);

            // Category and SubCategory
            Category.SelectDropDownValue(Driver, jobPost.Category);
            SubCategory.SelectDropDownValue(Driver, jobPost.SubCategory);
            // Experience
            YearsOfExperience.EnterText(jobPost.YearsOfExperience);

            // Checkbox Groups
            Driver.SelectFromCheckBoxGroup(QualificationTypes, jobPost.QualificationTypeList);
            Driver.SelectFromCheckBoxGroup(VisaStatusTypes, jobPost.VisaStatusTypeList);
            Driver.SelectFromCheckBoxGroup(JobTypes, jobPost.JobTypeList);

            // Dealing with Salary Slider field
            // only move the slider if either minimum or maximum salary is > 0
            if (jobPost.MinimumSalary > 0 || jobPost.MaximumSalary > 0)
            {
                int sliderWidth = SalaryRangeSlider.Size.Width;
                decimal minimumSalaryAmount = jobPost.MinimumSalary;
                decimal maximumSalaryAmount = jobPost.MaximumSalary;
                decimal minimumSliderOffsetValue = sliderWidth * (minimumSalaryAmount / JobPost.MaximumSalaryCap);
                decimal maximumSliderOffsetValue = sliderWidth * (maximumSalaryAmount / JobPost.MaximumSalaryCap);

                try
                {
                    int offset1 = decimal.ToInt32(minimumSliderOffsetValue);
                    int offset2 = decimal.ToInt32(maximumSliderOffsetValue);
                    MaximumSalaryCap.DragAndDrop(Driver, offset2);
                    MinimumSalaryCap.DragAndDrop(Driver, offset1);
                }
                catch (OverflowException)
                {
                    // in theory, it should never reach here since setter is ensuring that 
                    // the value cannot be greater than the maximum cap
                    throw;
                }
            }

            // Country and City
            Country.SelectDropDownValue(Driver, jobPost.Country);
            City.SelectDropDownValue(Driver, jobPost.City);

            // Date fields
            StartDate.SelectDate(Driver, jobPost.StartDate);
            EndDate.SelectDate(Driver, jobPost.EndDate);
            ExpiryDate.SelectDate(Driver, jobPost.ExpiryDate);
        }

    }
}
