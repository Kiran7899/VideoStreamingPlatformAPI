namespace VideoStreamingPlatformAPI.Services
{
    public interface ISubscribeService
    {
        void Subscribe(string userEmail, int channelID);

        void UnSubscribe(string userEmail, int channelID);
    }
}
