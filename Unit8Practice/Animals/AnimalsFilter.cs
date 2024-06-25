namespace Unit8Practice.Animals
{
    internal static class AnimalsFilter
    {
        public static List<Animal> FilterByAge(List<Animal> animals, int minAge)
        {
            return animals.Where(animal => animal.GetAge() > minAge).ToList();
        }
    }
}
