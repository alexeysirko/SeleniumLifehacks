using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    public class DateSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private const string SAVED_DATE_KEY = "SAVED_DATE_KEY";
        private DateTime _savedDate;
        private DateTime _futureDate;

        public DateSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation(@"in (\d+) days?")]
        public DateTime InXDaysTransform(int days)
        {
            var currentDate = (DateTime)_scenarioContext[SAVED_DATE_KEY];
            return currentDate.AddDays(days);
        }

        [Given(@"today is (.*)")]
        public void GivenTodayIs(DateTime date)
        {
            _scenarioContext.Add(SAVED_DATE_KEY, date);
        }

        [When(@"I add (.*)")]
        public void WhenIAdd(DateTime futureDate)
        {
            _futureDate = futureDate;
        }

        [Then(@"the date should be (.*)")]
        public void ThenTheDateShouldBe(DateTime expectedDate)
        {
            Assert.That(expectedDate, Is.EqualTo(_futureDate));
        }
    }
}
