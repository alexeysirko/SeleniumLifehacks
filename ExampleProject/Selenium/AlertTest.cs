using NUnit.Framework;
using OpenQA.Selenium;

namespace ExampleProject.Selenium
{
    internal class AlertsTest : BaseTest
    {
        private static readonly By jsAlertBtn = By.XPath(string.Format(preciseTextXpath, "JavaScript Alerts"));
        private static readonly By clickForJSAlertBtn = By.XPath("//button[@onclick='jsAlert()']");
        

        [Test]
        public void AlertTest()
        {
            driver.FindElement(jsAlertBtn).Click();
            driver.FindElement(clickForJSAlertBtn).Click();
            //accept alert
            //assert success message
        }
    }
}
