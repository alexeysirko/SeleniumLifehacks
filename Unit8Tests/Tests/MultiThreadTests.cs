using System.Threading;

namespace Unit8Tests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class MultiThreadTests
    {
        // Похож на ThreadStatic, но предоставляет более гибкий и мощный способ управления данными, специфичными для каждого потока.
        // ThreadLocal позволяет инициализировать значение для каждого потока с помощью делегата и предоставляет методы для управления жизненным циклом этих значений.
        private static ThreadLocal<int> _threadLocal = new ThreadLocal<int>(() => 0);
        

        [Test, Parallelizable]
        public void TestThreadLocal()
        {
            Parallel.For(0, 10, i =>
            {
                // .Value пример метода
                _threadLocal.Value = i;
                Console.WriteLine($"Thread local: i is {i}, thread is {_threadLocal.Value}");
                Assert.AreEqual(i, _threadLocal.Value);
            });          
        }


        // Используется для создания переменных, которые являются уникальными для каждого потока.
        // Переменная, помеченная атрибутом ThreadStatic, имеет отдельное значение для каждого потока.
        // Это полезно, когда нужно хранить данные, специфичные для каждого потока
        [ThreadStatic]
        private static int _threadStatic;

        [Test, Parallelizable]
        public void TestThreadStatic()
        {
            Parallel.For(0, 10, i =>
            {
                _threadStatic = i;
                Console.WriteLine($"Thread static: i is {i}, thread is {_threadStatic}");
                Assert.AreEqual(i, _threadStatic);
            });
        }


        // Асинхронные методы (async/await): Идеальны для ввода-вывода и операций, которые могут быть приостановлены без блокировки потоков. Похожи на синхронные
        // Многопоточные методы (lock): Идеальны для задач, требующих параллельного выполнения и интенсивных вычислений.
        [Test, Parallelizable]
        public async Task TestAsyncMethod()
        {
            int result = await AsyncMethod();
            Assert.Greater(25, result);
        }

        private async Task<int> AsyncMethod()
        {
            await Task.Delay(100);
            int random = new Random().Next(50);
            Console.WriteLine($"Async number generated {random}");
            return random;
        }


        private static int _counter;
        // This is the object used to synchronize access. It should be a private, static, and readonly object to ensure it’s shared among all threads.
        private static readonly object _lock = new object();

        [Test, Parallelizable]
        public void TestSynchronization()
        {
            Parallel.For(0, 1000, i =>
            {
                // Используется для синхронизации доступа к общим ресурсам между несколькими потоками.
                // lock блокирует определенный участок кода, чтобы только один поток мог выполнить его в данный момент времени.
                // Это предотвращает состояние гонки и обеспечивает целостность данных.
                lock (_lock)
                {
                    _counter++;
                }
            });

            Assert.AreEqual(1000, _counter);
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            _threadLocal.Dispose();
        }
    }
}
