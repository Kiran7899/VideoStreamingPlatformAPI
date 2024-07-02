using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{
    public class SubscribeService : ISubscribeService
    {
        IUserRepository userRepository;
        IChannelRepository channelRepository;
        public SubscribeService(IUserRepository userRepository, IChannelRepository channelRepository)
        {
            this.channelRepository = channelRepository;
            this.userRepository = userRepository;
        }
        public void Subscribe(string userEmail, int channelID)
        {

            User user = userRepository.GetUserByEmail(userEmail);
            Channel channel = channelRepository.GetChannelById(channelID);

            channel.Subscribers.Add(user);

            channel.VideoUploaded += user.ReceiveNotificationFromSubscribedChannels;

        }

        public void UnSubscribe(string userEmail, int channelID)
        {
            User user = userRepository.GetUserByEmail(userEmail);
            Channel channel = channelRepository.GetChannelById(channelID);

            channel.Subscribers.Remove(user);

            channel.VideoUploaded -= user.ReceiveNotificationFromSubscribedChannels;

        }
    }
}
