namespace Unit8Practice
{
    internal class Donkey : Animal
    {
        private string _name;

        public Donkey(int age, double weight, string name) : base(age, weight)
        {
            _name = name;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Donkey with name {_name}: age {_age}, weight {_weight}");
        }
    }
}
