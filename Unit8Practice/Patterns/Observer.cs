namespace Unit8Practice.Patterns
{
    internal class Observer
    {
        // Интерфейс наблюдателя
        public interface IObserver
        {
            void Update(string message);
        }

        // Интерфейс субъекта
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        // Конкретный субъект
        public class ConcreteSubject : ISubject
        {
            private List<IObserver> _observers = new List<IObserver>();
            private string _state;

            public string State
            {
                get { return _state; }
                set
                {
                    _state = value;
                    Notify();
                }
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(_state);
                }
            }
        }

        // Конкретный наблюдатель
        public class ConcreteObserver : IObserver
        {
            private string _name;

            public ConcreteObserver(string name)
            {
                _name = name;
            }

            public void Update(string message)
            {
                Console.WriteLine($"Observer {_name} received message: {message}");
            }
        }

        // Пример использования
        class ObserverLogic
        {
            static void Main()
            {
                ConcreteSubject subject = new ConcreteSubject();

                ConcreteObserver observer1 = new ConcreteObserver("Observer 1");
                ConcreteObserver observer2 = new ConcreteObserver("Observer 2");

                subject.Attach(observer1);
                subject.Attach(observer2);

                subject.State = "State has changed!";
            }
        }
    }
}
