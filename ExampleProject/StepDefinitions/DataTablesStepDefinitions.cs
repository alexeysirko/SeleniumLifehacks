using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    public class DataTablesStepDefinitions
    {
        private ScenarioContext _scenarioContext;

        public DataTablesStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"The main page is opened")]
        public void GivenTheMainPageIsOpened()
        {
            throw new PendingStepException();
        }

        [When(@"Click on '([^']*)' link")]
        public void WhenClickOn(string linkText)
        {
            throw new PendingStepException();
        }

        [Then(@"Data Tables page is opened")]
        public void ThenDataTablesPageIsOpened()
        {
            throw new PendingStepException();
        }

        [When(@"Find ""([^""]*)"" value in the ""([^""]*)"" column in the second table and save with key ""([^""]*)""")]
        public void WhenFindValueInTheColumnInTheSecondTableAndSaveWithKey(string value, string columnName, string key)
        {
            _scenarioContext.Add(key, value);
            throw new PendingStepException();
        }

        [Then(@"Value with key ""([^""]*)"" is saved as ""([^""]*)""")]
        public void ThenValueWithKeyIsSavedAs(string key, string value)
        {
            _scenarioContext.TryGetValue<string>(key, out string savedData);
           
            throw new PendingStepException();
        }

        [When(@"Sort the table by ""([^""]*)"" column")]
        public void WhenSortTheTableByColumn(string columnText)
        {
            throw new PendingStepException();
        }

        [Then(@"Data table is sorted by ""([^""]*)"" column")]
        public void ThenDataTableIsSortedBy(string columnText)
        {
            throw new PendingStepException();
        }

        [When(@"Save values in the ""([^""]*)"" column as list with key ""([^""]*)"":")]
        public void WhenSaveValuesInTheColumnAsListWithKey(string columnText, string key, Table lastNamesTable)
        {
            var rows = lastNamesTable.Rows;
            Assert.Multiple(() =>
            {
                foreach (var row in rows)
                {
                    Assert.That(row, Is.Not.Null);
                }
            });
            throw new PendingStepException();
        }

        [Then(@"Values with key ""([^""]*)"" are saved")]
        public void ThenValuesWithKeyAreSaved(string key)
        {
            throw new PendingStepException();
        }
    }
}
