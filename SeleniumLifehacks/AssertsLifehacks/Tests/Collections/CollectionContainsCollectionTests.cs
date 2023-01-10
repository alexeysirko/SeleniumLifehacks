using FluentAssertions;

namespace AssertsLifehacks.Tests.Collections;

public class CollectionContainsCollectionTests : CollectionsTests
{
    [Test]
    public void FluentContains()
    {
        // PASS
        Persons.Should().Contain(ContainedPersons);
        ContainedPersons.Should().BeSubsetOf(Persons);

        /*
            Expected Persons to be a subset of {
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
            , but items {
                AssertsLifehacks.Person
                {
                    Age = 50, 
                    Name = "Brian"
                }
            }
             are not part of the superset.
         */
        Persons.Should().BeSubsetOf(ContainedPersons);
    }

    [Test]
    public void ThatContains()
    {
        // PASS
        Assert.That(Persons, Is.SupersetOf(ContainedPersons));
        Assert.That(ContainedPersons, Is.SubsetOf(Persons));

        /*
            Expected: subset of < <AssertsLifehacks.Person>, <AssertsLifehacks.Person>, <AssertsLifehacks.Person> >
            But was:  < <AssertsLifehacks.Person>, <AssertsLifehacks.Person>, <AssertsLifehacks.Person> >
            Extra items: < <AssertsLifehacks.Person> >
        */
        Assert.That(Persons, Is.SubsetOf(DifferentPersons));
    }
}
