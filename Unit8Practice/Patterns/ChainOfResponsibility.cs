namespace Unit8Practice.Patterns
{
    internal class ChainOfResponsibility
    {
        // Абстрактный класс обработчика
        public abstract class Handler
        {
            protected Handler _successor;

            public void SetSuccessor(Handler successor)
            {
                _successor = successor;
            }

            public abstract void HandleRequest(int request);
        }

        // Конкретные обработчики
        public class ConcreteHandler1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request < 10)
                {
                    Console.WriteLine($"{this.GetType().Name} handled request {request}");
                }
                else if (_successor != null)
                {
                    _successor.HandleRequest(request);
                }
            }
        }

        public class ConcreteHandler2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine($"{this.GetType().Name} handled request {request}");
                }
                else if (_successor != null)
                {
                    _successor.HandleRequest(request);
                }
            }
        }

        public class ConcreteHandler3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request >= 20)
                {
                    Console.WriteLine($"{this.GetType().Name} handled request {request}");
                }
                else if (_successor != null)
                {
                    _successor.HandleRequest(request);
                }
            }
        }

        // Пример использования
        class ChainExample
        {
            static void Main()
            {
                // Создаем обработчиков
                Handler h1 = new ConcreteHandler1();
                Handler h2 = new ConcreteHandler2();
                Handler h3 = new ConcreteHandler3();

                // Устанавливаем цепочку
                h1.SetSuccessor(h2);
                h2.SetSuccessor(h3);

                // Генерируем запросы
                int[] requests = { 5, 14, 22, 18, 3, 27 };

                foreach (var request in requests)
                {
                    h1.HandleRequest(request);
                }
            }
        }
    }
