using NUnit.Framework;
using OpenQA.Selenium;

namespace ExampleProject.Selenium
{
    internal class AlertsTest : BaseTest
    {
        private static readonly By jsAlertBtn = By.XPath(string.Format(preciseTextXpath, "JavaScript Alerts"));
        private static readonly By clickForJSAlertBtn = By.XPath("//button[@onclick='jsAlert()']");
        private static readonly By successMessageField = By.XPath(string.Format(preciseTextXpath, "You successfully clicked an alert"));

        [Test]
        public void AlertTest()
        {
            driver.FindElement(jsAlertBtn).Click();
            driver.FindElement(clickForJSAlertBtn).Click();
            driver.SwitchTo().Alert().Accept();
            Assert.That(driver.FindElement(successMessageField).Displayed, "Success message is not found");
        }
    }
}
