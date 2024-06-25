using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System;

namespace ExampleProject.Framework.Tests
{
    internal class DynamicControlsTests : BaseTest
    {
        private DynamicControlsPage dynamicControlsPage = new();
        private static readonly string randomString = Guid.NewGuid().ToString();
    
        [Test]
        public void DynamicControlsTest()
        {
            //mainPage.ClickNavigationLink("Dynamic Controls");
            dynamicControlsPage.clickEnableBtn();
            Assert.That(dynamicControlsPage.isInputEnabled(), "input is not enabled");
            dynamicControlsPage.inputText(randomString);
            Assert.That(dynamicControlsPage.getInputTextValue() , Is.EqualTo(randomString) , "Text is not inputed");
        }
    }
}
