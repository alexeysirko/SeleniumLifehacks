using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    internal class BrowserStep
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        private const string Keyword = "KEYWORD";

        public BrowserStep(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [When(@"I accept the alert")]
        public void AcceptTheAlert()
        {
            AqualityServices.Browser.HandleAlert(AlertAction.Accept);
            _scenarioContext.Add(Keyword, "Some important value");
            _featureContext.Add(Keyword, "Feature data");
        }

        [Given(@"Test passing step")]
        public void GivenTestPassingStep()
        {
            string featureValue = (string)_featureContext[Keyword];
            Assert.Pass(featureValue);
        }

        [When(@"Test fails")]
        public void WhenTestFails()
        {
            string valueFromPreviousStep = (string)_scenarioContext[Keyword];
            Assert.Fail(valueFromPreviousStep);
        }
    }
}
