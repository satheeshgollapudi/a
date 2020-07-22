using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using MVPStudio.Framework.Extensions;
using Talent.Automation.Steps.BaseStep;

namespace Talent.UI.Page.EmployerArticlePage
{
    class ArticleManagePage:Base
    {

        public ArticleManagePage(IWebDriver driver) : base(driver)
        {
        }


        //Elements
        #region
        private IWebElement NewArtileButton => Driver.WaitForElement(By.XPath("//button[@class='ant-btn ant-btn-primary']"));
        private IWebElement DeleteArtileButton => Driver.WaitForElement(By.XPath("(//span[contains(.,'Delete')])[1]"));
        private IWebElement DeleteConfirmButton => Driver.WaitForElement(By.XPath("//button[@type='button'][contains(.,'Confirm')]"));

        #endregion

        public void NavigateToNewArticlePage()
        {
            NewArtileButton.WaitForClickable(Driver);
            NewArtileButton.Click();
        }

        public void DeleteArticle()
        {
            DeleteArtileButton.WaitForClickable(Driver);
            DeleteArtileButton.Click();
            DeleteConfirmButton.Click();
        }
    }
}
