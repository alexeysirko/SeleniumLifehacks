using ExampleProject.Models;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ExampleProject.StepDefinitions
{
    [Binding]
    public class TablesStepDefinitions
    {
        private Hero _hero;

        [When(@"I entered the following hero information:")]
        public void GivenIEnteredTheFollowingHeroInformation(Table table)
        {
            _hero = table.CreateInstance<Hero>();
        }

        [Then(@"Hero information is equal to:")]
        public void ThenHeroInformationIsEqualTo(Table table)
        {
            var expectedHero = table.CreateInstance<Hero>();         
            Assert.Multiple(() =>
            {
                Assert.That(expectedHero.Name, Is.EqualTo(_hero.Name));
                Assert.That(expectedHero.Birthdate, Is.EqualTo(_hero.Birthdate));
                Assert.That(expectedHero.Occupation, Is.EqualTo(_hero.Occupation));
                Assert.That(expectedHero.FavoriteWeapon, Is.EqualTo(_hero.FavoriteWeapon));
                Assert.That(expectedHero.Health, Is.EqualTo(_hero.Health));
            });
        }
    }
}
