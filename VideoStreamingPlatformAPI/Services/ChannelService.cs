using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{
    
    public class ChannelService : IChannelService
    {
        IChannelRepository ChannelRepository;
        public ChannelService(IChannelRepository ChannelRepository)
        {
            this.ChannelRepository = ChannelRepository;
        }

        public Channel CreateChannel(int DepartmentId, string ChannelName, string CreatedBy)
        {
            return ChannelRepository.SaveChannel(ChannelName,DepartmentId, CreatedBy);
        }
    }
}
