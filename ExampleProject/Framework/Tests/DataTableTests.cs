using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    [AllureFeature("User Interface features")]
    [AllureEpic("Web interface")]
    internal class DataTableTests : BaseTest
    {
        private DataTablesPage dataTablesPage = new();

        [Test]
        [AllureSuite("UI tests")]
        [AllureOwner("Alexey Sirko")]
        [AllureSeverity(SeverityLevel.minor)]
        public void DataTablesTest()
        {
            AllureApi.Step(nameof(mainPage.ClickNavigationLink));
            mainPage.ClickNavigationLink("Sortable Data Tables");
            var actualSum = 0.00;
            foreach (string due in dataTablesPage.GetFirstDueList())
            {
                actualSum += StringUtils.GetDoubleFromString(due);
            }
            Assert.That(testdata.GetValue<double>("dataTable.expectedSum"), Is.EqualTo(actualSum), "Sum is not correct");
        }
    }
}
