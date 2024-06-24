using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class DataTableTests : BaseTest
    {
        private DataTablesPage dataTablesPage = new();

        [Test]
        public void DataTablesTest()
        {
            mainPage.ClickNavigationLink("Sortable Data Tables");
            var actualSum = 0.00;
            foreach (string due in dataTablesPage.GetFirstDueList())
            {
                actualSum += StringUtils.GetDoubleFromString(due);
            }
            Assert.AreEqual(testdata.GetValue<double>("dataTable.expectedSum"), actualSum, "Sum is not correct");
        }
    }
}
