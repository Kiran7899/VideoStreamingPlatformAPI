using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Event;
using VideoStreamingPlatformAPI.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{

    public class VideoService : IVideoService
    {
        IVideoRepository VideoRepository;
        IChannelRepository channelRepository;
        IUserRepository userRepository;

        public VideoService(IVideoRepository VideoRepository, IChannelRepository channelRepository, IUserRepository userRepository)
        {
            this.VideoRepository = VideoRepository;
            this.channelRepository = channelRepository; 
            this.userRepository = userRepository;
        }
        public Video CreateVideo(string UserEmail, DepartmentTypeEnum DepartmentType, string Title,int channelId)
        {            
            var video = VideoRepository.CreateVideo(UserEmail, DepartmentType, Title, channelId);
            var channel = channelRepository.GetChannelById(channelId);
            channel.AddVideo(video);

            //OnVideoUploaded(channelId, Title, UserEmail);
            return video;
        }

        public List<Video> GetVideos()
        {
            var videos = VideoRepository.GetVideos();
            return videos;
        }
    }
}
