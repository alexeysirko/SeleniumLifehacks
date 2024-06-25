namespace Unit8Practice.Animals
{
    internal class Animal : IPrintable
    {
        protected int _age;
        protected double _weight;

        public Animal(int age, double weight)
        {
            _age = age;
            _weight = weight;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"My age is {_age}, my weight is {_weight}");
        }

        public virtual void EatFood()
        {
            Console.WriteLine("Animal is eating food");
        }

        public int GetAge() => _age;

        ~Animal()
        {
            Console.WriteLine("Animal object is killed");
        }
    }
}
