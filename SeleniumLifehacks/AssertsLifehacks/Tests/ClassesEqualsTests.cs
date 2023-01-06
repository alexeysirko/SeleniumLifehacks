using System.Diagnostics.CodeAnalysis;

namespace AssertsLifehacks.Tests;

public class ClassesEqualsTests
{
    private Person _person = new(20, "Alex");
    private Person _samePerson = new(20, "Alex");
    private Person _personDifferentName = new(20, "Bob");
    private Person _personFullDifferent = new(45, "Brian");

    [Test]
    public void FluentReferenceEquals()
    {

    }

    /// <summary>
    /// Use this with vanilla NUnit. Good error messages
    /// </summary>
    [Test]
    public void CompareFields()
    {
        Assert.Multiple(() =>
        {
            // Pass
            Assert.That(_person.Age, Is.EqualTo(_samePerson.Age));
            Assert.That(_person.Name, Is.EqualTo(_samePerson.Name));

            Assert.That(_person.Age, Is.EqualTo(_personDifferentName.Age));
            // Expected string length 3 but was 4. Strings differ at index 0.
            // Expected: "Bob"
            // But was:  "Alex"
            Assert.That(_person.Name, Is.EqualTo(_personDifferentName.Name));

            // Expected: 45
            // But was:  20
            Assert.That(_person.Age, Is.EqualTo(_personFullDifferent.Age));
            // Expected string length 5 but was 4. Strings differ at index 0.
            // Expected: "Brian"
            // But was:  "Alex"
            Assert.That(_person.Name, Is.EqualTo(_personFullDifferent.Name));
        });
    }


    /// <summary>
    /// Bad practice, old style. Same as .That consruction
    /// </summary>
    [Test]
    [SuppressMessage("Assertion", "NUnit2005:Consider using Assert.That(actual, Is.EqualTo(expected)) instead of Assert.AreEqual(expected, actual)")]
    public void SimpleAreEquals()
    {
        // Can pass only if you override Equals method
        Assert.Multiple(() =>
        {
            // Pass
            Assert.AreEqual(_person, _samePerson);
            
            // Expected: <AssertsLifehacks.Person>
            // But was:  <AssertsLifehacks.Person>
            Assert.AreEqual(_person, _personDifferentName);
            
            // Expected: <AssertsLifehacks.Person>
            // But was:  <AssertsLifehacks.Person>
            Assert.AreEqual(_person, _personFullDifferent);
        });
        
    }

    /// <summary>
    /// Can work only with overrided .Equals(). No information in the error message
    /// </summary>
    [Test]
    public void ThatIsEqualTo()
    {
        // Same as simple AreEqual
        Assert.Multiple(() =>
        {
            // Pass
            Assert.That(_person, Is.EqualTo(_samePerson));
            
            // Expected: <AssertsLifehacks.Person>
            // But was:  <AssertsLifehacks.Person>
            Assert.That(_person, Is.EqualTo(_personDifferentName));
           
            // Expected: <AssertsLifehacks.Person>
            // But was:  <AssertsLifehacks.Person>
            Assert.That(_person, Is.EqualTo(_personFullDifferent));
        });
    }

    /// <summary>
    /// Doesn't work!
    /// </summary>
    [Test]
    public void ThatIsSame()
    {
        Assert.Multiple(() =>
        {
            // Expected: same as <AssertsLifehacks.Person>
            // But was:  < AssertsLifehacks.Person >
            Assert.That(_person, Is.SameAs(_samePerson));

            // Expected: same as <AssertsLifehacks.Person>
            // But was:  < AssertsLifehacks.Person >
            Assert.That(_person, Is.SameAs(_personDifferentName));

            // Expected: same as <AssertsLifehacks.Person>
            // But was:  < AssertsLifehacks.Person >
            Assert.That(_person, Is.SameAs(_personFullDifferent));
        });
    }
}