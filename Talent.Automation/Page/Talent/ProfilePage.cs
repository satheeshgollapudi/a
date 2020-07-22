using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class ProfilePage : Base
    {
        private readonly ExcelData talentProfile;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            ExcelUtil.SetDataSource("profile.xlsx");
            talentProfile = ExcelUtil.DataSet.SelectSheet("talent").GetRowByKey("valid");
        }

        //Elements
        #region Primary Contact Details elements
        private IWebElement PrimaryContactDetailsEdit => Driver.WaitForElement(By.XPath("//div[text() = 'Primary Contact Details']//following::a[text() = 'Edit'][1]"));
        private IWebElement FirstNameInput => Driver.WaitForElement(By.CssSelector("input[placeholder = 'First Name']"));
        private IWebElement LastNameInput => Driver.WaitForElement(By.CssSelector("input[placeholder='Last Name']"));
        private IWebElement EmailInput => Driver.WaitForElement(By.CssSelector("input[placeholder = 'Email'][type='text']"));
        private IWebElement PhoneInput => Driver.WaitForElement(By.CssSelector("input[placeholder='Phone']"));
        private IWebElement SaveDetails => Driver.WaitForElement(By.XPath("//a[contains(text(),'Save')]"));
        private IWebElement GetName => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Name')]//following-sibling::div"));
        private IWebElement GetEmail => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Email')]//following-sibling::div"));
        private IWebElement GetPhone => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Phone')]//following-sibling::div"));

        #endregion Primary Contact Details

        #region Address elements
        private IWebElement AddressEdit => Driver.WaitForElement(By.XPath("//div[text() = 'Address']//following::a[text() = 'Edit'][1]"));
        private IWebElement NumberInput => Driver.WaitForElement(By.XPath("//div[@class='ant-col ant-col-xs-24']//input[@class='ant-input']"));
        private IWebElement StreetInput => Driver.WaitForElement(By.XPath("//div[@class='ant-col ant-col-xs-24']//following::input[@type='text'][2]"));
        private IWebElement SuburbInput => Driver.WaitForElement(By.XPath("//div[@class='ant-col ant-col-xs-24']//following::input[@type='text'][3]"));
        private IWebElement Country => Driver.WaitForElement(By.XPath("//div[contains(text(),'Country')]//following-sibling::div"));
        private IWebElement CountryList => Driver.WaitForElement(By.XPath("//li[contains(text(), 'Select Country')]//parent::ul"));
        private IWebElement City => Driver.WaitForElement(By.XPath("//div[contains(text(),'City')]//following-sibling::div"));
        private IWebElement CityList => Driver.WaitForElement(By.XPath("//li[contains(text(), 'Select City')]//parent::ul"));
        private IWebElement PostcodeInput => Driver.WaitForElement(By.XPath("//div[@class='ant-col ant-col-xs-24']//following::input[@type='text'][4]"));
        private IWebElement SaveAddressDetails => Driver.WaitForElement(By.XPath("//div[text()='Address']//following::a[text()='Save'][1]"));
        private IWebElement GetAddress1 => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Address')]//following-sibling::div[1]/div[1]/div"));
        private IWebElement GetAddress2 => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Address')]//following-sibling::div[1]/div[2]/div"));

        #endregion Address elements

        #region Nationality elements
        private IWebElement NationalityComponent => Driver.WaitForElement(By.XPath("//div[contains(text(), 'Nationality')]/parent::div"));
        private IWebElement EditNationality => NationalityComponent.FindElement(By.LinkText("Edit"));
        private IWebElement Nationality => NationalityComponent.FindElement(By.CssSelector("div.ant-select-selection--single"));
        private IWebElement NationalityList => Driver.WaitForElement(By.XPath("//li[contains(text(),'Select Country')]//parent::ul"));
        private IWebElement SaveNationality => NationalityComponent.FindElement(By.LinkText("Save"));
        private IWebElement GetNationality => NationalityComponent.FindElement(By.CssSelector("div.antd-pro-app-src-components-description-list-index-detail"));

        #endregion Nationality

        #region SocialMedia Accounts elements
        private IWebElement SocialMediaComponent => Driver.WaitForElement(By.XPath("//div[text() = 'Social Media Accounts']/parent::div"));
        private IWebElement EditSocialMedia => SocialMediaComponent.FindElement(By.LinkText("Edit"));
        private IWebElement LinkedinInput => Driver.WaitForElement(By.XPath("//div[text()='LinkedIn']//following-sibling::div/input"));
        private IWebElement GitHubInput => Driver.WaitForElement(By.XPath("//div[text()='GitHub']//following-sibling::div/input"));
        private IWebElement SaveSocialMediaDetails => SocialMediaComponent.FindElement(By.LinkText("Save"));
        private IWebElement GetLinkedInAccount => Driver.WaitForElement(By.XPath("//div[contains(@class, 'ant-col-xs-24')]/div/*[contains(., 'LinkedIn')]"));
        private IWebElement GetGitHubAccount => Driver.WaitForElement(By.XPath("//div[contains(@class, 'ant-col-xs-24')]/div/*[contains(., 'GitHub')]"));

        #endregion SocialMedia Accounts elements

        #region Skills elements
        private IWebElement SkillsComponent => Driver.WaitForElement(By.XPath("//div[contains(text(),'Skills')]/parent::div"));
        private IWebElement SkillsHeader => Driver.WaitForElement(By.XPath("//div[contains(@class, 'ant-collapse-header')][contains(.,'Skills')]"), 30);
        private IWebElement AddNewSkillBtn => Driver.WaitForElement(By.XPath("//button[contains(.,'Add New Skill')]"));
        private IWebElement SkillNameInput => Driver.WaitForElement(By.XPath("//input[contains(@placeholder,'Skill')]"));
        private IWebElement SkillLevelComboBox => Driver.WaitForElement(By.XPath("//div[contains(text(),'Skill Level')]/parent::div"));
        private IWebElement SkillLevelList => Driver.WaitForElement(By.CssSelector("ul.ant-select-dropdown-menu"));
        private IWebElement SaveSkillLink => SkillsComponent.FindElement(By.LinkText("Save"));
        private IList<IWebElement> EditSkillLinks => SkillsComponent.FindElements(By.LinkText("Edit"));
        private IList<IWebElement> DeleteSkillLinks => SkillsComponent.FindElements(By.LinkText("Delete"));
        private IWebElement OkBtn => Driver.WaitForElement(By.XPath("//button[contains(.,'OK')]"));

        private IWebElement CancelBtn => Driver.WaitForElement(By.XPath("//button[contains(.,'Cancel')]"));
        private IWebElement SkillsTable => Driver.WaitForElement(By.XPath("//div[contains(text(),'Skills')]//following-sibling::div//table/tbody"));

        #endregion


        #region Experience elements
        private IWebElement ExerienceBnt => Driver.WaitForElement(By.XPath("//div[@class='ant-collapse-header'][contains(.,'Experiences')]"));
        private IWebElement AddNewExperienceBnt => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Add New Experience')]"));
        private IWebElement ExCompanyTxt => Driver.WaitForElement(By.Name("company"));
        private IWebElement ExPositionTxt => Driver.WaitForElement(By.Name("position"));
        private IWebElement ExStartDate => Driver.WaitForElement(By.XPath("(//input[@placeholder='Select date'])[1]"));
        private IWebElement ExEndDate => Driver.WaitForElement(By.XPath("(//input[contains(@placeholder,'Select date')])[2]"));
        /*  private IWebElement ControlLeft => Driver.WaitForElement(By.XPath("//a[contains(@class,'ant-calendar-month-panel-prev-year-btn')]"));
          private IWebElement ControlRight => Driver.WaitForElement(By.XPath("(//a[@title='Next year (Control + right)'])[2]"));
          private IWebElement EOkBtn => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'OK')]"));
          private IWebElement chooseAnDecate => Driver.WaitForElement(By.XPath("(//a[@title='Choose a year'])[2]"));*/
        private IWebElement ExDesTxt => Driver.WaitForElement(By.Id("responsibilities"));
        private IWebElement ExSaveBtn => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'OK')]"));

        private IWebElement AllEditBtn => Driver.WaitForElement(By.XPath("//i[@class='anticon anticon-edit icon-effect-greyOut']"));
        private IWebElement AllEditSaveBtn => Driver.WaitForElement(By.XPath("//i[@class='anticon anticon-check icon-effect-greyOut']"));
        private IWebElement AllDeleteBtn => Driver.WaitForElement(By.XPath("//i[@class='anticon anticon-delete icon-effect-greyOut']"));


        #endregion


        #region Education elements
        private IWebElement EducationBnt => Driver.WaitForElement(By.XPath("(//div[@role='tab'])[5]"));
        private IWebElement AddNewEducationBnt => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Add New Education')]"));
        private IWebElement InstituteTxt => Driver.WaitForElement(By.Name("instituteName"));
        private IWebElement EcountryTxt => Driver.WaitForElement(By.Name("country"));
        private IWebElement ETileTxt => Driver.WaitForElement(By.Name("title"));
        private IWebElement EDegreeTxt => Driver.WaitForElement(By.Name("degree"));
        private IWebElement StartDate => Driver.WaitForElement(By.XPath("(//input[@placeholder='Select date'])[1]"));
        private IWebElement EndDate => Driver.WaitForElement(By.XPath("(//input[contains(@placeholder,'Select date')])[2]"));
        private IWebElement ControlLeft => Driver.WaitForElement(By.XPath("//a[contains(@class,'ant-calendar-month-panel-prev-year-btn')]"));
        private IWebElement ControlRight => Driver.WaitForElement(By.XPath("//a[contains(@class,'ant-calendar-month-panel-next-year-btn')]"));
        private IWebElement EOkBtn => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'OK')]"));
        private IWebElement chooseAnDecate => Driver.WaitForElement(By.XPath("(//a[@title='Choose a year'])[2]"));
        private IWebElement EduSaveBtn => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'OK')]"));

        private IWebElement EduEditBtn => Driver.WaitForElement(By.XPath("(//i[@aria-label='icon: edit'])[10]"));
        private IWebElement EduDeleteBtn => Driver.WaitForElement(By.XPath("(//i[@aria-label='icon: delete'])[2]"));

        #endregion



        #region Certification elements
        private IWebElement CertiBnt => Driver.WaitForElement(By.XPath("(//div[@role='tab'])[6]"));
        private IWebElement CertiAddNewBnt => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Add New Certification')]"));
        private IWebElement CertiNameTxt => Driver.WaitForElement(By.Name("certificationName"));
        private IWebElement CertiIssuerTxt => Driver.WaitForElement(By.Name("certificationFrom"));
        private IWebElement CertiYearTxt => Driver.WaitForElement(By.Name("certificationYear"));
        private IWebElement CertiSaveBtn => Driver.WaitForElement(By.XPath("//i[contains(@class,'anticon anticon-check icon-effect-greyOut')]"));
        private IWebElement CertiCancelBtn => Driver.WaitForElement(By.XPath("//i[contains(@class,'anticon anticon-close icon-effect-greyOut')]"));
        //  private IWebElement CerEditBtn => Driver.WaitForElement(By.XPath("/html/body/div[1]/div/section/section/main/div/div[3]/div/div/div/div/div[2]/div/div/div/div[6]/div[2]/div/div/div/div/div/div/div/table/tbody/tr[2]/td[4]/span/i[1]"));
        //   private IWebElement CerDeleteBtn => Driver.WaitForElement(By.XPath("/html/body/div[1]/div/section/section/main/div/div[3]/div/div/div/div/div[2]/div/div/div/div[6]/div[2]/div/div/div/div/div/div/div/table/tbody/tr[2]/td[4]/span/i[2]"));

        #endregion

        private IWebElement DeleteTxt => Driver.WaitForElement(By.XPath("//button[contains(@class,'ant-btn ant-btn-primary ant-btn-sm')]"));

        //Actions
        public string ProfilePageTitle()
        {
            return Driver.Title;
        }

        #region Profile Details Methods 
        public void UpdatePrimaryContactDetails(string FirstName, string LastName, string Email, string Phone)
        {
            PrimaryContactDetailsEdit.Click();
            FirstNameInput.EnterText(FirstName);
            LastNameInput.EnterText(LastName);
            EmailInput.EnterText(Email);
            PhoneInput.EnterText(Phone);
            SaveDetails.Click();
        }

        public void UpdateAddress(string number, string street, string suburb, string country, string city, string postcode)
        {
            AddressEdit.Click();
            NumberInput.EnterText(number);
            StreetInput.EnterText(street);
            SuburbInput.EnterText(suburb);
            Country.Click();
            CountryList.SelectFromDropdownList(Driver, country);
            City.Click();
            CityList.SelectFromDropdownList(Driver, city);
            PostcodeInput.EnterText(postcode);
            SaveAddressDetails.Click();
        }

        public void UpdateNationality(string nationality)
        {
            EditNationality.Click();
            Nationality.Click();
            NationalityList.SelectFromDropdownList(Driver, nationality);
            SaveNationality.Click();
        }

        public void UpdateSocialMediaAccounts(string Linkedin, string GitHub)
        {
            EditSocialMedia.Click();
            LinkedinInput.EnterText(Linkedin);
            GitHubInput.EnterText(GitHub);
            SaveSocialMediaDetails.Click();
        }

        public string ReturnEmail()
        {
            return GetEmail.GetInnerText(Driver);
        }

        public string ReturnPhone()
        {
            return GetPhone.GetInnerText(Driver);
        }

        public string ReturnName()
        {
            return GetName.GetInnerText(Driver);
        }

        public string ReturnAddress1()
        {
            return GetAddress1.GetInnerText(Driver);
        }

        public string ReturnAddress2()
        {
            return GetAddress2.GetInnerText(Driver);
        }

        public string ReturnNationality()
        {
            return GetNationality.GetInnerText(Driver);
        }

        public string ReturnLinkedInAccount()
        {
            return GetLinkedInAccount.GetAttribute("href");
        }

        public string ReturnGitHubAccount()
        {
            return GetGitHubAccount.GetAttribute("href");
        }
        public void ResetContactDetails(string role)
        {
            string firstName = talentProfile.GetValue("firstname");
            string lastName = talentProfile.GetValue("lastname");
            string email = talentProfile.GetValue("email");
            string phone = talentProfile.GetValue("phone");

            UpdatePrimaryContactDetails(firstName, lastName, email, phone);
        }

        public void ResetAddressDetails(string role)
        {
            string number = talentProfile.GetValue("addressNumber");
            string street = talentProfile.GetValue("addressStreet");
            string suburb = talentProfile.GetValue("addressSuburb");
            string country = talentProfile.GetValue("addressCountry");
            string city = talentProfile.GetValue("addressCity");
            string postcode = talentProfile.GetValue("addressPostcode");

            UpdateAddress(number, street, suburb, country, city, postcode);
        }

        public void ResetNationality(string role)
        {
            string nationality = talentProfile.GetValue("nationality");

            UpdateNationality(nationality);
        }

        public void ResetSocialMediaAccounts(string role)
        {
            string linkedInAccount = talentProfile.GetValue("linkedin");
            string gitHubAccount = talentProfile.GetValue("github");

            UpdateSocialMediaAccounts(linkedInAccount, gitHubAccount);
        }
        #endregion

        #region Skills Methods

        public void AddSkill(string skillName, string skillLevel)
        {
            SkillsHeader.ExpandHeader();
            AddNewSkillBtn.WaitForClickable(Driver);
            AddNewSkillBtn.Click();

            if (!string.IsNullOrEmpty(skillName))
            {
                SkillNameInput.SendKeys(skillName);
            }

            if (!string.IsNullOrEmpty(skillLevel))
            {
                SkillLevelComboBox.Click();
                SkillLevelList.SelectFromDropdownList(Driver, skillLevel);
            }

            SaveSkillLink.Click();
            //wait for the sucess message
            //System.Threading.Thread.Sleep(10000);
            //SuccessMessage.WaitForDisplayed(Driver);
        }

        public void EditSkill(string skillName, string updatedSkillName, string updatedSkillLevel)
        {
            SkillsHeader.ExpandHeader();
            var data = new Dictionary<int, string>();
            data.Add(1, skillName);
            int rowNumber = SkillsTable.SearchDataFromTable(Driver, data);

            if (rowNumber == 0)
            {
                throw new Exception("Data doesn't exist");
            }

            EditSkillLinks[rowNumber - 1].Click();

            SkillNameInput.EnterText(updatedSkillName);
            SkillLevelComboBox.Click();
            SkillLevelList.SelectFromDropdownList(Driver, updatedSkillLevel);
            SaveSkillLink.Click();
        }
        public void DeleteSkill(string skillName)
        {
            //SkillsHeader.ExpandHeader();
            //int rowNumber = SkillsTable.SearchDataFromTable(Drive skillName);

            //if (rowNumber == 0)
            //{
            //    throw new Exception("Data doesn't exist");
            //}

            //DeleteSkillLinks[rowNumber - 1].Click();
            //OkBtn.Click();
            //SuccessMessage.WaitForDisplayed(Driver);
        }

        public bool ValidateSkills(string skillName, string skillLevel)
        {
            SkillsHeader.ExpandHeader();
            var data = new Dictionary<int, string>
            {
                {1, skillName},
                {2, skillLevel}
            };

            return SkillsTable.IsDataPresentInTable(Driver, data);
        }
        #endregion


        public void AddEducation()
        {

            string institute = talentProfile.GetValue("institute");
            string country = talentProfile.GetValue("country");
            string title = talentProfile.GetValue("title");
            string degree = talentProfile.GetValue("degree");
            string startDate = talentProfile.GetValue("startDate");
            string endDate = talentProfile.GetValue("endDate");

            try
            {
                EducationBnt.WaitForClickable(Driver);
                EducationBnt.Click();
            }
            catch (ElementClickInterceptedException e)
            {

                EducationBnt.WaitForClickable(Driver);
                EducationBnt.Click();
            }

            AddNewEducationBnt.Click();


            if (!string.IsNullOrEmpty(institute))
            {
                InstituteTxt.SendKeys(institute);
            }

            if (!string.IsNullOrEmpty(country))
            {
                EcountryTxt.SendKeys(country);
            }
            if (!string.IsNullOrEmpty(title))
            {
                ETileTxt.SendKeys(title);
            }
            if (!string.IsNullOrEmpty(degree))
            {
                EDegreeTxt.SendKeys(degree);
            }


            //Choose the start date
            StartDate.WaitForClickable(Driver);
            StartDate.Click();
            searchDate(startDate, 2020);

            //choose the end data
            EndDate.WaitForClickable(Driver);
            EndDate.Click();

            searchDate(endDate, 2020);

            //save

            EduSaveBtn.WaitForClickable(Driver);
            EduSaveBtn.Click();
            Thread.Sleep(1000);


        }


        public void EditEducation()
        {
            EduEditBtn.WaitForClickable(Driver);
            EduEditBtn.Click();
            InstituteTxt.SendKeys("AUT");
            EduSaveBtn.WaitForClickable(Driver);
            EduSaveBtn.Click();
        }

        public void DeleteEducation()
        {
            EduDeleteBtn.WaitForClickable(Driver);
            EduDeleteBtn.Click();
            DeleteTxt.WaitForClickable(Driver);
            DeleteTxt.Click();
        }



        public void AddExperience()
        {
            var company = talentProfile.GetValue("company");
            string position = talentProfile.GetValue("position");
            string jobDescription = talentProfile.GetValue("jobDescription");
            string startDate = talentProfile.GetValue("startDate");
            string endDate = talentProfile.GetValue("endDate");

            ExerienceBnt.WaitForClickable(Driver);
            ExerienceBnt.Click();

            AddNewExperienceBnt.WaitForClickable(Driver);
            AddNewExperienceBnt.Click();


            if (!string.IsNullOrEmpty(company))
            {
                ExCompanyTxt.SendKeys(company);
            }

            if (!string.IsNullOrEmpty(position))
            {
                ExPositionTxt.SendKeys(position);
            }

            //Choose the start date
            ExStartDate.WaitForClickable(Driver);
            ExStartDate.Click();
            searchDate(startDate, 2020);

            //choose the end data
            ExEndDate.WaitForClickable(Driver);
            ExEndDate.Click();

            if (!string.IsNullOrEmpty(jobDescription))
            {
                ExDesTxt.SendKeys(jobDescription);
            }
            searchDate(endDate, 2020);

            //save
            ExSaveBtn.WaitForClickable(Driver);
            ExSaveBtn.Click();
        }



        public void EditExperience()
        {
            AllEditBtn.WaitForClickable(Driver);
            AllEditBtn.Click();
            ExCompanyTxt.SendKeys("ANZ");
            AllEditSaveBtn.WaitForClickable(Driver);
            AllEditSaveBtn.Click();
        }

        public void DeleteExperience()
        {
            AllDeleteBtn.WaitForClickable(Driver);
            AllDeleteBtn.Click();
            DeleteTxt.WaitForClickable(Driver);
            DeleteTxt.Click();

        }

        public void searchDate(String date, int defaultYear)
        {
            //take the year of date out
            String stringYear = date.Substring(0, 4);
            int year = int.Parse(stringYear);
            //take the month
            String stringmonth = date.Substring(5, 2);
            int month = int.Parse(stringmonth);

            switch (stringmonth)
            {
                case "01":
                    stringmonth = "Jan";
                    break;
                case "02":
                    stringmonth = "Feb";
                    break;
                case "03":
                    stringmonth = "Mar";
                    break;
                case "04":
                    stringmonth = "Apr";
                    break;
                case "05":
                    stringmonth = "May";
                    break;
                case "06":
                    stringmonth = "Jun";
                    break;
                case "07":
                    stringmonth = "Jul";
                    break;
                case "08":
                    stringmonth = "Aug";
                    break;
                case "09":
                    stringmonth = "Sep";
                    break;
                case "10":
                    stringmonth = "Oct";
                    break;
                case "11":
                    stringmonth = "Nov";
                    break;
                case "12":
                    stringmonth = "Dec";
                    break;

            }

            //compare the default year and the year user offered

            //judge how many times until we find the correct year should we click when the year is not same as default year 
            int yearGap = defaultYear - year;
            if (yearGap < 0)
            {
                //find the year
                for (int i = 0; i < Math.Abs(yearGap); i++)
                {
                    ControlRight.WaitForClickable(Driver);
                    ControlRight.Click();
                }

                //find the month
                Driver.WaitForElement(By.XPath("//td[@role='gridcell'][contains(.,'" + stringmonth + "')]")).Click();

            }
            else if (yearGap > 0)
            {
                for (int i = 0; i < yearGap; i++)
                {
                    ControlLeft.WaitForClickable(Driver);
                    ControlLeft.Click();

                }

                //find the month
                Driver.WaitForElement(By.XPath("//td[@role='gridcell'][contains(.,'" + stringmonth + "')]")).Click();

            }
            else
            {
                try
                {

                    Driver.WaitForElement(By.XPath("//td[@role='gridcell'][contains(.,'" + stringmonth + "')]")).Click();
                }
                catch (Exception e)
                {
                    Driver.WaitForElement(By.XPath("//td[@role='gridcell'][contains(.,'" + stringmonth + "')]")).Click();
                }

                //find the month

            };
        }


        public void AddCertificate()
        {
            String certification = talentProfile.GetValue("certification");
            String Issuer = talentProfile.GetValue("issuer");
            String Year = talentProfile.GetValue("year");


            try
            {
                CertiBnt.WaitForClickable(Driver);
                CertiBnt.Click();
            }
            catch (ElementClickInterceptedException e)
            {
                CertiBnt.WaitForClickable(Driver);
                CertiBnt.Click();
            }

            CertiAddNewBnt.Click();


            if (!string.IsNullOrEmpty(certification))
            {
                CertiNameTxt.SendKeys(certification);
            }

            if (!string.IsNullOrEmpty(Issuer))
            {
                CertiIssuerTxt.SendKeys(Issuer);
            }
            if (!string.IsNullOrEmpty(Year))
            {
                CertiYearTxt.SendKeys(Year);
            }

            //save
            CertiSaveBtn.WaitForClickable(Driver);
            CertiSaveBtn.Click();


        }

        public void EditCerticate()
        {
            AllEditBtn.WaitForClickable(Driver);
            AllEditBtn.Click();
            CertiNameTxt.SendKeys("AWS");
            CertiSaveBtn.WaitForClickable(Driver);
            CertiSaveBtn.Click();
        }

        public void DeleteCerticate()
        {
            AllDeleteBtn.WaitForClickable(Driver);
            AllDeleteBtn.Click();
            DeleteTxt.WaitForClickable(Driver);
            DeleteTxt.Click();
        }
    }
}