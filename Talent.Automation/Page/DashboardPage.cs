using MVPStudio.Framework.Extensions;
using OpenQA.Selenium;
using RestSharp;
using Talent.Automation.Page.Employer.Profile;
using Talent.Automation.Page.Recruiter;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class DashboardPage : Base
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement LogoImg => Driver.WaitForElement(By.Id("logo"));
        private IWebElement TalentFeedMenu => Driver.WaitForElement(By.LinkText("Talent Feed"));
        private IWebElement ProfilePageMenu => Driver.WaitForElement(By.LinkText("Profile"));
        private IWebElement JobsMenu => Driver.WaitForElement(By.XPath("//li[contains(@class, 'ant-menu-submenu')][contains(., 'Jobs')]"));
        private IWebElement JobsSubMenu => Driver.WaitForElement(By.CssSelector("ul[id='/jobs$Menu'] > li > a[href='/jobs']"));
        private IWebElement JobsWatchListLink => Driver.WaitForElement(By.LinkText("Watch List"));
        private IWebElement JobsLink => Driver.WaitForElement(By.LinkText("Jobs"));
        private IWebElement IndexName => Driver.WaitForElement(By.CssSelector("span.antd-pro-app-src-components-global-header-index-name"));
        private IWebElement IndexMenu => Driver.WaitForElement(By.CssSelector("ul.antd-pro-app-src-components-global-header-index-menu"));

        public string DashboardPageTitle()
        {
            return Driver.Title;
        }
        public bool IsLoggedAs(string role)
        {
            if (IndexName.Text.Equals(role, System.StringComparison.OrdinalIgnoreCase) || 
                IndexName.Text.Contains(role, System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public LoginPage Logout()
        {
            IndexName.Hover(Driver);
            IndexMenu.SelectFromDropdownList(Driver, "Logout");
            return new LoginPage(Driver);
        }

        public ProfilePage GoToProfilePage()
        {
            ProfilePageMenu.Click();
            return new ProfilePage(Driver);
        }

        public JobsWatchListPage GoToJobsWatchListPage()
        {
            JobsMenu.Hover(Driver);
            JobsWatchListLink.WaitForDisplayed(Driver);
            JobsWatchListLink.Click();
            return new JobsWatchListPage(Driver);
        }

        public JobsPage GotoJobsPage()
        {
            JobsMenu.Hover(Driver);
            JobsLink.WaitForDisplayed(Driver);
            JobsLink.Click();
            return new JobsPage(Driver);
        }

        public TalentFeedPage GoToTalentFeedPage()
        {
            TalentFeedMenu.Click();
            return new TalentFeedPage(Driver);
        }

        public void HoverOnJobTab()
        {
            JobsMenu.Hover(Driver);
        }

        public ViewPostedJobs GotoPostedJobs()
        {
            JobsSubMenu.Click();
            return new ViewPostedJobs(Driver);
        }
        
        public Skill GoToEmployerProfile()
        {
            IndexName.WaitForDisplayed(Driver);
            IndexName.Hover(Driver);
            IndexMenu.SelectFromDropdownList(Driver, "Account Settings");
            return new Skill(Driver);

        }

        //TODO add page navigation to jobs post page?

    }
}
