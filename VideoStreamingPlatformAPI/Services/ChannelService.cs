using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;

namespace VideoStreamingPlatformAPI.Services
{
    
    public class ChannelService : IChannelService
    {
        IChannelRepository ChannelRepository;
        IDepartmentRepository DepartmentRepository;
        public ChannelService(IChannelRepository ChannelRepository, IDepartmentRepository DepartmentRepository)
        {
            this.ChannelRepository = ChannelRepository;
            this.DepartmentRepository = DepartmentRepository;
        }

        public Channel CreateChannel(int DepartmentId, string ChannelName, string CreatedBy)
        {
            return ChannelRepository.SaveChannel(ChannelName,DepartmentId, CreatedBy);
        }
    }
}
