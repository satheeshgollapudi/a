using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using OpenQA.Selenium;
using Talent.Automation.Enums;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class LoginPage : Base
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            ExcelUtil.SetDataSource("credential.xlsx");
        }

        private IWebElement EmailTxt => Driver.WaitForElement(By.Id("email"));
        private IWebElement PasswordTxt => Driver.WaitForElement(By.Id("password"));
        private IWebElement LoginBtn => Driver.WaitForElement(By.Id("btn_login"));
        private IWebElement RememberMeCheckbox => Driver.WaitForElement(By.XPath("//input[@type='checkbox']"));
        private IWebElement ForgotPasswordBtn => Driver.WaitForElement(By.XPath("//a[@href]/span[text()='Forgot your password?']"));
        private IWebElement LoginAsTalentTab => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Demo as Talent')]"));
        private IWebElement LoginAsEmployerTab => Driver.WaitForElement(By.XPath("//div[@role = 'tab' and text() = 'Login as Employer']"));

        public string LoginPageTitle()
        {
            return Driver.Title;
        }

        public DashboardPage LoginAs(RoleEnum role)
        {
            var sheet = role.ToString().ToLower();
            var row = ExcelUtil.DataSet.SelectSheet(sheet).GetRowByKey("positive");
            EmailTxt.WaitForClickable(Driver);
            EmailTxt.SendKeys(row.GetValue("username"));
            PasswordTxt.SendKeys(row.GetValue("password"));
            LoginBtn.Click();
            Driver.WaitForPageLoaded("Dashboard - GTIO");
            return new DashboardPage(Driver);
        }

        public void LoginWithInvalidCredentials()
        {
            var row = ExcelUtil.DataSet.SelectSheet("talent").GetRowByKey("negative");
            EmailTxt.SendKeys(row.GetValue("username"));
            PasswordTxt.SendKeys(row.GetValue("password"));

            LoginBtn.Click();
        }

    }
}