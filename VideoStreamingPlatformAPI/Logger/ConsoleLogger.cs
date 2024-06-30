namespace VideoStreamingPlatformAPI.Logger
{
    public class ConsoleLogger : ILoggerVideoStreamingAPI
    {
        public void Error(string message,Exception exception)
        {
            Console.WriteLine($"ERROR: {message} \n {exception.Message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void Warn(string message)
        {
            Console.WriteLine($"WARNING : {message}");
        }
    }
}
