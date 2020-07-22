using OpenQA.Selenium;
using Talent.Automation.Page;
using Talent.Automation.Steps.BaseStep;
using TechTalk.SpecFlow;


namespace Talent.Automation.Steps
{
    [Binding]
    public class ArticleSchedulerSteps : Base
    {
        public ArticleSchedulerSteps(IWebDriver driver) : base(driver)
        {
        }

        [Given(@"I am on ArticleSheduler page")]
        public void GivenIAmOnArticleShedulerPage()
        {
            CurrentPage = GetInstance<ArticleShedulerPage>(Driver);
        }

        [Then(@"I clicked on Add template button")]
        public void ThenIClickedOnAddTemplateButton()
        {
            CurrentPage.As<ArticleShedulerPage>().ClickOnAddTemplateBtn();
        }

        [Then(@"I entered template name and description")]
        public void ThenIEnteredTemplateNameAndDescription()
        {
            CurrentPage.As<ArticleShedulerPage>().TemplateNameAndDescription();
        }

        [Then(@"I search for an article and choosed it")]
        public void ThenISearchForAnArticleAndChoosedIt()
        {
            CurrentPage.As<ArticleShedulerPage>().SearchForArticle();
        }

        [Then(@"I Added rules to the template")]
        public void ThenIAddedRulesToTheTemplate()
        {
            CurrentPage.As<ArticleShedulerPage>().AddRulesToArticle();
        }

        [Then(@"I saved the template")]
        public void ThenISavedTheTemplate()
        {
            CurrentPage.As<ArticleShedulerPage>().SaveTemplate();
        }

        [Then(@"the record should be added to the list succesfully")]
        public void ThenTheRecordShouldBeAddedToTheListSuccesfully()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckAddTemplate();
        }

        [Then(@"the record should not be added to the list")]
        public void ThenTheRecordShouldNotBeAddedToTheList()
        {
            CurrentPage.As<ArticleShedulerPage>().CheckAddTemplate();
        }

    }
}
