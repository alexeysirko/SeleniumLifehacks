using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Unit8Tests.Tests
{
    public record Person(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("surname")] string Surname,
        [property: JsonPropertyName("age")] int Age);
    public record Users(
        [property: JsonPropertyName("users")] List<Person> Persons);

    [TestFixture]
    internal class DDTTests : BaseTest
    {
        public static IEnumerable<Person> TestDataPersons
        {
            get
            {
                var jsonData = File.ReadAllText("Resources/testCaseSource.json");
                var users = JsonSerializer.Deserialize<Users>(jsonData);
                foreach (var person in users.Persons)
                {
                    yield return person;
                }
            }
        }


        [Test]
        //Можно передать cтатик поле, свойство или метод
        [TestCaseSource(nameof(TestDataPersons))]
        public void DDTTest(Person testPerson)
        {
            Assert.Multiple(() =>
            {
                Assert.That(testPerson.Name, Does.StartWith("J"));
                Assert.That(testPerson.Surname, Does.Not.EndsWith("es"));
                Assert.That(testPerson.Age, Is.GreaterThan(0));
            });
        }

        [Test, Category("Magic")]
        public void ShouldFail()
        {
            Assert.That(5, Is.GreaterThan(6));
        }
    }
}
