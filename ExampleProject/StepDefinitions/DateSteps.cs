using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    public class DateSteps
    {
        private DateTime _currentDate;
        private DateTime _futureDate;

        [Given(@"today is (.*)")]
        public void GivenTodayIs(DateTime date)
        {
            _currentDate = date;
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
