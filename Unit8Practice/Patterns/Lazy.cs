namespace Unit8Practice.Patterns
{
    internal class Lazy
    {
        public class ExpensiveObject
        {
            public ExpensiveObject()
            {
                Console.WriteLine("ExpensiveObject created.");
            }

            public void DoWork()
            {
                Console.WriteLine("ExpensiveObject is doing work.");
            }
        }

        public class LazyExample
        {
            private static Lazy<ExpensiveObject> _lazyExpensiveObject = new Lazy<ExpensiveObject>(() => new ExpensiveObject());

            static void MainMethod()
            {
                Console.WriteLine("FactoryLogic started.");

                // Объект ExpensiveObject еще не создан
                Console.WriteLine("Before accessing Lazy object.");

                // Объект ExpensiveObject создается при первом доступе к свойству Value
                _lazyExpensiveObject.Value.DoWork();

                // Объект ExpensiveObject уже создан и используется повторно
                _lazyExpensiveObject.Value.DoWork();
            }
        }
    }
}
