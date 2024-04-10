using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace ExampleProject.Selenium
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By dynamicControl = By.XPath(string.Format(preciseTextXpath, "Dynamic Controls"));
        private static readonly By enableBtn = By.XPath(string.Format(preciseTextXpath, "Enable"));
        private static readonly By inputField = By.XPath("//*[@id='input-example']//input");
        private static readonly string randomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            driver.FindElement(dynamicControl).Click();
            driver.FindElement(enableBtn).Click();
            var inputFieldElement = driver.FindElement(inputField);
            Assert.That(IsEnabled(inputFieldElement), "imput is not enabled");
            inputFieldElement.SendKeys(randomValue);
            Assert.That(driver.FindElement(inputField).GetAttribute("value"), Is.EqualTo(randomValue), "Text is not displayed");
        }

        private bool IsEnabled(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (TimeoutException)
            {
                return false;
            }
            return true;
        }
    }
}
