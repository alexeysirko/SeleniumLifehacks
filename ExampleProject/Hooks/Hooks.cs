using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using TechTalk.SpecFlow;

namespace ExampleProject.Hooks
{
    [Binding]
    internal class Hooks
    {
        private Browser browser;
        private static readonly JsonSettingsFile settings = new("config.json");

        [BeforeScenario("@TC25")]

        public void Setup()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
        }

        [AfterScenario("@TC25", Order = 2)]

        public void TearDown()
        {
            browser.Quit();
        }
    }
}
