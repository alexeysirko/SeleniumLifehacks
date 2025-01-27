using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject.Framework.Tests
{
    internal class DynamicLoadTests : BaseDragAndDropTest
    {
        private DynamicLoadPage _dynamicLoadPage = new();

        [SetUp]
        public void GoToLink()
        {
            _browser.Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
        }

        [Test]
        public void DynamicLoadTest()
        {
            _dynamicLoadPage.ClickStartBtn();
            Assert.That(_dynamicLoadPage.WaitLoadingBarForDisplayed(), "Loading bar is not displayed after wait");

            const string ExpectedFinishText = "Hello World!";
            string actualText = _dynamicLoadPage.GetFinishLabelText();
            Assert.That(ExpectedFinishText, Is.EqualTo(actualText), "Finish text is not correct");
        }
    }
}
