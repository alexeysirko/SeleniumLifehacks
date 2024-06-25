using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ExampleProject.Hooks
{
    [Binding]
    internal class HooksClass
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
