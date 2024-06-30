namespace VideoStreamingPlatformAPI.Logger
{
    public interface ILoggerVideoStreamingAPI
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message, Exception exception);
    }
}
