using InterviewVideoStraeming.Models;
using VideoStreamingPlatformAPI.Repositories;

namespace VideoStreamingPlatformAPI.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        ICommentRepository commentRepository;
        public UserService(IUserRepository userRepository, ICommentRepository commentRepository)
        {
            this._userRepository = userRepository;
            this.commentRepository = commentRepository;
        }

        public bool Comment(int videoId, string comment, string userEmail)
        {
            var user = _userRepository.GetUserByEmail(userEmail);
            if (user != null)
            {
                var IsCommentAdded = user.CommentOnVideo(videoId, comment,commentRepository);
                return IsCommentAdded;
            }
            return false;
        }

        public bool Like(int videoId, string userEmail)
        {
            var user = _userRepository.GetUserByEmail(userEmail);
            bool isLikeAdded = false;
            if (user != null) 
            {
                isLikeAdded = user.LikeVideo(videoId);
            }
            return isLikeAdded;
        }

        public string Login(string email, string password)
        {
            var Users = _userRepository.GetUsers();
            foreach (var user in Users)
            {
                if (user.Email == email && user.Password == password)
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
