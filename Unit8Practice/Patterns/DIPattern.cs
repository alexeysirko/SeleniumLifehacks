namespace Unit8Practice.Patterns
{
    internal class DIPattern
    {
        // Интерфейс службы
        public interface IService
        {
            void Serve();
        }

        // Реализация службы
        public class Service : IService
        {
            public void Serve()
            {
                Console.WriteLine("Service Called");
            }
        }

        // Клиент, который использует службу
        public class Client
        {
            private readonly IService _service;

            // Внедрение зависимости через конструктор
            public Client(IService service)
            {
                _service = service;
            }

            public void Start()
            {
                Console.WriteLine("Service is starting...");
                _service.Serve();
            }
        }

        // Пример использования
        class Program
        {
            static void MainMethod()
            {
                // Создание экземпляра службы
                IService service = new Service();

                // Внедрение зависимости в клиент
                Client client = new Client(service);

                // Запуск клиента
                client.Start();
            }
        }
    }
}
