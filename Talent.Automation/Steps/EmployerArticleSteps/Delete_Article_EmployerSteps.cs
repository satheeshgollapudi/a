using System;
using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;
using Talent.UI.Page.EmployerArticlePage;
using TechTalk.SpecFlow;


namespace Talent.UI
{
    [Binding]
    public class Delete_Article_EmployerSteps : Base
    {
        public Delete_Article_EmployerSteps(IWebDriver driver) : base(driver)
        {
        }

        [When(@"I press the delete button on the first article")]
        public void WhenIPressTheDeleteButtonOnTheFirstArticle()
        {
            ArticleManagePage articleManagePage = new ArticleManagePage(Driver);
            articleManagePage.DeleteArticle();
        }
        
        [Then(@"the article should be deleted")]
        public void ThenTheArticleShouldBeDeleted()
        {
           var deleteConfirm= Driver.WaitForElement(By.XPath("(//span[contains(.,'Removed article')])[2]"));
            if (!string.IsNullOrEmpty(deleteConfirm.Text))
            {
                Assert.Pass();
            }
            else {
                Assert.Fail();
            }                   
        }
    }
}
