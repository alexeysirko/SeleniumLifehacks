namespace Unit8Tests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class MultiThreadTests
    {
        private static ThreadLocal<int> _threadLocal = new ThreadLocal<int>(() => 0);
        

        [Test, Parallelizable]
        public void TestThreadLocal()
        {
            Parallel.For(0, 10, i =>
            {
                _threadLocal.Value = i;
                Console.WriteLine($"Thread local: i is {i}, thread is {_threadLocal.Value}");
                Assert.AreEqual(i, _threadLocal.Value);
            });          
        }


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
                // This statement ensures that only one thread can enter the critical section at a time.
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
