using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using MVPStudio.Framework.Base;
using MVPStudio.Framework.Helps;
using OpenQA.Selenium;
using Talent.Automation.Page;
using TechTalk.SpecFlow;

namespace Talent.Automation.Hooks
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentTest _step;

        [BeforeTestRun]
        public static void SetupFramework(IObjectContainer objectContainer)
        {
            new FrameworkInitializeHook().InitializeSettings();
            _ = new WebDriverSetup(objectContainer);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _featureName = ReportContext.ExtendReport.CreateTest<Feature>(featureContext.FeatureInfo.Title); //name of feature file
        }
        [BeforeScenario]
        public void TestStart(ScenarioContext scenarioContext)
        {
            _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title); //name of scenario
        }
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext, IWebDriver driver)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            switch (stepType)
            {
                case "Given":
                    _step = _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                case "When":
                    _step = _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                case "And":
                    _step = _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                case "Then":
                    _step = _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    break;
                default:
                    break;
            }

            if (scenarioContext.TestError != null)
            {
                var screenshotFilePath = ScreenshotHelper.TryToTakeScreenshot(driver);
                if (screenshotFilePath != null)
                {
                    _step.Fail(scenarioContext.TestError.Message,
                    MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotFilePath).Build());
                }
                else
                {
                    _step.Fail(scenarioContext.TestError.Message);
                }
            }
        }
        [AfterScenario]
        public static void TearDownScenario()
        {
            // reset browser
            // driver.ResetDriver();
        }
        [AfterTestRun]
        public static void EndTest(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
            ReportContext.ExtendReport.Flush();
        }
    }
}
