using InterviewVideoStraeming.Models;


namespace VideoStreamingPlatformAPI.Repositories.ChannelRepository
{
    public class InMemoryChannelRepository : IChannelRepository
    {
        Dictionary<int,Channel> ChannelMapByID = new Dictionary<int,Channel>();
        static int ChannelId = 0;

        IDepartmentRepository departmentRepository;
        IUserRepository userRepository;

        public InMemoryChannelRepository(IDepartmentRepository departmentRepository,IUserRepository userRepository) 
        {
            this.departmentRepository = departmentRepository;
            this.userRepository = userRepository;
        }

        public Channel GetChannelById(int ChannelID)
        {
            if (ChannelMapByID.ContainsKey(ChannelID)) 
                return ChannelMapByID[ChannelID];

            return null!;
        }

        public Channel SaveChannel(string name, int departmentId, string createdBy)
        {
            ChannelId++;
            Department department = departmentRepository.GetDepartmentById(departmentId);
            Channel channel = new Channel();
            channel.Name = name;
            channel.Department = department;
            channel.CreatedBy = userRepository.GetUserByEmail(createdBy);
            channel.Id = ChannelId;

            ChannelMapByID.Add(ChannelId, channel);

            return channel;
        }
    }
}
