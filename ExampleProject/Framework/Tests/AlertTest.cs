using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V130.Page;

namespace ExampleProject.Framework.Tests
{
    internal class AlertTest : BaseTest
    {
        private JavaScriptAlertPage jsAlertPage = new();

        [Test]
        public void AlertsTest()
        {
            mainPage.ClickNavigationLink("JavaScript Alerts");
            jsAlertPage.ClickJSAlertBtn();
            browser.HandleAlert(Aquality.Selenium.Browsers.AlertAction.Accept);
            Assert.That(jsAlertPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
            CheckDevtoolsMetrics();
        }

        [Test]
        public void CheckDevtoolsGeoPosition()
        {
            browser.Driver.Navigate().GoToUrl("https://my-location.org");

            using var devtools = AqualityServices.Browser.DevTools.GetDevToolsSession();
            devtools.SendCommand(new SetGeolocationOverrideCommandSettings
            {
                Latitude = 37.7749,
                Longitude = -122.4194,
                Accuracy = 1
            });
            AqualityServices.Browser.Driver.Navigate().Refresh();
            AqualityServices.Browser.DevTools.CloseDevToolsSession();
        }
    }
}
