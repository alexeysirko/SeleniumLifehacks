namespace Unit8Practice.Animals
{
    internal class Zoo : IPrintable
    {
        private string _city;
        private List<Animal> _animals;

        public Zoo(List<Animal> animals, string city)
        {
            _animals = animals;
            _city = city;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"In {_city} zoo we have animals:");
            foreach (var animal in _animals)
            {
                animal.PrintInfo();
            }
        }

        public void FeedAnimals()
        {
            Console.WriteLine($"Let's feed animals in {_city} Zoo!");
            int i = 0;
            while (i < _animals.Count)
            {
                _animals[i].EatFood();
                i++;
            }
        }

        public string GetCity() => _city;
    }
}
