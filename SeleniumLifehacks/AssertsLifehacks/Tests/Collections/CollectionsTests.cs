using FluentAssertions;

namespace AssertsLifehacks.Tests.Collections;

public abstract class CollectionsTests
{
    protected readonly Person PersonFromList = new Person(20, "Alex");
    protected readonly Person PersonNotFromList = new Person(45, "Ben");

    protected readonly List<Person> Persons = new()
    {
        new Person(50, "Brian"),
        new Person(20, "Alex"),
        new Person(18, "Anna")
    };

    protected readonly List<Person> SamePersons = new()
    {
        new Person(50, "Brian"),
        new Person(20, "Alex"),
        new Person(18, "Anna")
    };

    protected readonly List<Person> ContainedPersons = new()
    {
        new Person(20, "Alex"),
        new Person(18, "Anna")
    };

    protected readonly List<Person> DifferentPersons = new()
    {
        new Person(50, "Brian"),
        new Person(99, "Bob"),
        new Person(18, "Anna")
    };
}