using MVPStudio.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class JobsPage : Base
    {
        public JobsPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Filter => Driver.WaitForElement(By.CssSelector("div.ant-collapse-header svg[data-icon = 'right']"));
        private IWebElement JobTitleTxtBox => Driver.WaitForElement(By.CssSelector("input[placeholder = 'Search Job Title']"));
        private IWebElement JobDescTxtBox => Driver.WaitForElement(By.CssSelector("input[placeholder = 'Search Job Description']"));
        private IWebElement ResetBtn => Driver.WaitForElement(By.XPath("//button[contains(., 'Reset')]"));
        private IWebElement ApplyFilterBtn => Driver.WaitForElement(By.CssSelector("button.ant-btn-primary"));
        private IWebElement FirstJobInList => Driver.WaitForElement(By.CssSelector("div.ant-card-body"), 20);
        private IWebElement FirstJobTitle => FirstJobInList.FindElement(By.CssSelector("h4.ant-list-item-meta-title span:first-child"));
        private IWebElement FirstJobStatus => FirstJobInList.FindElement(By.CssSelector("h4.ant-list-item-meta-title span.ant-tag"));
        private IWebElement FirstJobDesc => FirstJobInList.FindElement(By.CssSelector("div.antd-pro-app-src-pages-job-common-job-list-jobSummary div"));
        private IWebElement FirstJobSwitch => FirstJobInList.FindElement(By.XPath("//ul[@class='ant-card-actions']/li[2]/span/div/span"));
        private IWebElement FirstJobSwitchIcon => FirstJobInList.FindElement(By.XPath("//ul[@class='ant-card-actions']/li[2]//i"));
        private IList<IWebElement> Cards => Driver.WaitForElements(By.CssSelector("div.ant-card-body"));

        public string JobsPageTitle()
        {
            return Driver.Title;
        }

        public string ReturnFirstJobTitle()
        {
            return FirstJobTitle.Text;
        }

        public string ReturnFirstJobDesc()
        {
            return FirstJobDesc.Text;
        }
        public string ReturnFirstJobStatusText()
        {
            return FirstJobStatus.Text;
        }
        public string ReturnFirstJobStatusColor()
        {
            return FirstJobStatus.GetCssValue("background-color");
        }
        public string ReturnFirstJobSwitchText()
        {
            return FirstJobSwitch.Text;
        }
        public string ReturnFirstJobSwitchIcon()
        {
            return FirstJobSwitchIcon.GetAttribute("aria-label");
        }
        public void ClickFirstJobSwitch()
        {
            FirstJobSwitch.Click();
        }
        public string ReturnFirstListJobTitle()
        {
            return FirstJobInList.Text;
        }

        public void ClickFilter()
        {
            Filter.Click();
        }

        public void SearchByJobTitle(string jobTitle)
        {
            Filter.Click();
            JobTitleTxtBox.SendKeys(jobTitle);
            ApplyFilterBtn.WaitForClickable(Driver);
            ApplyFilterBtn.Click();
        }

        public string ReturnJobTitle(IWebElement card)
        {
            if (card != null)
            {
                string title = card.FindElement(By.CssSelector("h4.ant-list-item-meta-title span:first-child")).GetInnerText(Driver);
                System.Console.WriteLine("jobtitle is " + title);
                return title;
            }
            throw new ArgumentNullException($"{nameof(card) is null}");
        }

        public bool ValidateResultByTitle(IDictionary<string, string> filter)
        {
            foreach (var card in Cards)
            {
                if (ReturnJobTitle(card).Contains(filter["jobTitle"], StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                return false;
            }
            return true;
        }

        public bool SearchResultByTitle(string jobTitle)
        {
            foreach (var card in Cards)
            {
                var foundJobtitle = ReturnJobTitle(card);
                Console.WriteLine("title is" + foundJobtitle);
                if (foundJobtitle.Equals(jobTitle, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Found matching title");
                    return true;
                }
            }
            return false;
        }
    }
}
