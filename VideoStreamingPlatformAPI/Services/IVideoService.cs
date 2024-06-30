using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Services
{
    public interface IVideoService
    {
        Video CreateVideo(string UserEmail, DepartmentTypeEnum DepartmentType, string Title, int channelId);
    }
}
