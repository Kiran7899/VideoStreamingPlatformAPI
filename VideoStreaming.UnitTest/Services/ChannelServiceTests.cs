using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Services;
using Moq;
using InterviewVideoStraeming.Models;

namespace VideoStreaming.UnitTest.Services
{
    public class ChannelServiceTests
    {
        private ChannelService GetChannelService(IChannelRepository ChannelRepository)
        {
            return new ChannelService(ChannelRepository);
        }

        [Test]
        public void CreateChannel_ValidInputs_ReturnsChannelObject()
        {
            var channelRepository = new Mock<IChannelRepository>();
            var departmentRepository = new Mock<IDepartmentRepository>();   
            var channelService = GetChannelService(channelRepository.Object);
            var Channel = new Channel();
            Channel.Name = "New Channel";
            channelRepository.Setup(ch => ch.SaveChannel(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Channel);

            var result = channelService.CreateChannel(1, "Channel1", "Kiran");

            Assert.That(result.Name,Is.EqualTo("New Channel"));
        }
    }
}
