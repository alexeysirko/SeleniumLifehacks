namespace Unit8Practice.Animals
{
    internal static class AnimalsFilter
    {
        public static List<Animal> FilterByAge(List<Animal> animals, int minAge)
        {
            return animals.Where(animal => animal.GetAge() > minAge).ToList();
        }

        public static void PrintGrownUps(List<Zoo> zoos, string grownUpPart)
        {
            zoos
                .Where(zoo => zoo.GetCity().Contains(grownUpPart))
                .ToList()
                .ForEach(filteredZoo => filteredZoo.PrintInfo());
        }

        public static List<Animal> OrderAnimalsByAge(List<Animal> animals)
        {
            return animals
                .OrderBy(animal => animal.GetAge())
                .ToList();
        }

        public static void GroupAnimalsByType(List<Animal> animals)
        {
            var groupedAnimals = animals.GroupBy(a => a.GetType().Name)
                            .Select(group => new
                            {
                                AnimalType = group.Key,
                                Animals = group.ToList()
                            });

            foreach (var group in groupedAnimals)
            {
                Console.WriteLine($"Animal Type: {group.AnimalType}");
                foreach (var animal in group.Animals)
                {
                    animal.PrintInfo();
                }
            }
        }
        public static void PrintDuplicates(List<Animal> animals)
        {
            var duplicates = animals
                                .GroupBy(animal => animal, new AnimalComparer())
                                .Where(group => group.Count() > 1)
                                .Select(group => group.Key);
           
            if(duplicates.Any() == false)
            {
                Console.WriteLine("There are no duplicates");
                return;
            }

            foreach (var duplicate in duplicates)
                duplicate.PrintInfo();
        }

        public static List<Animal> MergeAnimals(List<Animal> animalsLeft, List<Animal> animalsRight)
        {
            return animalsLeft.Concat(animalsRight).ToList();
        }

        public static bool HasCollectionAnimal(List<Animal> animals, Animal expectedAnimal)
        {
            return animals.Contains(expectedAnimal, new AnimalComparer());
        }
    }
}
