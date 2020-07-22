using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.Automation.Page;
using Talent.Automation.Page.Employer.Profile;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;
using MVPStudio.Framework.Extensions;
using System.Linq;
using MVPStudio.Framework.Helps.Excel;

namespace Talent.Automation.Steps.Employer.ProfileSteps
{
    public class EmployerSkillSteps : Base
    {
        private readonly ScenarioContext context;

        public EmployerSkillSteps(IWebDriver driver, ScenarioContext injectedContext, ScenarioContext scenarioContext) : base(driver)
        {
            context = injectedContext;
            CurrentPage = GetInstance<DashboardPage>(Driver);
            ExcelUtil.SetDataSource("employer.xlsx");
        }

        #region Common steps for Employer SKill:-Go to Profle and Add a skill
        [Given(@"I am on Employer Profile")]
        public void GivenIAmOnEmployerProfile()
        {
            CurrentPage = CurrentPage.As<DashboardPage>().GoToEmployerProfile();
            Assert.That(CurrentPage.As<Skill>().IsEmployerProfileTabActive());
        }

        [Given(@"I add the skill with (.*) and (.*)")]
        public void GivenIAddTheSkillWithAnd(string name, string level)
        {
            var available = CurrentPage.As<Skill>().AddSkill(name, level);
            if(available)
            {
                Assert.GreaterOrEqual(CurrentPage.As<Skill>().IsSkillAddedSuccessfully(name), 0);
            }
            else
            {
                Assert.That(available, Is.EqualTo(false));
            }
        }
        #endregion

        #region Add Employer Skill Steps
        [When(@"I add a skill more than 30 characters")]
        public void WhenIAddASkillMoreThan30Characters()
        {
            var row = ExcelUtil.DataSet.SelectSheet("skill").GetRowByKey("negative");
            var name = row.GetValue("Skill");
            var level = row.GetValue("Level");
            var available = CurrentPage.As<Skill>().AddSkill(name, level);
            if (!available)
            {
                throw new Exception($" the skill {name} is already there, please enter another skill");
            }
        }

        [When(@"I add a skill (.*) and level (.*)")]
        public void WhenIAddASkillAndLevel(string name, string level)
        {
            var available = CurrentPage.As<Skill>().AddSkill(name, level);
            if (!available)
            {
                throw new Exception($" the skill {name} is already there, please enter another skill");
            }
        }

        [When(@"I add the same skill (.*) and level (.*)")]
        public void WhenIAddTheSameSkillAndLevel(string name, string level)
        {
            CurrentPage.As<Skill>().AddDuplicateSkill(name, level);
        }

        [When(@"I cancel a skill (.*) and level (.*)")]
        public void WhenICancelASkillAndLevel(string name, string level)
        {
            CurrentPage.As<Skill>().CancelSkill(name, level);
        }

        [Then(@"the skill (.*) should be added sucessfully")]
        public void ThenTheSkillShouldBeAddedSucessfully(string name)
        {
            Assert.GreaterOrEqual(CurrentPage.As<Skill>().IsSkillAddedSuccessfully(name), 0);
        }

        [Then(@"A error message '(.*)' should be displayed")]
        public void ThenAErrorMessageShouldBeDisplayed(string msg)
        {
            var message = Driver.GetMessage();
            Assert.That(message.Contains(msg, StringComparison.OrdinalIgnoreCase));
        }

        [Then(@"The skill (.*) should not be added successfully")]
        public void ThenTheSkillShouldNotBeAddedSuccessfully(string name)
        {
            string[] tag = context.ScenarioInfo.Tags;
            if (tag.Contains("duplicateskill"))
            {
                /*I am using 2 for comparing because when The form is
               * open for adding a skill it actually gives you the total rows 2
               */
                Assert.That(CurrentPage.As<Skill>().IsTableEmpty(), Is.EqualTo(2));
            }
            else if (tag.Contains("invalidskill") || tag.Contains("cancelskill"))
            {
                Assert.That(CurrentPage.As<Skill>().IsSkillAddedSuccessfully(name), Is.EqualTo(-1));
            }
        }

        [Then(@"The skill should added with only (.*) characters")]
        public void ThenTheSkillShouldAddedWithOnlyCharacters(int length)
        {
            var row = ExcelUtil.DataSet.SelectSheet("skill").GetRowByKey("negative");
            var name = row.GetValue("Skill");
            Assert.That(CurrentPage.As<Skill>().IsSkillAddedSuccessfully(name.Substring(0, length)), Is.GreaterThanOrEqualTo(0));
        }
        #endregion

        #region EditEmployerSkill Steps

       [When(@"I edit the old skill (.*) and (.*) with new skill (.*) and (.*)")]
       public void WhenIEditTheOldSkillAndWithNewSkillAnd(string name, string level, string newName, string newLevel)
       {
           CurrentPage.As<Skill>().UpdateSkill(name, level, newName, newLevel);
       }
       
        [When(@"I cancel the old skill (.*) and (.*) with new skill (.*) and (.*)")]
        public void WhenICancelTheOldSkillAndWithNewSkillAnd(string name, string level, string newName, string newLevel)
        {
            CurrentPage.As<Skill>().CancelUpdateSkill(name, level, newName, newLevel);
        }

        [Then(@"The skill should be sucessfully updated with new skill (.*) and (.*)")]
       public void ThenTheSkillShouldBeSucessfullyUpdatedWithNewSkillAnd(string newName, string newLevel)
       {
           Assert.Multiple(() => {
               //Assert.That(Driver.GetMessage().Contains("Profile Updated", StringComparison.OrdinalIgnoreCase));
               Assert.GreaterOrEqual(CurrentPage.As<Skill>().UpdateSkillSucess(newName), 0);
           });
       }

       [Then(@"The skill(.*) should not be sucessfully updated with new skill (.*) and (.*)")]
       public void ThenTheSkillShouldNotBeSucessfullyUpdatedWithNewSkillAnd(string name, string newName, string newLevel)
       {
        Assert.That(CurrentPage.As<Skill>().UpdateSkillSucess(newName), Is.EqualTo(-1));
       }
       #endregion

        #region DeleteEmployerSkill Steps

        [When(@"I delete the skill (.*)")]
        public void WhenIDeleteTheSkill(string name)
        {
            CurrentPage.As<Skill>().DeleteSkill(name);
        }

        [Then(@"the skill (.*) should be deleted sucessfully")]
        public void ThenTheSkillShouldBeDeletedSucessfully(string name)
        {
            Assert.Multiple(() => {
                //Assert.That(Driver.GetMessage().Contains("Profile Updated", StringComparison.OrdinalIgnoreCase));
                Assert.That(CurrentPage.As<Skill>().DeleteSkillSuccess(name), Is.EqualTo(-1));
            });
        }

        [When(@"I cancel the skill (.*)")]
        public void WhenICancelTheSkill(string name)
        {
            CurrentPage.As<Skill>().CancelSkill(name);
        }

        [Then(@"The skill (.*) should be not deleted sucessfully")]
        public void ThenTheSkillShouldBeNotDeletedSucessfully(string name)
        {
            Assert.That(CurrentPage.As<Skill>().IsTableEmpty(), Is.Not.Zero);
        }
        #endregion

       

        
    }
}

