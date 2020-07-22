using OpenQA.Selenium;
using Talent.Automation.Steps.BaseStep;

namespace Talent.Automation.Page
{
    public class TalentFeedPage : Base
    {
        public TalentFeedPage(IWebDriver driver) : base(driver)
        {
        }

        public string TalentFeedPageTitle()
        {
            return Driver.Title;
        }
    }
}
