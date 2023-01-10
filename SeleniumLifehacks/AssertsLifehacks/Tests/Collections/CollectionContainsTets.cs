using FluentAssertions;

namespace AssertsLifehacks.Tests.Collections;

public class CollectionContainsTets : CollectionsTests
{
    /// <summary>
    /// Perfect
    /// </summary>
    [Test]
    public void FluentContains()
    {
        // PASS
        Persons.Should().ContainEquivalentOf(PersonFromList);

        //PASS only with overrided equals
        Persons.Should().Contain(PersonFromList);

        /*
         Expected _persons {
        AssertsLifehacks.Person
        {
            Age = 50, 
            Name = "Brian"
        }, 
        AssertsLifehacks.Person
        {
            Age = 20, 
            Name = "Alex"
        }, 
        AssertsLifehacks.Person
        {
            Age = 18, 
            Name = "Anna"
        }
        }
        to contain AssertsLifehacks.Person
        {
            Age = 45, 
            Name = "Ben"
        }
        */
        Persons.Should().ContainEquivalentOf(PersonNotFromList);
    }

    /// <summary>
    /// Works only with overrided Equals method.
    /// </summary>
    [Test]
    public void ThatContains()
    {
        // PASS
        Assert.Contains(PersonFromList, Persons);
        Assert.That(Persons, Does.Contain(PersonFromList));

        // Expected: some item equal to <AssertsLifehacks.Person>
        // But was:  < < AssertsLifehacks.Person >, < AssertsLifehacks.Person >, < AssertsLifehacks.Person > >
        Assert.Contains(PersonNotFromList, Persons);
        Assert.That(Persons, Does.Contain(PersonNotFromList));
    }

    /// <summary>
    /// Same as Contains
    /// </summary>
    [Test]
    public void ThatHas()
    {
        // PASS
        Assert.That(Persons, Has.Member(PersonFromList));

        // Expected: some item equal to <AssertsLifehacks.Person>
        // But was:  < < AssertsLifehacks.Person >, < AssertsLifehacks.Person >, < AssertsLifehacks.Person > >
        Assert.That(Persons, Has.Member(PersonNotFromList));
    }
}
