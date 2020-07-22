using OpenQA.Selenium;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;

namespace Talent.Automation.Steps
{
    [Binding]
    public class DeleteArticleSteps : Base
    {
        private readonly ScenarioContext context;

        public DeleteArticleSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            context = injectedContext;
        }       

        [Then(@"I click on Delete button")]
        public void ThenIClickOnDeleteButton()
        {
            CurrentPage = GetInstance<ArticleShedulerPage>(Driver);
            CurrentPage.As<ArticleShedulerPage>().ClickDeleteTemplate();
        }

        [Then(@"I confirmed deletion")]
        public void ThenIConfirmedDeletion()
        {
            CurrentPage.As<ArticleShedulerPage>().ConfirmDeleteClick();
        }

        [Then(@"I cancel deletion")]
        public void ThenICancelDeletion()
        {
            CurrentPage.As<ArticleShedulerPage>().CancelDeleteBtn();
        }

        [Then(@"the record should be deleted from the list succesfully")]
        public void ThenTheRecordShouldBeDeletedFromTheListSuccesfully()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckDeleteTemplate();
        }

        [Then(@"the record should not be deleted")]
        public void ThenTheRecordShouldNotBeDeleted()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckDeleteTemplate();
        }


    }
}
