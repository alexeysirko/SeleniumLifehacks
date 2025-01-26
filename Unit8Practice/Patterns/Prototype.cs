namespace Unit8Practice.Patterns
{
    internal class Prototype
    {
        // Интерфейс прототипа
        public interface IPrototype
        {
            IPrototype Clone();
        }

        // Конкретный прототип
        public class ConcretePrototype : IPrototype
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public IPrototype Clone()
            {
                return (IPrototype)MemberwiseClone();
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}";
            }
        }

        // Пример использования
        class PrototypeLogic
        {
            static void MainMethod()
            {
                ConcretePrototype prototype1 = new ConcretePrototype { Id = 1, Name = "Prototype 1" };
                ConcretePrototype prototype2 = (ConcretePrototype)prototype1.Clone();
                prototype2.Name = "Prototype 2";

                Console.WriteLine(prototype1);
                Console.WriteLine(prototype2);
            }
        }
    }
}
