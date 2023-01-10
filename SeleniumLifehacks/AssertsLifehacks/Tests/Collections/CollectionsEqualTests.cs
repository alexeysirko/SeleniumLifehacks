using FluentAssertions;

namespace AssertsLifehacks.Tests.Collections;

public class CollectionsEqualTests : CollectionsTests
{
    /// <summary>
    /// Good
    /// </summary>
    [Test]
    public void FluentEquivalent()
    {
        // PASS
        Persons.Should().BeEquivalentTo(SamePersons);

        /*
        Expected Persons[1] to be AssertsLifehacks.Person
        {
            Age = 99, 
            Name = "Bob"
        }, but found AssertsLifehacks.Person
        {
            Age = 20, 
            Name = "Alex"
        }
        */
        Persons.Should().BeEquivalentTo(DifferentPersons);
    }

    /// <summary>
    /// Works only with overrided Equals
    /// </summary>
    [Test]
    public void CollectionsEquals()
    {
        // PASS
        Assert.That(Persons, Is.EqualTo(SamePersons));
        Assert.That(Persons, Is.EquivalentTo(SamePersons));

        /*
            Expected and actual are both <System.Collections.Generic.List`1[AssertsLifehacks.Person]> with 3 elements
            Values differ at index [1]
            Expected: <AssertsLifehacks.Person>
            But was:  <AssertsLifehacks.Person>
        */
        Assert.That(Persons, Is.EqualTo(DifferentPersons));

        /*
            Expected: equivalent to < <AssertsLifehacks.Person>, <AssertsLifehacks.Person>, <AssertsLifehacks.Person> >
            But was:  < <AssertsLifehacks.Person>, <AssertsLifehacks.Person>, <AssertsLifehacks.Person> >
            Missing (1): < <AssertsLifehacks.Person> >
            Extra (1): < <AssertsLifehacks.Person> >
        */
        Assert.That(Persons, Is.EquivalentTo(DifferentPersons));
    }
}
