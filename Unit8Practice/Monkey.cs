namespace Unit8Practice
{
    internal class Monkey : Animal
    {
        private string _foodType;

        public Monkey(int age, double weight, string foodType) : base(age, weight)
        {
            _foodType = foodType;
        }

        public override void EatFood()
        {
            Console.WriteLine($"This monkey loves {_foodType}");
        }
    }
}
