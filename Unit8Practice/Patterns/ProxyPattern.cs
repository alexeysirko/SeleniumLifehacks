namespace Unit8Practice.Patterns
{
    internal class ProxyPattern
    {
        // Интерфейс субъекта
        public interface ISubject
        {
            void Request();
        }

        // Реальный субъект
        public class RealSubject : ISubject
        {
            public void Request()
            {
                Console.WriteLine("RealSubject: Handling Request.");
            }
        }

        // Заместитель
        public class Proxy : ISubject
        {
            private RealSubject _realSubject;

            public void Request()
            {
                if (_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }
                Console.WriteLine("ProxyPattern: Logging request.");
                _realSubject.Request();
            }
        }

        // Пример использования
        class ProxyLogic
        {
            static void Main()
            {
                ISubject proxy = new Proxy();
                proxy.Request();
            }
        }
    }
}
