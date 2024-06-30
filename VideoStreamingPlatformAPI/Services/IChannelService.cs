

using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Services
{
    public interface IChannelService
    {
        Channel CreateChannel(int DepartmentId, string ChannelName, string CreatedBy);
    }
}
