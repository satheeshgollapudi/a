using MVPStudio.Framework.Config;
using MVPStudio.Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Talent.Automation.Page;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps.BaseStep
{
    [Binding]
    public class NavigationSteps : Base
    {
        public NavigationSteps(IWebDriver driver) : base(driver)
        {
        }

        [Given(@"I navigate to '(.*)' page")]
        public void GivenINavigateToPage(string page)
        {
            switch (page)
            {
                case "login":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "user/login"));
                    Driver.WaitForPageLoaded("login");
                    break;

                case "dashboard":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "dashboard"));
                    Driver.WaitForPageLoaded("dashboard");
                    break;

                case "profile":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "profile"));
                    Driver.WaitForPageLoaded("profile");
                    break;

                case "jobs watch list":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "jobs/watchList"));
                    Driver.WaitForPageLoaded("Watch List");
                    break;

                case "jobs":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "jobs"));
                    Driver.WaitForPageLoaded("jobs");
                    break;

                case "talent feed":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "talentFeed"));
                    Driver.WaitForPageLoaded("Talent Feed");
                    break;

                case "article scheduler":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "onboarding/article/scheduler"));
                    Driver.WaitForPageLoaded("scheduler");
                    break;

                case "manage article":
                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "onboarding/article"));
                    Driver.WaitForPageLoaded("article");
                    break;


                default:
                    break;
            }
        }

        [Then(@"I should be navigated to '(.*)' page")]
        public void ThenIShouldBeNavigatedToPage(string pageName)
        {
            switch (pageName)
            {
                case "login":
                    CurrentPage = GetInstance<LoginPage>(Driver);
                    Assert.That(CurrentPage.As<LoginPage>().LoginPageTitle().Contains("Login", StringComparison.OrdinalIgnoreCase));
                    break;

                case "dashboard":
                    CurrentPage = GetInstance<DashboardPage>(Driver);
                    Assert.That(CurrentPage.As<DashboardPage>().DashboardPageTitle().Contains("Dashboard", StringComparison.OrdinalIgnoreCase));
                    break;

                case "profile":
                    CurrentPage = GetInstance<ProfilePage>(Driver);
                    Assert.That(CurrentPage.As<ProfilePage>().ProfilePageTitle().Contains("Profile", StringComparison.OrdinalIgnoreCase));
                    break;

                case "jobs watch list":
                    CurrentPage = GetInstance<JobsWatchListPage>(Driver);
                    Assert.That(CurrentPage.As<JobsWatchListPage>().JobsWatchListPageTitle().Contains("Watch List", StringComparison.OrdinalIgnoreCase));
                    break;

                case "jobs":
                    CurrentPage = GetInstance<JobsPage>(Driver);
                    Console.WriteLine(Driver.Title);
                    Assert.That(CurrentPage.As<JobsPage>().JobsPageTitle().Contains("Jobs", StringComparison.OrdinalIgnoreCase));
                    break;
                case "talent feed":
                    CurrentPage = GetInstance<TalentFeedPage>(Driver);
                    Assert.That(CurrentPage.As<TalentFeedPage>().TalentFeedPageTitle().Contains("Talent Feed", StringComparison.OrdinalIgnoreCase));
                    break;

                case "add article scheduler":
                    CurrentPage = GetInstance<ArticleShedulerPage>(Driver);
                    Assert.That(CurrentPage.As<ArticleShedulerPage>().ArticleShedulerPageTitle().Contains("scheduler", StringComparison.OrdinalIgnoreCase));
                    break;

                //case "edit article scheduler":
                //    CurrentPage = GetInstance<EditArticleSchedulerPage>(Driver);
                //    Assert.That(CurrentPage.As<EditArticleSchedulerPage>().EditArticleSchedulerPageTitle().Contains("scheduler", StringComparison.OrdinalIgnoreCase));
                //    break;

                default:
                    break;
            }


        }

        [Given(@"I refresh the page")]
        public void GivenIRefreshThePage()
        {
            Driver.Navigate().Refresh();
        }

        [Then(@"I should see success message")]
        public void ThenIShouldSeeSuccessMessage()
        {
           // Assert.IsTrue(Driver.GetSuccessMessage());
        }

    }
}