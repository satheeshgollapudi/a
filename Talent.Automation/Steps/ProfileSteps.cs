using MVPStudio.Framework.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    public class ProfileSteps : Base
    {
        private readonly ScenarioContext context;

        public ProfileSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            context = injectedContext;
        }

        [Given(@"I am on Profile Page")]
        public void GivenIAmOnProfilePage()
        {
            CurrentPage = GetInstance<ProfilePage>(Driver);
        }

        [When(@"I edit and save Primary Contact Details as '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenIEditAndSavePrimaryContactDetailsAs(string firstName, string lastName, string email, string phone)
        {
            CurrentPage.As<ProfilePage>().UpdatePrimaryContactDetails(
            firstName, lastName, email, phone);
        }

        [Then(@"I should see the profile page display the updated contact details '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIShouldSeeTheProfilePageDisplayTheUpdatedContactDetails(string firstName, string lastName, string email, string phone)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Concat(firstName, " ", lastName),
                    CurrentPage.As<ProfilePage>().ReturnName());
                Assert.AreEqual(email, CurrentPage.As<ProfilePage>().ReturnEmail());
                Assert.AreEqual(phone, CurrentPage.As<ProfilePage>().ReturnPhone());
            });

        }

        [Given(@"I reset Primary Contact Details as '(.*)'")]
        public void GivenIResetPrimaryContactDetailsAs(string key)
        {
            CurrentPage.As<ProfilePage>().ResetContactDetails(key);
        }

        [When(@"I edit and save Address as '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void WhenIEditAndSaveAddressAs(string number, string street, string suburb, string country,
                   string city, string postcode)
        {
            CurrentPage.As<ProfilePage>().UpdateAddress(number, street, suburb, country, city, postcode);
        }

        [Then(@"I should see the profile page display the updated address '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIShouldSeeTheProfilePageDisplayTheUpdatedAddress(string number, string street, string suburb, string country,
            string city, string postcode)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Concat(number, " ",
                    street, ", ", suburb),
                    CurrentPage.As<ProfilePage>().ReturnAddress1());
                Assert.AreEqual(string.Concat(city, ", ", country, ", ", postcode),
                    CurrentPage.As<ProfilePage>().ReturnAddress2());
            });
        }


        [Given(@"I reset Address as '(.*)'")]
        public void GivenIResetAddressAs(string key)
        {
            CurrentPage.As<ProfilePage>().ResetAddressDetails(key);
        }

        [When(@"I edit and save nationality as '(.*)'")]
        public void WhenIEditAndSaveNationalityAs(string nationality)
        {
            CurrentPage.As<ProfilePage>().UpdateNationality(nationality);
        }

        [Then(@"I should see the profile page display the updated nationality '(.*)'")]
        public void ThenIShouldSeeTheProfilePageDisplayTheUpdatedNationality(string nationality)
        {
            Assert.AreEqual(nationality, CurrentPage.As<ProfilePage>().ReturnNationality());
        }

        [Given(@"I reset Nationality as '(.*)'")]
        public void GivenIResetNationalityAs(string key)
        {
            CurrentPage.As<ProfilePage>().ResetNationality(key);
        }

        [When(@"I edit and save Social Media Accounts As '(.*)' '(.*)'")]
        public void WhenIEditAndSaveSocialMediaAccountsAs(string linkedinAccount, string githubAccount)
        {
            CurrentPage.As<ProfilePage>().UpdateSocialMediaAccounts(linkedinAccount, githubAccount);
        }

        [Then(@"I should see the profile page display the updated Social Media Accounts '(.*)' '(.*)'")]
        public void ThenIShouldSeeTheProfilePageDisplayTheUpdatedSocialMediaAccounts(string linkedinAccount, string githubAccount)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(linkedinAccount, CurrentPage.As<ProfilePage>().ReturnLinkedInAccount());
                Assert.AreEqual(githubAccount, CurrentPage.As<ProfilePage>().ReturnGitHubAccount());
            });
        }

        [Given(@"I reset Social Media Acccounts as '(.*)'")]
        public void GivenIResetSocialMediaAcccountsAs(string key)
        {
            CurrentPage.As<ProfilePage>().ResetSocialMediaAccounts(key);
        }

        [When(@"I add a new skill '(.*)' '(.*)'")]
        public void WhenIAddANewSkill(string skillName, string skillLevel)
        {
            CurrentPage.As<ProfilePage>().AddSkill(skillName, skillLevel);
        }

        [Then(@"I should see the skill '(.*)' '(.*)' in the Skill list")]
        public void ThenIShouldSeeTheSkillInTheSkillList(string skillName, string skillLevel)
        {
            Assert.IsTrue(CurrentPage.As<ProfilePage>().ValidateSkills(skillName, skillLevel));
        }

        [Given(@"I delete the skill '(.*)'")]
        public void GivenIDeleteTheSkill(string skillName)
        {
            CurrentPage.As<ProfilePage>().DeleteSkill(skillName);
        }

        [When(@"I update the skill '(.*)' to '(.*)' '(.*)'")]
        public void WhenIUpdateTheSkillTo(string skillName, string updatedSkillName, string updatedSkillLevel)
        {
            CurrentPage.As<ProfilePage>().EditSkill(skillName, updatedSkillName, updatedSkillLevel);
        }

        [Then(@"I should not see the skill '(.*)' '(.*)' in the skill list")]
        public void ThenIShouldNotSeeTheSkillInTheSkillList(string skillName, string skillLevel)
        {
            Assert.IsFalse(CurrentPage.As<ProfilePage>().ValidateSkills(skillName, skillLevel));
        }

        [Then(@"I should see error message '(.*)'")]
        public void ThenIShouldSeeErrorMessage(string errorMessage)
        {
            Console.WriteLine(Driver.GetMessage());
            Assert.That(Driver.GetMessage().Contains(errorMessage, StringComparison.OrdinalIgnoreCase));
        }

    }
}