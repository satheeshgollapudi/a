using OpenQA.Selenium;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;


namespace Talent.Automation.Steps
{
    [Binding]
    public class EditArticleSchedulerSteps : Base
    {
        private readonly ScenarioContext context;

        public EditArticleSchedulerSteps(IWebDriver driver, ScenarioContext injectedContext) : base(driver)
        {
            context = injectedContext;
        }
        

        [Then(@"I click on Edit button")]
        public void ThenIClickOnEditButton()
        {
            CurrentPage = GetInstance<ArticleShedulerPage>(Driver);
            CurrentPage.As<ArticleShedulerPage>().ClickEditTemplate();
        }

        [Then(@"I entered the inputs")]
        public void ThenIEnteredTheInputs()
        {
            CurrentPage.As<ArticleShedulerPage>().EditArticle();
        }

        [Then(@"I saved the edited template")]
        public void ThenISavedTheEditedTemplate()
        {
            CurrentPage.As<ArticleShedulerPage>().SaveEditArticle();
        }


        [Then(@"the record should be edited to the list succesfully")]
        public void ThenTheRecordShouldBeEditedToTheListSuccesfully()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckEditTemplate();
        }

        [Then(@"I deleted an article")]
        public void ThenIDeletedAnArticle()
        {
            CurrentPage.As<ArticleShedulerPage>().DeleteArticle();
        }

        [Then(@"the edited record should not be added to the list")]
        public void ThenTheEditedRecordShouldNotBeAddedToTheList()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckEditTemplate();
        }

    }
}
