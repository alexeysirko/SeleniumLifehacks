using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace ExampleProject.Selenium
{
    internal class IFrameTests : BaseTest
    {
        private static readonly By framesBtn = By.XPath(string.Format(preciseTextXpath, "Frames"));
        private static readonly By iframeBtn = By.XPath(string.Format(preciseTextXpath, "iFrame"));
        private static readonly By editBtn = By.XPath(string.Format(preciseTextXpath, "Edit"));
        private static readonly By undoBtn = By.XPath(string.Format(preciseTextXpath, "Undo"));
        private static readonly string textIsNotDisplayedMsg = "Text is not displayed";
        private static readonly string randomValue = Guid.NewGuid().ToString();
        private static readonly string initText = "Your content goes here.";

        [Test]
        public void IFrameTest()
        {
            driver.FindElement(framesBtn).Click();
            driver.FindElement(iframeBtn).Click();
            //input text to the textfield
            Assert.True(driver.FindElement(By.XPath(string.Format(preciseTextXpath, initText + randomValue))).Displayed,
                    textIsNotDisplayedMsg);

            driver.FindElement(editBtn).Click();
            driver.FindElement(undoBtn).Click();
            //assert text is not displayed
        }
    }
}