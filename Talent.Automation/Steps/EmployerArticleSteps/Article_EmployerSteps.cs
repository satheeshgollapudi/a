using System;
using MVPStudio.Framework.Helps.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;
using Talent.UI.Page.EmployerArticlePage;
using TechTalk.SpecFlow;


namespace Talent.UI.Steps
{
    [Binding]
    public class Article_EmployerSteps : Base
    {
        public Article_EmployerSteps(IWebDriver driver) : base(driver)
        {
        }

        [When(@"I press the edit button on the first article, update the information of this article")]
        public void WhenIPressTheEditButtonOnTheFirstArticleUpdateTheInformationOfThisArticle()
        {
           EditPage editPage = new EditPage(Driver);
            editPage.CheckIfThereIsArticle();
            
        }
        
        [Then(@"the article's information should be my updated information")]
        public void ThenTheArticleSInformationShouldBeMyUpdatedName()
        {
            EditPage editPage = new EditPage(Driver);
            editPage.Assert_Edit();
        }
    }
}
