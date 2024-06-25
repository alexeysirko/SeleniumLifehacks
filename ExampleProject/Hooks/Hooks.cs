using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using TechTalk.SpecFlow;

namespace ExampleProject.Hooks
{
    [Binding]
    internal class Hooks
    {
        private readonly Browser browser = AqualityServices.Browser;
        private static readonly JsonSettingsFile settings = new("config.json");

        [BeforeScenario]

        public void Setup()
        {
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }

        [AfterScenario]

        public void TearDown()
        {
            browser.Quit();
        }
    }
}
