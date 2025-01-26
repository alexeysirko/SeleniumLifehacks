using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V129.Page;
using System;
using System.Collections.Generic;

namespace ExampleProject.Framework.Tests
{
    internal class BaseTest
    {
        protected MainPage mainPage = new();
        protected Browser browser;
        protected static readonly JsonSettingsFile settings = new("config.json");
        protected static readonly JsonSettingsFile testdata = new("testdata.json");

        [SetUp]
        public void SetUp()
        {
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.Driver.Navigate().GoToUrl(settings.GetValue<string>("url"));
        }

        [TearDown]
        [Order(1)]
        public void CheckDevtoolsGeoPosition()
        {
            using var devtools = AqualityServices.Browser.DevTools.GetDevToolsSession();
            devtools.SendCommand(new SetGeolocationOverrideCommandSettings
            {
                Latitude = 37.7749,
                Longitude = -122.4194,
                Accuracy = 1
            });

            browser.Driver.Navigate().GoToUrl("https://my-location.org");

            AqualityServices.Browser.DevTools.CloseDevToolsSession();
        }
        
        [TearDown]
        [Order(2)]
        public void CheckDevtoolsMetrics()
        {
            using var devtools = AqualityServices.Browser.DevTools.GetDevToolsSession();
            DevToolsPerformanceExtensions.EnablePerformanceMonitoring(AqualityServices.Browser.DevTools);
            IDictionary<string, double> metrics = DevToolsPerformanceExtensions.GetPerformanceMetrics(AqualityServices.Browser.DevTools).Result;
            foreach (var metric in metrics)
            {
                Console.WriteLine($"metric: {metric.Key}, value: {metric.Value}");
            }

            AqualityServices.Browser.DevTools.CloseDevToolsSession();
        }

        [TearDown]
        [Order(71)]
        public void CloseBrowser()
        {
            //browser.Quit();
        }
    }
}
