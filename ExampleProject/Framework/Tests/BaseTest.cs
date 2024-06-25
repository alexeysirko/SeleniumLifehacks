using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.Framework.Tests
{
    
    internal class BaseTest
    {
        //protected MainPage mainPage = new();
        protected Browser browser;
        protected static readonly JsonSettingsFile settings = new("config.json");
        protected static readonly JsonSettingsFile testdata = new("testdata.json");

        
        public void Setup()
        {

            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(settings.GetValue<string>("url"));
            browser.WaitForPageToLoad();
        }


        
        public void Teardown()
        {
            browser.Quit();
        }
    }
}
