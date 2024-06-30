using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Services
{

    public class VideoService : IVideoService
    {
        IVideoRepository VideoRepository;

        public VideoService(IVideoRepository VideoRepository)
        {
            this.VideoRepository = VideoRepository;
        }
        public Video CreateVideo(string UserEmail, DepartmentTypeEnum DepartmentType, string Title,int channelId)
        {
            return VideoRepository.CreateVideo(UserEmail, DepartmentType, Title, channelId);
        }
    }
}
