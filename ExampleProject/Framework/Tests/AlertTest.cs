using ExampleProject.Framework.Pages;
using NUnit.Framework;

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
            Assert.IsTrue(jsAlertPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
