//using MVPStudio.Framework.Config;
//using OpenQA.Selenium;
//using System;
//using TechTalk.SpecFlow;

//namespace Talent.Automation.Steps.BaseStep
//{
//    public class Navigation
//    {
//        private IWebDriver Driver { get; set; }
//        public Navigation(IWebDriver Driver)
//        {
//            this.Driver = Driver;
//        }


//        [Given(@"I navigate to '(.*)' page")]
//        public virtual void GivenINavigateToPage(string page)
//        {
//            switch (page)
//            {
//                case "login":
//                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "/user/login"));

//                    break;
//                case "talent profile":
//                    Driver.Navigate().GoToUrl(new Uri(Settings.AUT + "/profile"));

//                    break;
//                default:
//                    break;
//            }
//        }

//        [Then(@"I should see updated skill in the Skill list")]
//        public void ThenIShouldSeeUpdatedSkillInTheSkillList()
//        {

//            //SkillsPage validateEdit = new SkillsPage(Driver);
//            //  validateEdit.ValidateEditSkills("C");

//        }

//    }
//}
