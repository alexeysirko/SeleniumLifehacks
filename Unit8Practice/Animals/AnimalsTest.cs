namespace Unit8Practice.Animals
{
    internal class AnimalsTest
    {
        public static void ZooLogic()
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(25, 70));
            animals.Add(new Animal(3, 4.55));
            animals.Add(new Monkey(7, 39.5, "Banana"));
            animals.Add(new Monkey(7, 39.5, "Banana"));
            animals.Add(new Donkey(12, 69, "Donny"));
            animals.Add(new Monkey(18, 75, "Bamboo"));
            animals.Add(new Donkey(2, 32.2, "Little"));

            Zoo zoo = new(animals, "New York");
            zoo.PrintInfo();
            Console.WriteLine();
            zoo.FeedAnimals();

            Console.WriteLine("\nFiltering practice");
            List<Animal> filteredAnimals = AnimalsFilter.FilterByAge(animals, 10);
            Zoo filteredZoo = new(filteredAnimals, "City of grown-up animals");
            filteredZoo.PrintInfo();

            List<Zoo> zoos = new();
            zoos.Add(zoo);
            zoos.Add(filteredZoo);
            
            Console.WriteLine("\nPractice with lambda");
            AnimalsFilter.PrintGrownUps(zoos, "grown-up");
            
            Console.WriteLine("\nPracticew with group");
            AnimalsFilter.GroupAnimalsByType(animals);

            Console.WriteLine("\nPractice with duplicates");
            Console.WriteLine("Duplicates list:");
            AnimalsFilter.PrintDuplicates(animals);
        }
    }
}
