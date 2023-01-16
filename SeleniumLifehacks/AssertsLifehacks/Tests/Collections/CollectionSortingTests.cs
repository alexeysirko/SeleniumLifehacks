namespace AssertsLifehacks.Tests.Collections;

public class CollectionSortingTests : CollectionsTest
{
    List<Person> ActualPersons => Persons;
    List<Person> ExpectedSortedPersons => ActualPersons.OrderByDescending(p => p.Age).ToList();
    List<Person> UnsortedPersons => ActualPersons.OrderBy(p => p.Age).ToList();


    /// <summary>
    /// That's good
    /// </summary>
    [Test]
    public void IsOrdered()
    {
        // PASS
        Assert.That(ExpectedSortedPersons, Is.Ordered.Descending.By("Age"));

        /*
          Expected: collection ordered by "Age", descending
          But was:  < <AssertsLifehacks.Person>, <AssertsLifehacks.Person>, <AssertsLifehacks.Person> >
          Ordering breaks at index [1]:  <AssertsLifehacks.Person>
         */
        Assert.That(UnsortedPersons, Is.Ordered.Descending.By("Age"));
    }

    /// <summary>
    /// Bad solution
    /// </summary>
    [Test]
    public void AreEqual()
    {
        // PASS
        Assert.That(ActualPersons, Is.EqualTo(ExpectedSortedPersons));

        /*
          Expected and actual are both <System.Collections.Generic.List`1[AssertsLifehacks.Person]> with 3 elements
          Values differ at index [0]
          Expected: <AssertsLifehacks.Person>
          But was:  <AssertsLifehacks.Person>
         */
        Assert.That(UnsortedPersons, Is.EqualTo(ExpectedSortedPersons));
    }    
}
