namespace Unit8Practice
{
    internal class Animal
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
    }
}
