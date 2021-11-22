using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace NavAutomation.Hooks
{
    [Binding]
    public sealed class Hook
    {
        public static ExtentTest featurename;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        public static string reportpath;
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private DriverHelper _driverHelper;
        private static Random random = new Random();

        public Hook(DriverHelper driverHelper, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this._driverHelper = driverHelper;
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestStart()
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Report//index.html";
            ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(Path);
            htmlreporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext )
        {
            featurename = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions Options = new ChromeOptions();
            Options.AddArgument("user-data-dir=E:/Profiles/WebAutomation");
            Options.AddArgument("profile-directory=Profile 4");
            Options.AddArgument("start-maximized");
            _driverHelper.Driver = new ChromeDriver(Options);
            scenario = featurename.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                var mediaEntity = TakeScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("Passed",mediaEntity);
                    //string Path = TakeScreenshot();
                    //scenario.AddScreenCaptureFromPath(Path);
                }
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if(_scenarioContext.TestError != null)
            {
                var mediaEntity = TakeScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                    //string Path = TakeScreenshot();
                    //scenario.AddScreenCaptureFromPath(Path);
                }
                else if(stepType == "When")
                {
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    //string Path = TakeScreenshot();
                    //scenario.AddScreenCaptureFromPath(Path);
                }
                else if(stepType == "Then") {
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    //string Path = TakeScreenshot();
                    //scenario.AddScreenCaptureFromPath(Path);
                }
                else if(stepType == "And")
                {
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    //string Path = TakeScreenshot();
                    //scenario.AddScreenCaptureFromPath(Path);
                }
            }

        }
        [AfterScenario]
        public void AfterScenario()
        {
            //_driverHelper.Driver.Dispose();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
        public MediaEntityModelProvider TakeScreenshot(string Name)
        {
          var screenshot = ((ITakesScreenshot)_driverHelper.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,Name).Build();
        }
        //public string TakeScreenshot()
        //{
        //    string Path = AppDomain.CurrentDomain.BaseDirectory.ToString() + "ScreenShots//" + RandomString(6) + ".png" ;
        //    Screenshot screenshot = ((ITakesScreenshot)_driverHelper.Driver).GetScreenshot();
        //    screenshot.SaveAsFile(Path, ScreenshotImageFormat.Png);
        //    return Path;
        //}
        //public static string RandomString(int length)
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    return new string(Enumerable.Repeat(chars, length)
        //        .Select(s => s[random.Next(s.Length)]).ToArray());
        //}
    }
}
