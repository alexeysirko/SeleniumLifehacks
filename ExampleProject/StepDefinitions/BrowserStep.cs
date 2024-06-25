using Aquality.Selenium.Browsers;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    internal class BrowserStep
    {
        [When(@"I accept the alert")]
        public void AcceptTheAlert()
        {
            AqualityServices.Browser.HandleAlert(AlertAction.Accept);
        }
    }
}
