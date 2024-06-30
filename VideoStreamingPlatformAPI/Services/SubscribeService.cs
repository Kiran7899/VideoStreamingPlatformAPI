using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{
    public class SubscribeService : ISubscribeService
    {
        IUserRepository userRepository;
        IChannelRepository channelRepository;
        IVideoService videoService;
        public SubscribeService(IUserRepository userRepository, IChannelRepository channelRepository,IVideoService videoService)
        {
            this.channelRepository = channelRepository;
            this.userRepository = userRepository;
            this.videoService = videoService;
        }
        public void Subscribe(string userEmail, int channelID)
        {

            User user = userRepository.GetUserByEmail(userEmail);
            Channel channel = channelRepository.GetChannelById(channelID);

            channel.Subscribers.Add(user);

            VideoService.VideoUploaded += user.ReceiveNotificationFromSubscribedChannels;

        }

        public void UnSubscribe(string userEmail, int channelID)
        {
            User user = userRepository.GetUserByEmail(userEmail);
            Channel channel = channelRepository.GetChannelById(channelID);

            VideoService.VideoUploaded -= user.ReceiveNotificationFromSubscribedChannels;

        }
    }
}
