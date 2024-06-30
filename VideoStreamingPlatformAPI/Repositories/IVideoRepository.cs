using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories
{
    public interface IVideoRepository
    {
        Video CreateVideo(string userEmail, DepartmentTypeEnum DepartmentType, string Title, int ChannelID);
    }
}
