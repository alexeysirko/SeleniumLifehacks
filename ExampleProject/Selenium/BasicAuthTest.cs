using NUnit.Framework;
using OpenQA.Selenium;

namespace ExampleProject.Selenium
{
    internal class BasicAuthTest : BaseTest
    {
        INetwork networkInterceptor = null;
        private static readonly By basicAuth = By.XPath(string.Format(preciseTextXpath, "Basic Auth"));
        private static readonly By successAuth = By.XPath(string.Format(partialTextXpath, "Congratulations! You must have the proper credentials"));

        [SetUp]
        public void Authorize()
        {
            NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
            {
                UriMatcher = uri => uri.Host.Contains("internet"),
                Credentials = new PasswordCredentials("admin", "admin")
            };

            networkInterceptor = driver.Manage().Network;
            networkInterceptor.AddAuthenticationHandler(handler);
            networkInterceptor.StartMonitoring();
        }

        [Test]
        public void SuccessfulBasicAuthTest()
        {
            driver.FindElement(basicAuth).Click();
            // In video you can see Assert.True instead of Assert.That and it's old style of Nunit asserts. Now it is recommended to use Assert.That constructions
            Assert.That(driver.FindElement(successAuth).Displayed, "Message is not displayed");
        }

        [TearDown]
        public void TearItDown()
        {
            networkInterceptor.StopMonitoring();
        }
    }
}
