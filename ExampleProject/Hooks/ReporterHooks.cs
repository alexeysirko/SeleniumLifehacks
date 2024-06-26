using Aquality.Selenium.Browsers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ExampleProject.Hooks
{
    [Binding]
    internal class ReporterHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private const string Keyword = "KEYWORD";

        public ReporterHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeFeature]
        public static void StartReport(FeatureContext featureContext)
        {
            string featureName = featureContext.FeatureInfo.Title;
            Reporter.CreateFeature(featureName);           
        }

        [BeforeScenario]
        public void StartScenario()
        {
            string scenarioName = _scenarioContext.ScenarioInfo.Title;
            Reporter.CreateScenario(scenarioName);
        }

        [BeforeStep]
        public void StartStep()
        {
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = _scenarioContext.StepContext.StepInfo.Text;
            Reporter.AddStep(stepType, stepName);
        }

        [AfterScenario("@TC25", Order = 1)]
        public static void EndScenarioWithBrowser()
        {
            var file = ((ITakesScreenshot)AqualityServices.Browser.Driver).GetScreenshot();
            var img = file.AsBase64EncodedString;

            Reporter.LogScreenshot("Ending test", img);           
        }

        [AfterScenario(Order = 3)]
        public static void EndScenario()
        {
            Reporter.EndReporting();
        }
    }
}
