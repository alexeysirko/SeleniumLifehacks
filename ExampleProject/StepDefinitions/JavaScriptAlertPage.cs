using ExampleProject.Framework.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    internal class JavaScriptAlertPageStep
    {
        private JavaScriptAlertPage alertpage = new();

        [When(@"I generate JS alert on the Javascript alert page")]
        public void GenerateJSAlert()
        {
            alertpage.ClickJSAlertBtn();
        }

        [Then(@"Success message displayed on the alert page")]
        public void SuccessmsgDisplayed()
        {
            Assert.That(alertpage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
