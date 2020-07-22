using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.Automation.Steps.BaseStep;
using NUnit.Framework;


namespace Talent.UI.Page.EmployerArticlePage
{
    class EditPage : Base
    {
        public EditPage(IWebDriver driver) : base(driver)
        {
            ExcelUtil.SetDataSource("Employer_Article.xlsx");
        }

        //first edit button
        private IWebElement EditBnt => Driver.WaitForElement(By.XPath("(//span[contains(.,'Edit')])[1]"));
        private IWebElement Name => Driver.WaitForElement(By.Name("name"));
        private IWebElement Description => Driver.WaitForElement(By.Name("description"));
        private IWebElement DefaultPoints => Driver.WaitForElement(By.Name("defaultPoints"));
        private IWebElement Tag => Driver.WaitForElement(By.XPath("//input[@placeholder='Press enter']"));
        private IWebElement Article => Driver.WaitForElement(By.XPath("//div[@data-placeholder='Write your article here...']"));
        private IWebElement PublishBtn => Driver.WaitForElement(By.XPath("//button[@class='ant-btn ant-btn-primary']"));
        private IWebElement PreviewBtn => Driver.WaitForElement(By.XPath("(//span[contains(.,'Preview')])[1]"));
        private IWebElement PreviewName => Driver.WaitForElement(By.XPath("(//div[@class='ant-row']//h3)[1]"));
        private IWebElement PreviewDescription => Driver.WaitForElement(By.XPath("//span[@style='font-style: italic; font-weight: lighter;']"));
        private IList<IWebElement> PreviewTag => Driver.FindElements(By.XPath("//div[@class='ant-col ant-col-18']//span"));
        private IWebElement PreviewDefaultPoints => Driver.WaitForElement(By.XPath("(//div[@class='ant-col ant-col-6']//span)[1]"));
        private IWebElement PreviewArticle => Driver.WaitForElement(By.XPath("(//div[@class='ant-spin-container']//p)[1]"));


        public void CheckIfThereIsArticle()
        {
            //check if there is article. If yes, we can call the edit method
            if (EditBnt != null)
            {
                EditArticle();
            }
            else
            {
                throw new Exception();
            }
        }

        public void EditArticle()
        {
            //read data from the excel
            var row = ExcelUtil.DataSet.SelectSheet("manage_articles").GetRowByKey("edit");

            //edit the first article
            EditBnt.Click();
            Name.Clear();
            var newName = row.GetValue("Name");
            if (!string.IsNullOrEmpty(newName))
            {
                Name.SendKeys(newName);
            }

            Description.Clear();
            var newDescription = row.GetValue("Description");
            if (!string.IsNullOrEmpty(newDescription))
            {
                Description.SendKeys(newDescription);
            }


            DefaultPoints.Clear();
           var newDefaultPoints = row.GetValue("DefaultPoints");
            if (!string.IsNullOrEmpty(newDefaultPoints))
            {
                DefaultPoints.SendKeys(newDefaultPoints);
            }

           var newTag = row.GetValue("Tag");
            if (!string.IsNullOrEmpty(newTag))
            {
                Tag.SendKeys(newTag);
                Tag.SendKeys(Keys.Enter);
            }


            Article.Clear();
            var newArticle = row.GetValue("Article");
            if (!string.IsNullOrEmpty(newArticle))
            {
                Article.SendKeys(newArticle);
            }

            PublishBtn.Click();

        }

        public void Assert_Edit()
        {
            var row = ExcelUtil.DataSet.SelectSheet("manage_articles").GetRowByKey("edit");
            PreviewBtn.WaitForClickable(Driver);
            PreviewBtn.Click();
            Assert.AreEqual(row.GetValue("Name"),PreviewName.Text);
            Assert.AreEqual(row.GetValue("Description"),PreviewDescription.Text);
            Assert.AreEqual("Points: "+ row.GetValue("DefaultPoints"),PreviewDefaultPoints.Text);
            
            foreach (var Tag in PreviewTag)
            {

                if (Tag.Text == row.GetValue("Tag"))
                {
                    Assert.Pass();
                }
            }

            Assert.AreEqual(row.GetValue("Article"),PreviewArticle.Text);

        }



    }
}
