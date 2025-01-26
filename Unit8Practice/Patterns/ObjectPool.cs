using System.Collections.Concurrent;

namespace Unit8Practice.Patterns
{
    public class ObjectPool<T> where T : new()
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly int _maxSize;

        public ObjectPool(int maxSize)
        {
            _objects = new ConcurrentBag<T>();
            _maxSize = maxSize;
        }

        // Получаем из пула, если есть. Или создаем новый
        public T GetObject()
        {
            if (_objects.TryTake(out T item))
            {
                return item;
            }
            return new T();
        }

        // Возврат объекта обратно в пул
        public void AddObject(T item)
        {
            if (_objects.Count < _maxSize)
            {
                _objects.Add(item);
            }
        }
    }

    // Пример использования
    class ObjectPoolLogic
    {
        static void MainMethod()
        {
            var pool = new ObjectPool<MyClass>(5);

            MyClass obj1 = pool.GetObject();
            MyClass obj2 = pool.GetObject();

            pool.AddObject(obj1);
            pool.AddObject(obj2);
        }
    }

    public class MyClass
    {
        public string Driver { get; set; }
    }
}
