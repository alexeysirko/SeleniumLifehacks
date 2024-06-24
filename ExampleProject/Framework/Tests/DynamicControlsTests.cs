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
            mainPage.ClickNavigationLink("Dynamic Controls");
            dynamicControlsPage.ClickEnableBtn();
            Assert.That(dynamicControlsPage.IsInputEnabled(), "Input is not enabled");
            dynamicControlsPage.InputText(randomString);
            Assert.That(randomString, Is.EqualTo(dynamicControlsPage.GetInputTextValue()),
                "Text is not displayed");
        }
    }
}
