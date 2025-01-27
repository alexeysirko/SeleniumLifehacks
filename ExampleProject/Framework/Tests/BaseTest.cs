﻿using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ExampleProject.Framework.Tests
{
    [AllureNUnit]
    [AllureLink("Website", "https://the-internet.herokuapp.com")]  
    [AllureTms("If you use allure TMS system")]
    internal class BaseTest
    {
        protected MainPage mainPage = new();
        protected Browser browser;
        protected static readonly JsonSettingsFile settings = new("config.json");
        protected static readonly JsonSettingsFile testdata = new("testdata.json");

        [SetUp]
        [AllureBefore("Start the test browser")]
        public void SetUp()
        {
            AllureApi.AddAttachment("settings file", "text/plain", "Resources/settings.json");

            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.Driver.Navigate().GoToUrl(settings.GetValue<string>("url"));
        }

        [TearDown]
        [AllureAfter("Close the browser")]       
        public void TearDown()
        {   
            byte[] screenshot = AqualityServices.Browser.GetScreenshot();
            AllureApi.AddAttachment("Screenshot", "image/png", screenshot);
            
            browser.Quit();
        }
    }
}
