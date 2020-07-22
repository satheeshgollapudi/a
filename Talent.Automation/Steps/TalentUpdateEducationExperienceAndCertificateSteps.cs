using MVPStudio.Framework.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    public class TalentUpdateEducationExperienceAndCertificateSteps : Base

    {
        public TalentUpdateEducationExperienceAndCertificateSteps(IWebDriver driver) : base(driver)
        {
        }



        [Given(@"I have logined in GTIO as a talent")]
        public void GivenIHaveLoginedInGTIOAsATalent()
        {

            // navigate to login page
            Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "user/login"));
            Driver.Manage().Window.Maximize();
            LoginSteps loginSteps = new LoginSteps(Driver);
            loginSteps.LoginAs("talent");


        }

        [Given(@"I have navigated to the profile page")]
        public void GivenIHaveNavigatedToTheProfilePage()
        {

            Driver.FindElement(By.LinkText("Profile")).Click();


        }

        [Then(@"I should able to update my Education information")]
        public void ThenIShouldAbleToUpdateMyEducationInformation()
        {

            ProfilePage profilePage = new ProfilePage(Driver);
            profilePage.AddEducation();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("//div[@class='ant-message-custom-content ant-message-success'][contains(.,'Added record')]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.EditEducation();

            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Updated Education')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.DeleteEducation();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Deleted')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

        }

        [Then(@"I should able to update my experience information")]
        public void ThenIShouldAbleToUpdateMyExperienceInformation()
        {
            Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "profile"));

            ProfilePage profilePage = new ProfilePage(Driver);
            profilePage.AddExperience();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("//div[@class='ant-message-custom-content ant-message-success'][contains(.,'Added record')]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.EditExperience();

            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Updated Experience')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.DeleteExperience();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Deleted')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

        }

        [Then(@"I should able to update my certificate information")]
        public void ThenIShouldAbleToUpdateMyCertificateInformation()
        {
            Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "profile"));
            ProfilePage profilePage = new ProfilePage(Driver);
            profilePage.AddCertificate();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("//div[@class='ant-message-custom-content ant-message-success'][contains(.,'Added record')]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.EditCerticate();

            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Updated Certificate')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

            profilePage.DeleteCerticate();
            try
            {
                var spanTex = Driver.FindElement(By.XPath("(//span[contains(.,'Deleted')])[2]")).Text;
                Assert.IsNotEmpty(spanTex);
            }
            catch (Exception e)
            {
                _ = e.Message;
            }

        }


    }

}

