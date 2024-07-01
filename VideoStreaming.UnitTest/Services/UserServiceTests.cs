using InterviewVideoStraeming.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingPlatformAPI.Repositories;
using VideoStreamingPlatformAPI.Repositories.ChannelRepository;
using VideoStreamingPlatformAPI.Services;

namespace VideoStreaming.UnitTest.Services
{
    public class UserServiceTests
    {
        private UserService GetUserService(IUserRepository userRepository,ICommentRepository commentRepository)
        {
            return new UserService(userRepository,commentRepository);
        }

        [Test]
        public void RegisterUser_PassRequiredParameters_UserShouldBeCreated()
        {
            //Arrange
            
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(user => user.RegisterUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DepartmentTypeEnum>(), It.IsAny<UserTypeEnum>()))
                .Returns(new User() { Email = "kiran@gmail.com" });
            var commentRepo = new Mock<ICommentRepository>();   
            var userService = GetUserService(userRepo.Object,commentRepo.Object);

            //Act
            var User = userService.RegisterUser("Kiran","Email","password",DepartmentTypeEnum.DX_ADMIN,UserTypeEnum.CREATOR);

            //Assert
            Assert.That(User.Email, Is.EqualTo("kiran@gmail.com"));
        }

        [Test]
        public void Login_PassValidUserNamePassword_ReturnsSuccessMessage()
        {
            //Arrange            
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(user => user.GetUsers()).Returns(new List<User>() { new User() { Email = "Kiran@gmail.com",Password = "abc@123" } }) ;
            var commentRepo = new Mock<ICommentRepository>();
            var userService = GetUserService(userRepo.Object, commentRepo.Object);

            //Act
            var result = userService.Login("Kiran@gmail.com", "abc@123");

            //Assert
            Assert.That(result,Is.EqualTo("Success"));
        }

        [Test]
        public void Login_PassInValidPassword_ReturnsInvalidLoginMessage()
        {
            //Arrange
            var userRepo = new Mock<IUserRepository>();           
            userRepo.Setup(user => user.GetUsers()).Returns(new List<User>() { new User() { Email = "Kiran@gmail.com", Password = "abc@123" } });
            var commentRepo = new Mock<ICommentRepository>();
            var userService = GetUserService(userRepo.Object, commentRepo.Object);

            //Act
            var result = userService.Login("Kiran@gmail.com", "ab@123");

            //Assert
            Assert.That(result, Is.EqualTo("Invalid Login"));
        }

        [Test]
        public void Login_PassInValidEmail_ReturnsInvalidLoginMessage()
        {
            //Arrange
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(user => user.GetUsers()).Returns(new List<User>() { new User() { Email = "Kiran@gmail.com", Password = "abc@123" } });
            var commentRepo = new Mock<ICommentRepository>();
            var userService = GetUserService(userRepo.Object, commentRepo.Object);

            //Act
            var result = userService.Login("Kira@gmail.com", "abc@123");

            //Assert
            Assert.That(result, Is.EqualTo("Invalid Login"));
        }
    }
}
