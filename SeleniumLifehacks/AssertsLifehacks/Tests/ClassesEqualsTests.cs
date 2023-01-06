using System.Diagnostics.CodeAnalysis;

namespace AssertsLifehacks.Tests;

public class ClassesEqualsTests
{
    private Person _person = new Person(20, "Alex");
    private Person _samePerson = new Person(20, "Alex");
    private Person _personDifferentName = new Person(20, "Bob");
    private Person _personFullDifferent = new Person(45, "Brian");

    [Test]
    [SuppressMessage("Assertion", "NUnit2005:Consider using Assert.That(actual, Is.EqualTo(expected)) instead of Assert.AreEqual(expected, actual)")]
    public void SimpleAreEquals()
    {
        // Can't work with complex types
        Assert.Multiple(() =>
        {
            Assert.AreEqual(_person, _samePerson);
            Assert.AreEqual(_person, _personDifferentName);
            Assert.AreEqual(_person, _personFullDifferent);
        });
        // 3 same errors:
        // Expected: <AssertsLifehacks.Person>
        // But was:  <AssertsLifehacks.Person>
    }

    [Test]
    public void ThatIsEqualTo() 
    {
        // Same as simple AreEqual
        Assert.Multiple(() =>
        {
            Assert.That(_samePerson, Is.EqualTo(_person));
            Assert.That(_samePerson, Is.EqualTo(_personDifferentName));
            Assert.That(_samePerson, Is.EqualTo(_personFullDifferent));
        });
        // 3 same errors:
        // Expected: <AssertsLifehacks.Person>
        // But was:  <AssertsLifehacks.Person>
    }
}