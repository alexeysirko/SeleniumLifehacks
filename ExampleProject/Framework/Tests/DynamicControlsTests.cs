using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using NUnit.Framework;
using System;

namespace ExampleProject.Framework.Tests
{
    [AllureFeature("User Interface features")]
    [AllureEpic("Web interface")]
    internal class DynamicControlsTests : BaseTest
    {
        private DynamicControlsPage dynamicControlsPage = new();
        private static readonly string randomString = Guid.NewGuid().ToString();
    
        [Test]
        [AllureSuite("UI tests")]
        [AllureSeverity(SeverityLevel.normal)]
        public void DynamicControlsTest()
        {
            AllureApi.Step(nameof(mainPage.ClickNavigationLink));
            mainPage.ClickNavigationLink("Dynamic Controls");
            AllureApi.Step(nameof(dynamicControlsPage.ClickEnableBtn));
            dynamicControlsPage.ClickEnableBtn();
            Assert.That(dynamicControlsPage.IsInputEnabled(), "Input is not enabled");
            AllureApi.Step(nameof(dynamicControlsPage.InputText));
            dynamicControlsPage.InputText(randomString);
            Assert.That(randomString, Is.EqualTo(dynamicControlsPage.GetInputTextValue()),
                "Text is not displayed");
        }
    }
}
