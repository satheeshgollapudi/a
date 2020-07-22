using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;

namespace Talent.UI.Page.EmployerArticlePage
{
    class CreatePage : Base
    {
        public CreatePage(IWebDriver driver) : base(driver)
        {
            ExcelUtil.SetDataSource("Employer_Article.xlsx");
        }

        private IWebElement Name => Driver.WaitForElement(By.Name("name"));
        private IWebElement Description => Driver.WaitForElement(By.Name("description"));
        private IWebElement DefaultPoints => Driver.WaitForElement(By.Name("defaultPoints"));
        private IWebElement LibraryType => Driver.WaitForElement(By.XPath("(//span[@class='ant-select-arrow'])[1]"));
        private IWebElement LibraryTypeArticle => Driver.WaitForElement(By.XPath("//li[@role='option'][contains(.,'Article')]"));
        private IWebElement Tag => Driver.WaitForElement(By.XPath("//input[@placeholder='Press enter']"));
        private IWebElement Article => Driver.WaitForElement(By.XPath("//div[@data-placeholder='Write your article here...']"));
        private IWebElement PublishBtn => Driver.WaitForElement(By.XPath("//button[@class='ant-btn ant-btn-primary']"));

        public void ReadDataFromArticleSheetAndAddNewArticle()
        {
            //read data from excel
            var row = ExcelUtil.DataSet.SelectSheet("manage_articles").GetRowByKey("create");
            var name = row.GetValue("Name");
            var description = row.GetValue("Description");
            var defaultPoints = row.GetValue("DefaultPoints");
            var tag = row.GetValue("Tag");
            var article = row.GetValue("Article");
           

            //Add new article with data from excel
            AddNewArticle(name, description, defaultPoints, tag, article);

        }


        public void AddNewArticle(string name, string description, string defaultPoints, string tag, string article)
        {

            if (!string.IsNullOrEmpty(name))
            {
                Name.SendKeys(name);
            }

            if (!string.IsNullOrEmpty(description))
            {
                Description.SendKeys(description);
            }

            if (!string.IsNullOrEmpty(defaultPoints))
            {
                DefaultPoints.SendKeys(defaultPoints);
            }


            LibraryType.Click();
            LibraryTypeArticle.Click();

            //seperate tags by comma
            string[] taglist = tag.Split(",");
            foreach (string tagSep in taglist)
            {
                Tag.SendKeys(tagSep);
                Tag.SendKeys(Keys.Enter);

            }


            if (!string.IsNullOrEmpty(article))
            {
                Article.SendKeys(article);
            }

            PublishBtn.Click();

        }
    }
}
