using MVPStudio.Framework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page.Employer.Profile
{
    /// <summary>
    /// Skill class defines the add, update and delete method
    /// </summary>
    public class Skill: Base
    {
        public Skill(IWebDriver driver) : base(driver)
        {
        }

        #region Initalize the WebElements 
        private IWebElement ProfileTab => Driver.WaitForElement(By.CssSelector("main ul li:nth-child(1)"));
        private IWebElement AddNewSkillBtn => Driver.WaitForElement(By.CssSelector("button[class='ant-btn ant-btn-dashed']"));
        private IWebElement TypeSkill => Driver.WaitForElement(By.CssSelector("input.ant-input"));
        //private IWebElement NoData => Driver.WaitForElement(By.CssSelector("div.ant-table-placeholder"));
        private IList<IWebElement> TableBodyRows => Driver.WaitForElements(By.CssSelector("tbody[class='ant-table-tbody'] tr"));
        private IWebElement SelectLevel => Driver.WaitForElement(By.XPath("//ul[contains(@class,'ant-select-dropdown-menu-root ant-select-dropdown-menu-vertical')]"));
        private IWebElement SaveBtn => Driver.WaitForElement(By.LinkText("Save"));
        private IWebElement CancelBtn => Driver.WaitForElement(By.LinkText("Cancel"));
        private IWebElement ClickOnDropDown =>
            Driver.WaitForElement(By.CssSelector("div[class='ant-select ant-select-enabled']"));
        protected IWebElement DeleteBtn =>
            Driver.WaitForElement(By.CssSelector("button[class='ant-btn ant-btn-primary ant-btn-sm']"));

        //This webElements is for Cancel the Deleting Skill
        private IWebElement CancelButton =>
            Driver.WaitForElement(By.CssSelector("button[class='ant-btn ant-btn-sm']"));
        #endregion
        
        /// this method checks Employer Profile tab is active
        public bool IsEmployerProfileTabActive()
        {
            if (ProfileTab.GetAttribute("class")
                .Contains("ant-menu-item-selected", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
        #region methods for Add Skill Scenario
        // this method create a new skill
        public bool AddSkill(string name, string level)
        {
            if (ReturnRowNumber(name) == -1)
            {
                AddNewSkillBtn.Click();
                EnterSkillDetails(name, level);
                SaveBtn.Click();
                return true;
            }
            return false;
        }

        // This method add the same skill again
        public void AddDuplicateSkill(string name, string level)
        {
            AddNewSkillBtn.Click();
            EnterSkillDetails(name, level);
            SaveBtn.Click();
        }

        // This method click on cancel button when user changes his mind not to add a skill
        public void CancelSkill(string name, string level)
        {
                AddNewSkillBtn.Click();
                EnterSkillDetails(name, level);
                CancelBtn.Click();     
        }

        /// <summary>
        /// This method tells that Is a skill added
        /// </summary>
        /// <param name="name">name of skill</param>
        /// <returns>Return -1 when no skill added and Return >= 0 when skill is found 
        /// or added successfully</returns>
        public int IsSkillAddedSuccessfully(string name)
        {
            return ReturnRowNumber(name);
        }
        #endregion

        #region methods for Update Skill Scenario
        public void UpdateSkill(string name, string level, string newName, string newLevel)
        {
            int rowNumber = ReturnRowNumber(name);
            if(rowNumber != -1)
            {
                IWebElement editBtn = TableBodyRows[rowNumber].FindElement(By.XPath($"//tr[{rowNumber + 1}]/td[3]/span/a[1]"));
                editBtn.Click();
                EnterSkillDetails(newName, newLevel);
                SaveBtn.Click();
            }
            else
            {
                throw new Exception("No matching skill is available to update".ToString());
            }
        }

        public int UpdateSkillSucess(string name)
        { 
            return ReturnRowNumber(name);
        }

        public void CancelUpdateSkill(string name, string level, string newName, string newLevel)
        {
            int rowNumber = ReturnRowNumber(name);
            if (rowNumber != -1)
            {
                IWebElement editBtn = TableBodyRows[rowNumber].FindElement(By.XPath($"//tr[{rowNumber + 1}]/td[3]/span/a[1]"));
                editBtn.Click();
                EnterSkillDetails(newName, newLevel);
                CancelBtn.Click();
            }
            else
            {
                throw new Exception("No matching skill is available to Cancel editing".ToString());
            }
        }

        #endregion

        #region methods for Delete Skill Scenario

        // this method delete the skill from the employer profile
        public void DeleteSkill(string name)
        {
            int rowNumber = ReturnRowNumber(name);
            if (rowNumber != -1)
            {
                IWebElement deleteBtn = TableBodyRows[rowNumber].FindElement(By.XPath($"//tr[{rowNumber + 1}]/td[3]/span/a[2]"));
                deleteBtn.Click();
                DeleteBtn.Click();
            }
            else
            {
                throw new Exception($"the skill {name} is not available to perform delete action!");
            }
        }
        //This method clicks on Cancel button not to delete the skill
        public void CancelSkill(string name)
        {
            int rowNumber = ReturnRowNumber(name);
            if (rowNumber != -1)
            {
                IWebElement deleteBtn = TableBodyRows[rowNumber].FindElement(By.XPath($"//tr[{rowNumber + 1}]/td[3]/span/a[2]"));
                deleteBtn.Click();
                CancelButton.Click();
            }
            else
            {
                throw new Exception($"the skill {name} is not available to perform cancel actions!");
            }
        }

        // Returns -1 when skill is deleted
        public int DeleteSkillSuccess(string name)
        {
            return ReturnRowNumber(name);
        }
        #endregion

        #region Common methods between Add, update and delete scenarios
        // This method just enter the skill details
        protected void EnterSkillDetails(string name, string level)
        {
            if (!string.IsNullOrEmpty(name))
            {
                TypeSkill.WaitForDisplayed(Driver);
                TypeSkill.EnterText(name);
            }

            if (!string.IsNullOrEmpty(level))
            {
                ClickOnDropDown.Click();
                SelectLevel.WaitForClickable(Driver, 2);
                SelectLevel.SelectFromDropdownList(Driver, level);
            }
        }

        //Return No of Row into Employer Skill Table
        public int IsTableEmpty()
        {
            return TableBodyRows.Count;
        }

        /// <summary>
        /// this method search if skill is already into the Employer Skill table or need to add to perform actions
        /// </summary>
        /// <param name="name">the name of skill</param>
        /// <returns>Returns -1 if skill is not found otherwise the rownumber of the tale where skill is found</returns>
        protected int ReturnRowNumber(string name)
        {
            var rowNumber = -1;
            var count = IsTableEmpty();
            Console.WriteLine(count);
            //Look for the old value into table 
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (TableBodyRows[i].FindElement(By.XPath($"//tr[{i + 1}]/td[1]")).Text == name)
                    {
                        rowNumber = i;
                        break;
                    }
                }
            }
            return rowNumber;
        }
        #endregion
    }
}
