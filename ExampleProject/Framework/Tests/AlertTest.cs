using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    [AllureEpic("Browser functions")]
    [AllureFeature("Browser actions")]  
    internal class AlertTest : BaseTest
    {
        private JavaScriptAlertPage jsAlertPage = new();

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureLink("Website", "https://the-internet.herokuapp.com/javascript_alerts")]
        [AllureSuite("Browser tests")]       
        [AllureIssue("DE-5")]
        [AllureDescription("As user I want to accept alert on the page popup")]
        public void AlertsTest()
        {
            AllureApi.Step(nameof(mainPage.ClickNavigationLink));
            mainPage.ClickNavigationLink("JavaScript Alerts");
            AllureApi.Step(nameof(jsAlertPage.ClickJSAlertBtn));
            jsAlertPage.ClickJSAlertBtn();
            browser.HandleAlert(Aquality.Selenium.Browsers.AlertAction.Accept);
            Assert.That(jsAlertPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
