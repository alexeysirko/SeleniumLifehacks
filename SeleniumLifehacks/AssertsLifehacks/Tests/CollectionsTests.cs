using FluentAssertions;
using NUnit.Framework.Constraints;

namespace AssertsLifehacks.Tests;

public class CollectionsTests
{
    private readonly Person _personFromList = new Person(20, "Alex"); 
    private readonly Person _personNotFromList = new Person(45, "Ben"); 

    private readonly List<Person> _persons = new()
    { 
        new Person(50, "Brian"),
        new Person(20, "Alex"),
        new Person(18, "Anna")
    };

    private readonly List<Person> _samePersons = new()
    {
        new Person(50, "Brian"),
        new Person(20, "Alex"),
        new Person(18, "Anna")
    };

    private readonly List<Person> _differentPersons = new()
    {
        new Person(50, "Brian"),
        new Person(99, "Bob"),
        new Person(18, "Anna")
    };

    /// <summary>
    /// Perfect
    /// </summary>
    [Test]
    public void FluentContains()
    {
        // PASS
        _persons.Should().ContainEquivalentOf(_personFromList);

        //PASS only with overrided equals
        _persons.Should().Contain(_personFromList);

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
        _persons.Should().ContainEquivalentOf(_personNotFromList);
    }

    /// <summary>
    /// Works only with overrided Equals method.
    /// </summary>
    [Test]
    public void ThatContains()
    {
        // PASS
        Assert.Contains(_personFromList, _persons);
        Assert.That(_persons, Does.Contain(_personFromList));

        // Expected: some item equal to <AssertsLifehacks.Person>
        // But was:  < < AssertsLifehacks.Person >, < AssertsLifehacks.Person >, < AssertsLifehacks.Person > >
        Assert.Contains(_personNotFromList, _persons);
        Assert.That(_persons, Does.Contain(_personNotFromList));       
    }

    /// <summary>
    /// Same as Contains
    /// </summary>
    [Test]
    public void ThatHas()
    {
        // PASS
        Assert.That(_persons, Has.Member(_personFromList));
       
        // Expected: some item equal to <AssertsLifehacks.Person>
        // But was:  < < AssertsLifehacks.Person >, < AssertsLifehacks.Person >, < AssertsLifehacks.Person > >
        Assert.That(_persons, Has.Member(_personNotFromList));
    }
}