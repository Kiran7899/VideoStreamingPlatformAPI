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
    public class SubscribeServiceTests
    {
        private SubscribeService GetSubscribeService(IUserRepository userRepository, IChannelRepository channelRepository)
        {
            return new SubscribeService(userRepository, channelRepository);
        }
        
        [Test]
        public void Subscribe_PassValidInput_SubscriberCountShouldBeOne()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var channelRepository = new Mock<IChannelRepository>();
            Channel channel = new Channel();
            channel.Subscribers = new List<User>();
            channelRepository.Setup(ch => ch.GetChannelById(It.IsAny<int>())).Returns(channel);
            User user = new User();
            userRepository.Setup(us => us.GetUserByEmail(It.IsAny<string>())).Returns(user);
            var subscribeService = GetSubscribeService(userRepository.Object, channelRepository.Object);

            //Act
            subscribeService.Subscribe("kiran@gmail.com", 1);

            //Assert
            Assert.That(channel.Subscribers.Count,Is.EqualTo(1));
        }

        [Test]
        public void UnSubscribe_PassValidInput_SubscriberCountShouldBeZero()
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();
            var channelRepository = new Mock<IChannelRepository>();
            Channel channel = new Channel();
            channel.Subscribers = new List<User>();
            channelRepository.Setup(ch => ch.GetChannelById(It.IsAny<int>())).Returns(channel);
            User user = new User();
            userRepository.Setup(us => us.GetUserByEmail(It.IsAny<string>())).Returns(user);
            var subscribeService = GetSubscribeService(userRepository.Object, channelRepository.Object);
            subscribeService.Subscribe("kiran@gmail.com", 1);

            //Act
            subscribeService.UnSubscribe("kiran@gmail.com", 1);

            //Assert
            Assert.That(channel.Subscribers.Count, Is.EqualTo(0));
        }
    }
}
