using System;
using MVPStudio.Framework.Config;
using MVPStudio.Framework.Extensions;
using MVPStudio.Framework.Helps.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;
using Talent.UI.Page.EmployerArticlePage;
using TechTalk.SpecFlow;

[Binding]
public class Create_Article_EmployerSteps : Base

{
    public Create_Article_EmployerSteps(IWebDriver driver) : base(driver)
    {
        ExcelUtil.SetDataSource("Employer_Article.xlsx");
    }

    [When(@"I press the add new article button,fill up all the information and click save button")]
    public void WhenIPressTheAddNewArticleButtonFillUpAllTheInformationAndClickSaveButton()
    {
        ArticleManagePage articleManagePage = new ArticleManagePage(Driver);
        articleManagePage.NavigateToNewArticlePage();
        CreatePage createPage = new CreatePage(Driver);
        createPage.ReadDataFromArticleSheetAndAddNewArticle();
    }

    [Then(@"the new article I just wrote should be shown on the article list")]
    public void ThenTheNewArticleIJustWroteShouldBeShownOnTheArticleList()
    {
        var row = ExcelUtil.DataSet.SelectSheet("manage_articles").GetRowByKey("create");
        string articleTitle = row.GetValue("Name");

        //do the assertion to validate if there is an article that we just created
        FindArticleFromUl(articleTitle);
    }

    public void FindArticleFromUl(string articleTitle)
    {
        //navigate to manage article page
        Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "onboarding/article"));
        Driver.WaitForPageLoaded("article");

        //validate each article's header
        var judge = true;
        while (judge)
        {
            for (int i = 1; i <= 5; i++)
            {
                var titleText = Driver.FindElement(By.XPath("/html/body/div[1]/div/section/section/main/div/div[3]/div/div/div/div/div/div/div/div/ul/li[" + i + "]/div[1]/div[1]/div/h4")).Text;
                if (titleText == articleTitle)
                {
                    judge = false;
                    Assert.IsFalse(judge);
                    break;
                }
            }

            if (judge == false)
            {
                break;
            }
            //click the next page button
            var nextPagebtn = Driver.FindElement(By.XPath("(//a[@class='ant-pagination-item-link'])[2]"));
            if (nextPagebtn.Enabled)
            {
                nextPagebtn.Click();
            }
            else
            {
                Assert.IsFalse(judge);
                return;
            }
        }
    }

}


