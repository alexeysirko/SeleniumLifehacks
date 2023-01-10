namespace AssertsLifehacks;

public class Person : IEquatable<Person?>
{
    public int Age { get; set; }
    public string Name { get; set; }

    public Person(int age, string name)
    {
        Age = age;
        Name = name;
    }

    public bool Equals(Person? other)
    {
        return other is not null &&
               Age == other.Age &&
               Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Age, Name);
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }
}
