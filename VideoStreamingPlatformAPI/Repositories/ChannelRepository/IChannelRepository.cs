using InterviewVideoStraeming.Models;

namespace VideoStreamingPlatformAPI.Repositories.ChannelRepository
{
    public interface IChannelRepository
    {
        Channel SaveChannel(string name, int departmentId, string createdBy);

        Channel GetChannelById(int ChannelID);
    }
}
