using Unit8Practice;


List<Animal> animals = new List<Animal>();
animals.Add(new Animal(25, 70));
animals.Add(new Animal(3, 4.55));
animals.Add(new Monkey(7, 39.5, "Banana"));
animals.Add(new Donkey(12, 69, "Donny"));
animals.Add(new Monkey(18, 75, "Bamboo"));
animals.Add(new Donkey(2, 32.2, "Little"));

Zoo zoo = new(animals, "NewYork");
zoo.PrintAnimals();
zoo.FeedAnimals();
