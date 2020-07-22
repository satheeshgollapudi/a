using MVPStudio.Framework.Config;
using MVPStudio.Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Talent.Automation.Enums;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    public class LoginSteps : Base
    {
        public LoginSteps(IWebDriver driver) : base(driver)
        {
        }

        [Given(@"I login as '(.*)'")]
        public void LoginAs(string role)
        {
            try
            {
                _ = Enum.TryParse(role, out RoleEnum asRole);
                Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "/user/login"));
                CurrentPage = GetInstance<LoginPage>(Driver);
                CurrentPage = CurrentPage.As<LoginPage>().LoginAs(asRole);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Given(@"I login with invalid credentials")]
        public void GivenILoginWithInvalidCredentials()
        {
            Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "/user/login"));
            CurrentPage = GetInstance<LoginPage>(Driver);
            CurrentPage.As<LoginPage>().LoginWithInvalidCredentials();
        }

        [Then(@"I should receive error message ""(.*)""")]
        public void ThenIShouldReceiveErrorMessage(string message)
        {
            Assert.AreEqual(message, Driver.GetMessage());
        }

        [Then(@"I shouldn't be allowed to login to the website")]
        public void ThenIShouldnTBeAllowedToLoginToTheWebsite()
        {
            Assert.That(Driver.Title.Contains("Login", StringComparison.OrdinalIgnoreCase));
        }
    }
}
