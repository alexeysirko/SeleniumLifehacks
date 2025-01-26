namespace Unit8Practice.Patterns
{
    // Интерфейс стратегии
    public interface IStrategy
    {
        void AlgorithmInterface();
    }

    // Конкретная стратегия A
    public class ConcreteStrategyA : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyA AlgorithmInterface");
        }
    }

    // Конкретная стратегия B
    public class ConcreteStrategyB : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyB AlgorithmInterface");
        }
    }

    // Контекст
    public class Context
    {
        private IStrategy _strategy;

        // Конструктор принимает стратегию
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.AlgorithmInterface();
        }
    }

    // Пример использования
    class StrategyLogic
    {
        static void MainMethod()
        {
            Context context;

            // Используем стратегию A
            context = new Context(new ConcreteStrategyA());
            context.ExecuteStrategy();

            // Переключаемся на стратегию B
            context.SetStrategy(new ConcreteStrategyB());
            context.ExecuteStrategy();
        }
    }
}
