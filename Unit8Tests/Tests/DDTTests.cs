using System.Text.Json;
using System.Text.Json.Serialization;

namespace Unit8Practice.Tests
{
    public record Person(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("surname")] string Surname,
        [property: JsonPropertyName("age")] int Age);
    public record Users(
        [property: JsonPropertyName("users")] List<Person> Persons);

    [TestFixture]
    internal class DDTTests
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
    }
}
