using Aquality.Selenium.Browsers;
using ExampleProject.Framework.Pages;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class BasicAuthTest : BaseTest
    {
        private BasicAuthPage basicAuthPage = new();

        [SetUp]
        public void BasicAuthorisation()
        {
            browser.RegisterBasicAuthenticationAndStartMonitoring("internet",
                testdata.GetValue<string>("basicAuth.login"),
                testdata.GetValue<string>("basicAuth.password"));
        }

        [Ignore("Aquality basic auth doesn't work")]
        [Test]
        public void BasicAuthSuccessfulTest()
        {
            mainPage.ClickNavigationLink("Basic Auth");
            Assert.That(basicAuthPage.IsSuccessMessageDisplayed(), "Success message is not displayed");
        }
    }
}
