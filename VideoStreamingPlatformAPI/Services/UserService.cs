using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public string Login(string userName, string password)
        {
            var Users = _userRepository.GetUsers();
            foreach (var user in Users)
            {
                if (user.Email == userName && user.Password == password)
                    return "Success";
            }
            return "Invalid Login";
        }

        public User RegisterUser(
            string username,
            string email,
            string password,
            DepartmentTypeEnum department,
            UserTypeEnum role)
        {
            return _userRepository.RegisterUser(username, email, password, department, role);
        }
    }
}
