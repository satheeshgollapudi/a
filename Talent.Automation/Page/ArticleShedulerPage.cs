using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class ArticleShedulerPage : Base
    {

        private readonly ExcelData CreateArticle;
        private readonly ExcelData UpdateArticle;
        public ArticleShedulerPage(IWebDriver driver) : base(driver)
        {
            ExcelUtil.SetDataSource("articleScheduler.xlsx");
            CreateArticle = ExcelUtil.DataSet.SelectSheet("articlescheduler").GetRowByKey("valid");
            //UpdateArticle = ExcelUtil.DataSet.SelectSheet("articlescheduler").GetRowByKey("editarticle");
        }

        private IWebElement AddTemplate => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Add template')]"));
        private IWebElement TemplateName => Driver.WaitForElement(By.XPath("//input[@type='text'][@id='template_name']"));
        private IWebElement Description => Driver.WaitForElement(By.XPath("//input[contains(@id,'template_description')]"));
        private IWebElement SearchArticle => Driver.WaitForElement(By.XPath("//input[contains(@placeholder,'Search for article')]"));
        private IWebElement ArticleName => Driver.WaitForElement(By.XPath("//div[@class = 'ant-card-head-title']"));
        private IWebElement PlusIcon => Driver.WaitForElement(By.XPath("//i[@class = 'anticon anticon-plus']"));
        private IWebElement AddRules => Driver.WaitForElement(By.XPath("//button[@class = 'ant-btn']"));
        private IWebElement Days => Driver.WaitForElement(By.XPath("//input[@role='spinbutton']"));
        private IWebElement SaveBtn => Driver.WaitForElement(By.XPath("//span[@class='ant-form-item-children']//button[@class = 'ant-btn ant-btn-primary']"));
        private IWebElement EditDays => Driver.WaitForElement(By.XPath("//input[@role='spinbutton'][@value='']"));
        private IWebElement CancelDelete => Driver.FindElement(By.XPath("//div//button[@class='ant-btn ant-btn-sm']"));
        private IList<IWebElement> Template => Driver.FindElements(By.XPath("//td[@class='ant-table-row-cell-break-word'][1]"));
        private IList<IWebElement> ChooseToDeleteArticle => Driver.FindElements(By.XPath("//div[@class='ant-timeline-item-content']//div[@class='ant-card ant-card-bordered ant-card-small']"));
        public string ArticleShedulerPageTitle()
        {
            return Driver.Title;
        }
        public void ClickOnAddTemplateBtn()
        {
            AddTemplate.Click();
        }
        public void TemplateNameAndDescription()
        {
            try
            {
                TemplateName.WaitForClickable(Driver);
                TemplateName.SendKeys(CreateArticle.GetRowByKey("valid").GetValue("templateName"));
                Description.SendKeys(CreateArticle.GetRowByKey("valid").GetValue("description"));

            }

            catch (Exception e)
            {
                throw;
            }

        }
        public void SearchForArticle()
        {
            SearchArticle.SendKeys(CreateArticle.GetRowByKey("valid").GetValue("searchArticle"));
            PlusIcon.Click();
        }
        public void AddRulesToArticle()
        {
            AddRules.Click();
            Days.SendKeys(CreateArticle.GetRowByKey("valid").GetValue("days"));
        }
        public DashboardPage SaveTemplate()
        {
            SaveBtn.Click();
            return new DashboardPage(Driver);
        }
        public void ClickEditTemplate()
        {
            foreach (var temp in Template)
            {
                string findtemplate = CreateArticle.GetRowByKey("valid").GetValue("templateName");
                string T = temp.Text;
                if (T == findtemplate)
                {
                    IWebElement EditBtn = Driver.WaitForElement(By.XPath("//td[contains(text(),'" + T + "')]//parent::tr//descendant::td//div//i[@aria-label='icon: edit']"));
                    EditBtn.Click();
                }
            }

        }
        public void EditArticle()
        {
            TemplateName.Clear();
            TemplateName.SendKeys(CreateArticle.GetRowByKey("editarticle").GetValue("templateName"));
            Description.Clear();
            Description.SendKeys(CreateArticle.GetRowByKey("editarticle").GetValue("description"));
            //SearchArticle.SendKeys(CreateArticle.GetRowByKey("editarticle").GetValue("searchArticle"));
            //PlusIcon.Click();
            //AddRules.Click();
            //EditDays.SendKeys(CreateArticle.GetRowByKey("editarticle").GetValue("days"));
            
        }
        public void DeleteArticle()
        {            
            foreach (var choosearticle in ChooseToDeleteArticle)
            {
                string article = CreateArticle.GetRowByKey("valid").GetValue("searcharticle");

                string A = choosearticle.Text;
                if (A == article)
                {
                    IWebElement MinusBtn = Driver.FindElement(By.XPath("//div[contains(text(), '" + article + "')]//parent::div//div//i[@aria-label='icon: minus']"));
                    MinusBtn.Click();
                }
            }
        }
        public DashboardPage SaveEditArticle()
        {
            SaveBtn.Click();
            return new DashboardPage(Driver);
        }
        public void ClickDeleteTemplate()
        {

            foreach (var temp in Template)
            {
                string template = CreateArticle.GetRowByKey("editarticle").GetValue("templateName");

                string T = temp.Text;
                if (T == template)
                {
                    IWebElement DeleteBtn = Driver.FindElement(By.XPath("//td[contains(text(),'" + template + "')]//parent::tr//descendant::td//div//i[@aria-label='icon: delete']"));
                    DeleteBtn.Click();
                }
            }

        }
        public void ConfirmDeleteClick()
        {
            IWebElement ConfirmDelete = Driver.FindElement(By.XPath("//div//button[@class='ant-btn ant-btn-primary ant-btn-sm']"));
            ConfirmDelete.Click();
        }
        public void CancelDeleteBtn()
        {
            CancelDelete.Click();
        }
        public bool CheckAddTemplate()
        {
            foreach (var temp in Template)
            {
                string template = CreateArticle.GetRowByKey("valid").GetValue("templateName");
                string T = temp.Text;
                if (T == template)
                {
                    Console.WriteLine("Template" + template + "is present");
                    return true;
                }
            }
            return false;
        }
        public bool CheckEditTemplate()
        {
            foreach (var temp in Template)
            {
                string c = CreateArticle.GetRowByKey("editarticle").GetValue("templateName");
                string T = temp.Text;
                if (T == c)
                {
                    Console.WriteLine("Template" + c + "is present");
                    return true;
                }
            }
            return false;
        }
        public bool CheckDeleteTemplate()
        {
            foreach (var temp in Template)
            {
                string c = CreateArticle.GetRowByKey("editarticle").GetValue("templateName");
                string T = temp.Text;
                if (T == c)
                {
                    Console.WriteLine("Template" + c + "is present");
                }
                else
                {
                    Console.WriteLine("Template" + c + "is deleted");
                    return true;
                }
            }
            return false;
        }

    }
}
