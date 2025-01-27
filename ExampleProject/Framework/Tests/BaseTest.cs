using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Utilities;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System.Collections.Generic;
using System;

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

        protected void CheckDevtoolsMetrics()
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
        public void CloseBrowser()
        {
            browser.Quit();
        }
    }
}
