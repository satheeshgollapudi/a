using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.Automation.Steps.BaseStep;
using MVPStudio.Framework.Extensions;

namespace Talent.Automation.Page.Recruiter
{
    /// <summary>
    /// ViewPostedJobs class represents the recruiter posted jobs 
    /// </summary>
    public class ViewPostedJobs: Base
    {
        private readonly IWebDriver Driver;
        public ViewPostedJobs(IWebDriver driver) : base(driver)
        {
            this.Driver = driver;
        }

        #region Initialize the web elements
        private IWebElement Jobs => Driver.WaitForElement(By.CssSelector(".ant-spin-container .ant-row"));
        private IList<IWebElement> Pagination => Driver.WaitForElements(By.CssSelector("ul[class='ant-pagination'] > li"));
        #endregion


        //This method returns the total jobs and actual jobs based on the info from UI.  
        public (int, int) ValidateTotalJobs()
        {
            if (Jobs.Displayed && Jobs.Enabled)
            {
                var text = Driver.WaitForElement(By.CssSelector("main .ant-row > p")).Text;
                var totalJobs = Int16.Parse(text.Split(" ")[3]);
                Console.WriteLine("Jobs at my account: " + totalJobs);
                if(Pagination.Count > 3)
                {
                    Pagination[Pagination.Count - 2].Click();
                    var len = Driver.WaitForElements(By.CssSelector(".ant-spin-container .ant-row > .ant-col")).Count;
                    var actual = 6 * (Pagination.Count - 3) + len;
                    Console.WriteLine("Total length: " + actual);

                    return (totalJobs, actual);
                }
                else
                {
                    throw new Exception("No jobs are posted by you at this stage!!!");
                } 
            }
            return (0, -1);
        }
    }
}
