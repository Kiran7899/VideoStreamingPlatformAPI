using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Event;

namespace VideoStreamingPlatformAPI.Services
{
    public interface IVideoService
    {
        Video CreateVideo(string UserEmail, DepartmentTypeEnum DepartmentType, string Title, int channelId);

        static event VideoUploadedEventHandler VideoUploaded;

        List<Video> GetVideos();
    }
}
