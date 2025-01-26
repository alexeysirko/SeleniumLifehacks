namespace Unit8Practice.Patterns
{
    internal class SyncSingletone
    {
        public sealed class Singleton
        {
            private static Singleton _instance = null;
            private static readonly object _lock = new object();

            private Singleton() { }

            public static Singleton Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton();
                            }
                        }
                    }
                    return _instance;
                }
            }

            public void DoSomething()
            {
                Console.WriteLine("Driver running");
            }
        }

        // Пример использования
        class SyncSingletoneLogic
        {
            static void MainMethod()
            {
                Singleton singleton = Singleton.Instance;
                singleton.DoSomething();
            }
        }
    }
}
