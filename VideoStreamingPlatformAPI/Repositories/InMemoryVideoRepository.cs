using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Repositories
{
    public class InMemoryVideoRepository : IVideoRepository
    {
        static List<Video> videos = new List<Video>();
        static Dictionary<int,Video> VideoMapByID = new Dictionary<int,Video>();
        static int videoId = 0;

        IUserRepository _userRepository;
        IChannelRepository _channelRepository;
        public InMemoryVideoRepository(IUserRepository _userRepository, IChannelRepository channelRepository)
        {
            this._userRepository = _userRepository;
            this._channelRepository = channelRepository;
        }

        List<Video> Videos = new List<Video>();
        Dictionary<int, Video> VideoBasedOnId = new Dictionary<int, Video>();
        public Video CreateVideo(string userEmail, DepartmentTypeEnum DepartmentType, string Title, int ChannelID)
        {
            Video video = new Video();
            video.Title = Title;
            video.UploadedBy = _userRepository.GetUserByEmail(userEmail);
            Channel channel = _channelRepository.GetChannelById(ChannelID);
            video.UploadedChannel = channel;
            videoId++;
            video.Id = videoId;

            videos.Add(video);
            VideoMapByID.Add(videoId, video);
            
            return video;
        }
    }
}
