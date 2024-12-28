namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            //Test: Both instances should be the same
            Console.WriteLine(Object.ReferenceEquals(logger1, logger2));

            //Log messages
            logger1.Log("First message");
            logger2.Log("Second messasge");
        }
    }

    class Logger
    {
        private static Logger? _instance;

        private static readonly object _lock = new();

        //Private constructor
        private Logger() { }

        //Public static property to access the singleton instance
        public static Logger Instance { 
            get 
            {
                lock (_lock)
                {
                    _instance ??= new Logger();
                }

                return _instance;
            }
        }

        //Log method
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
}
